using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiFtp
{
    public class Ftp
    {
        private string url; // ftp://sqlserver.S2AM.sdslab.cat
        private string username; // g01
        private string password; // 12345aA

        public Ftp(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = password;
        }

        private Stack<string> carpetas = new Stack<string>();
        private List<strFtpElemento> contenido = new List<strFtpElemento>();

        public byte[] DownloadFile(string ftpfile)
        {
            string rutaCarpeta = GetRutaCarpeta();

            rutaCarpeta = string.IsNullOrEmpty(rutaCarpeta) ? ftpfile : $"{rutaCarpeta}/{ftpfile}";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(rutaCarpeta);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream ftpStream = response.GetResponseStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                ftpStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public class strFtpElemento
        {
            public string Permisos { get; set; }  // Permisos de archivo/carpeta (ej. "drwxr-xr-x")
            public int NumEnlaces { get; set; }   // Número de enlaces (1 para archivos, más para carpetas)
            public string Propietario { get; set; } // Usuario propietario
            public string Grupo { get; set; }       // Grupo propietario
            public long Tamaño { get; set; }     // Tamaño del archivo (en bytes)
            public string Fecha { get; set; }    // Fecha de última modificación
            public string Hora { get; set; }     // Hora de última modificación
            public DateTime? FechaCompleta { get; set; }
            public string Nombre { get; set; }   // Nombre del archivo o carpeta

            public bool EsCarpeta => Permisos.StartsWith("d"); // Determina si es carpeta
        }

        private strFtpElemento ParsearElemento(string detalle)
        {
            string[] partes = detalle.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length < 8)
                return new strFtpElemento { Nombre = detalle };

            return new strFtpElemento
            {
                Permisos = partes[0],    // drwxr-xr-x (carpeta) o -rw-r--r-- (archivo)
                NumEnlaces = int.TryParse(partes[1], out int enlaces) ? enlaces : 1,
                Propietario = partes[2],
                Grupo = partes[3],
                Tamaño = long.TryParse(partes[4], out long tam) ? tam : 0,
                Fecha = partes[5] + " " + partes[6], // Mes y día
                Hora = partes[7],                   // Hora o año
                Nombre = string.Join(" ", partes, 8, partes.Length - 8)
            };
        }

        public void GetDir()
        {
            contenido = new List<strFtpElemento>();

            string rutaCarpeta = GetRutaCarpeta();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(rutaCarpeta);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != FtpStatusCode.OpeningData)
                {
                    throw new Exception("No se pudo abrir la conexión de datos FTP.");
                }

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var elemento = ParsearElemento(line);

                        if (!elemento.EsCarpeta)
                        {
                            elemento.FechaCompleta = Convert.ToDateTime(elemento.Fecha + " " + elemento.Hora);
                        }

                        contenido.Add(elemento);
                        //textBox1.Text += line + Environment.NewLine;
                    }
                }
            }

            if (carpetas.Count > 0)
            {
                AgregarCarpetaAtras();
            }
        }

        public void CambiarDeCarpeta(string nombreSeleccionado)
        {
            var elemento = contenido.FirstOrDefault(ev => ev.Nombre == nombreSeleccionado);

            if (elemento != null)
            {
                if (elemento.EsCarpeta)
                {
                    if (elemento.Nombre == "..")
                    {
                        carpetas.Pop();
                    }
                    else
                    {
                        carpetas.Push(elemento.Nombre);
                    }
                    ObtenerDir();
                }
            }
        }

        private void AgregarCarpetaAtras()
        {
            strFtpElemento carpetaAtras = new strFtpElemento
            {
                Nombre = "..",
                Permisos = "drwxr-xr-x", // Permisos de carpeta (solo de referencia)
                NumEnlaces = 0,
                Propietario = "root",
                Grupo = "root",
                Tamaño = 0,
                FechaCompleta = null  // No necesitamos fecha para ".."
            };

            contenido.Insert(0, carpetaAtras);  // Lo agregamos al inicio de la lista
        }

        public List<strFtpElemento> ObtenerDir()
        {
            return contenido;
        }

        private string GetCarpetas()
        {
            return string.Join("/", carpetas.Reverse());
        }

        private string GetRutaCarpeta()
        {
            string rutaCarpeta = GetCarpetas();

            rutaCarpeta = string.IsNullOrEmpty(rutaCarpeta) ? url : $"{url}/{rutaCarpeta}";

            return rutaCarpeta;
        }

        public string GetCarpetaActual()
        {
            string rutaCarpeta = GetCarpetas();
            rutaCarpeta = string.IsNullOrEmpty(rutaCarpeta) ? "/" : $"/{rutaCarpeta}";

            return rutaCarpeta;
        }

        public void NuevaCarpeta(string nombreCarpeta)
        {
            string rutaCarpeta = GetRutaCarpeta();
            rutaCarpeta = $"{rutaCarpeta}/{nombreCarpeta}";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(rutaCarpeta);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                carpetas.Push(nombreCarpeta);
            }

            ObtenerDir();
        }

        public void EliminarDirectorio(string nombreCarpeta)
        {
            string rutaCarpeta = GetRutaCarpeta();
            rutaCarpeta = $"{rutaCarpeta}/{nombreCarpeta}";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(rutaCarpeta);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory; // Comando RMD para eliminar carpetas
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                // Nada
            }

            ObtenerDir();
        }

        public void EliminarFichero(string nombreCarpeta)
        {
            string rutaCarpeta = GetRutaCarpeta();
            rutaCarpeta = $"{rutaCarpeta}/{nombreCarpeta}";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(rutaCarpeta);
            request.Method = WebRequestMethods.Ftp.DeleteFile; // Comando DELE para eliminar archivos
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                // Nada
            }

            ObtenerDir();
        }

        public void UploadFile(byte[] arr, string fileName)
        {
            string rutaCarpeta = GetRutaCarpeta();
            rutaCarpeta = $"{rutaCarpeta}/{fileName}";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(rutaCarpeta);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            // Leer el archivo local y enviarlo al servidor FTP
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(arr, 0, arr.Length);
            }

            // Obtener la respuesta del servidor
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                //addLog($"Archivo '{fileName}' subido con éxito.");
            }

            ObtenerDir();
        }
    }
}
