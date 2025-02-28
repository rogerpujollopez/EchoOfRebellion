using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
    public static class Funcions
    {
        public static string SeleccionarCarpeta(string rutaInicial = "")
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona una carpeta";
                folderDialog.ShowNewFolderButton = true;

                if (!string.IsNullOrWhiteSpace(rutaInicial))
                {
                    folderDialog.SelectedPath = rutaInicial;
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
            }
            return string.Empty;
        }

        public static string ObtindreCarpetaPrograma()
        {
            return Application.StartupPath;
        }

        public static string ObtindreCarpetaPrograma(string fitxer)
        {
            return Path.Combine(ObtindreCarpetaPrograma(), fitxer);
        }

        public static void Impresoras(ComboBox combo)
        {
            List<string> impresoras = Impresoras();

            combo.Items.Clear();

            foreach (string item in impresoras)
            {
                combo.Items.Add(item);
            }

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0; 
            }
        }


        public static List<string> Impresoras()
        {
            List<string> impresoras = new List<string>();

            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                impresoras.Add(printerName);
            }
            return impresoras;
        }

        public static string Left(this string texto, int length)
        {
            if (string.IsNullOrEmpty(texto) || length <= 0)
                return string.Empty;

            return texto.Length <= length ? texto : texto.Substring(0, length);
        }

        public static PictureBox ObtenerPicturesBox(Control.ControlCollection controls, string nombre)
        {
            foreach(Control c in controls)
            {
                if (c.Tag != null && c.Tag.ToString() == nombre) 
                {
                    return (PictureBox)c;
                }
            }

            return null;
        }

        public static string RutaImagen(string titol) //  Seleccionar Imatge
        {
            string ruta = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = titol;
                openFileDialog.Filter = "Imatges JPG i PNG|*.jpg;*.png";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ruta = openFileDialog.FileName;
                }
            }

            return ruta;
        }

        public static string CreateSalt()
        {
            DateTime today = DateTime.Today;
            string strHash = today.ToString("yyyyMMddHHmmssfff");
            return strHash.Hash256();
        }

        public static int CreateNumRNG()
        {
            using (RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider())
            {
                byte[] valor = new byte[4];

                rngCrypt.GetBytes(valor);

                int valor3 = BitConverter.ToInt32(valor, 0);

                valor3 = Math.Abs(100000 + (valor3 % 900000));

                return valor3;
            }
        }

        public static string RandomText_Basic(int longitud)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";

            return _Random_Basic(longitud, alphabet);
        }

        public static string RandomNumber_Basic(int longitud)
        {
            const string alphabet = "0123456789";

            return _Random_Basic(longitud, alphabet);
        }

        private static string _Random_Basic(int longitud, string alphabet)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int RandomNumber;
            RandomNumber = rand.Next(100000, 999999);
            string ret = "";
            for (int t = 0; t < longitud; t++) { ret += alphabet.Substring(rand.Next(0, alphabet.Length - 1), 1); }

            return ret;
        }
        public static bool ValidacionLogin(string login)
        {
            string regexLogin = @"^[a-zA-Z0-9]{4,20}$";
            bool esValid = Regex.IsMatch(login, regexLogin);

            return esValid;
        }
        public static bool ValidacionPassword(string password)
        {
            string regexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d@$]{8,20}$";
            bool esValid = Regex.IsMatch(password, regexPassword);

            return esValid;
        }
    }

}
