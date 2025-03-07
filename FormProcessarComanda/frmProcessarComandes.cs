using EDILibrary;
using FormBase;
using FormVisualizacionListado;
using MiFtp;
using System;
using System.Collections.Generic;
using BiblioModeloDatos;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;
using Utils;
using static MiFtp.Ftp;
using System.Data.SqlClient;

namespace FormProcessarComanda
{
    public partial class frmProcessarComandes : frmBase
    {
        public frmProcessarComandes()
        {
            InitializeComponent();
        }

        private Ftp ftp;
        private FileSystemWatcher fileWatcher;
        private Timer timerDelayRefreshDir;
        private Timer timerDelayEdi;

        private void frmProcessarComandes_Load(object _sender, EventArgs _e)
        {
            listView1.View = View.Details;  // Vista de detalles (columnas)
            listView1.FullRowSelect = true;  // Seleccionar toda la fila
            listView1.GridLines = true;      // Mostrar líneas de cuadrícula

            // Agregar columnas
            listView1.Columns.Add("Nombre", 150);
            listView1.Columns.Add("Tamaño", 100);
            listView1.Columns.Add("Fecha Modificación", 100);

            listView2.View = View.Details;  // Vista de detalles (columnas)
            listView2.FullRowSelect = true;  // Seleccionar toda la fila
            listView2.GridLines = true;      // Mostrar líneas de cuadrícula
            listView2.MultiSelect = false;   // No permitir selección múltiple
            listView2.Enabled = false;       // Deshabilitar interacción directa del usuario (solo lectura)

            // Agregar columnas
            listView2.Columns.Add("Nombre", 150);
            listView2.Columns.Add("Tamaño", 100);
            listView2.Columns.Add("Fecha Modificación", 100);

            SubLog("Inicializando ftp ...");
            ftp = new Ftp(UsuariActiu.ftpserver, UsuariActiu.ftpuser, UsuariActiu.ftppass);

            EntrarDirectoriInicial();

            SubLog("Obteniendo lista de ficheros locales ...");
            ObtenerDirLocal();

            SubLog("Iniciado File Watcher");
            IniciarFileWatcher();

            SubLog();

            timerDelayRefreshDir = new Timer();
            timerDelayRefreshDir.Interval = 1000;
            timerDelayRefreshDir.Tick += (sender, e) =>
            {
                timerDelayRefreshDir.Stop();
                EventoTimerDelayRefreshDir();
            };

            timerDelayEdi = new Timer();
            timerDelayEdi.Interval = 1000;
            timerDelayEdi.Tick += (sender, e) =>
            {
                timerDelayEdi.Stop();
                EventoTimerDelayEdi();
            };
        }

        private void EventoTimerDelayRefreshDir()
        {
            this.Invoke((MethodInvoker)delegate
            {
                ObtenerDirLocal();
            });
        }

        private void EventoTimerDelayEdi()
        {
            this.Invoke((MethodInvoker)delegate
            {
                ProcessarEdi();
            });
        }

        private void IniciarTimer()
        {
            timerDelayRefreshDir.Stop(); // Si ya está en marcha, lo reinicia
            timerDelayRefreshDir.Start(); // Inicia el timer
        }

        private string carpetaDescarrega = UsuariActiu.ftplocalpath;

        Queue<string> cola = new Queue<string>();

        private void IniciarFileWatcher()
        {
            // Verificar si la carpeta existe
            if (!Directory.Exists(carpetaDescarrega))
            {
                MessageBox.Show("La carpeta no existe: " + carpetaDescarrega, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Inicializar FileSystemWatcher
            fileWatcher = new FileSystemWatcher
            {
                Path = carpetaDescarrega,
                Filter = "*.edi", 
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite, // Detectar creaciones y modificaciones
                EnableRaisingEvents = true // Habilitar eventos
            };

            // Suscribir eventos
            fileWatcher.Created += OnFileCreated;
            fileWatcher.Deleted += OnFileDeleted;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            // Evitar problemas de acceso al UI thread
            this.Invoke((MethodInvoker)delegate
            {
                SubLog($"Nuevo archivo detectado: {e.Name}"); // e.FullPath
                cola.Enqueue(e.FullPath);
                timerDelayEdi.Start();
                ObtenerDirLocal();
            });
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                SubLog($"** Eliminado archivo {e.Name}"); // e.FullPath

                foreach (ListViewItem item in listView2.Items)
                {
                    if (item.Text.Equals(e.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        listView2.Items.Remove(item);
                        break; // Salimos del bucle tras eliminar el ítem
                    }
                }

                IniciarTimer();
            });
        }

        private void EntrarDirectoriInicial()
        {
            SubLog("Obteniendo lista de ficheros del ftp ...");

            string[] carperas = UsuariActiu.ftpremotepath.TrimStart('/').Split('/');
            ObtenerDirFtp();
            if (carperas.Length > 0)
            {
                foreach (string s in carperas)
                {
                    ftp.CambiarDeCarpeta(s);
                    ObtenerDirFtp();
                }
            }
        }

        List<strFtpElemento> _contenido = new List<strFtpElemento>();

        private void ObtenerDirFtp()
        {
            listView1.Items.Clear();

            ftp.GetDir();

            lblRuta.Text = ftp.GetCarpetaActual();

            _contenido = ftp.ObtenerDir();

            foreach (strFtpElemento item in _contenido)
            {
                if (!item.EsCarpeta && item.Nombre.EndsWith(".edi", StringComparison.OrdinalIgnoreCase))
                {
                    ListViewItem listItem = new ListViewItem(item.Nombre);
                    listItem.SubItems.Add(item.Tamaño.ToString() + " bytes");
                    listItem.SubItems.Add(item.FechaCompleta?.ToString("dd-MM-yyyy HH:mm") ?? "N/A");
                    listView1.Items.Add(listItem);
                }
            }
        }

        private void SubLog(string msg) 
        {
            txtLog.Text = msg + Environment.NewLine + txtLog.Text;
        }

        private void SubLog()
        {
            SubLog("Ready !");
        }

        private void ObtenerDirLocal()
        {
            string rutaCarpeta = UsuariActiu.ftplocalpath;

            if (!Directory.Exists(rutaCarpeta))
            {
                SubLog("La carpeta local no existe.");
                return;
            }

            string[] archivos = Directory.GetFiles(rutaCarpeta, "*.edi", SearchOption.TopDirectoryOnly);

            listView2.Items.Clear();

            foreach (string archivo in archivos)
            {
                string nombreArchivo = Path.GetFileName(archivo);
                long tamaño = new FileInfo(archivo).Length; // Obtener tamaño en bytes
                string fechaModificacion = File.GetLastWriteTime(archivo).ToString("dd-MM-yyyy HH:mm");

                // Crear la fila con los datos
                ListViewItem item = new ListViewItem(nombreArchivo);
                item.SubItems.Add($"{tamaño} bytes"); // Agregar tamaño
                item.SubItems.Add(fechaModificacion); // Agregar fecha de modificación

                listView2.Items.Add(item); // Agregar al ListView
            }

            lblLocal.Text = rutaCarpeta;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Busquem fitxers al ftp

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No hi han fitxers seleccionats.", "Avis!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ftp.NuevaCarpeta(UsuariActiu.ftpprocessedpath, false);

                SubLog("Descarregant fitxers ...");

                string rutalocal = UsuariActiu.ftplocalpath;

                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    string nombreArchivo = item.Text;

                    SubLog($"Descarregant {nombreArchivo}");

                    Application.DoEvents();

                    byte[] arr = ftp.DownloadFile(nombreArchivo);

                    string rutaLocalfile = $"{rutalocal}/{nombreArchivo}";
                    Funcions.SaveFile(arr, rutaLocalfile);

                    SubLog($"Movent fitxer {nombreArchivo} a {UsuariActiu.ftpprocessedpath}");

                    ftp.MoverFichero(nombreArchivo, UsuariActiu.ftpprocessedpath.TrimEnd('/'));

                    Application.DoEvents();
                    
                    ObtenerDirFtp();
                }

                SubLog("Fi descarrega");
            }
            catch (Exception ex) 
            {
                SubLog(ex.Message);
            }

            SubLog();

        }

        private bool ediEnCurso = false;

        private void ProcessarEdi()
        {
            if (ediEnCurso) return;
            if (cola.Count == 0) return;

            ediEnCurso = true;

            string rutaArchivo = cola.Dequeue();

            string[] lineas = File.ReadAllLines(rutaArchivo, Encoding.UTF8);

            int idOrder = 0;

            try
            {
                idOrder = Edi.EDItoOrder(lineas);

                string nombreArchivo = Path.GetFileName(rutaArchivo);
                string rutaDirectorio = Path.GetDirectoryName(rutaArchivo);

                SubLog($"Fichero {nombreArchivo} procesado");
                SubLog($"Nº de orden {idOrder} asignado");

                try
                {
                    Funcions.MoverArchivo(rutaDirectorio, nombreArchivo, UsuariActiu.ftpprocessedpath);
                    SubLog($"Fichero {nombreArchivo} movido a {UsuariActiu.ftpprocessedpath}");
                }
                catch (Exception ex) {
                    throw new Exception($"Error al mover el fichero {nombreArchivo} , error {ex.Message}");
                }
            }
            catch (Exception ex) 
            {
                SubLog($"Error en fichero {rutaArchivo} , error {ex.Message}");
            }
            finally
            {
                SubLog();
                ediEnCurso = false;
                timerDelayEdi.Start();
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            clsModeloDatos dm = new clsModeloDatos();
            frmListado_Factory frm = new frmListado_Factory();

            string codeOrder = txtOrderCode.Text;

            string query = @"
                    select idOrder
                    from Orders 
                    where codeOrder = @codeOrder
                ";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@codeOrder", codeOrder));

            DataSet ds = dm.PortarPerConsulta(query, parametros);
            DataRow row = ds.Tables[0].Rows[0];

            frm.IdOrder = (short)row["idOrder"];
            frm.ShowDialog();
        }
    }
}
