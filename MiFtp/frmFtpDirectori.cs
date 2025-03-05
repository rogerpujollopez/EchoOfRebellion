using FormBase;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;
using static MiFtp.Ftp;

namespace MiFtp
{
    public partial class frmFtpDirectori : frmBase
    {
        public string RetornRuta { get; private set; }
        public string rutainicial;

        public frmFtpDirectori(string rutainicial)
        {
            InitializeComponent();
            this.rutainicial = rutainicial;
        }

        private Ftp ftp;

        private void frmFtpDirectori_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;  // Vista de detalles (columnas)
            listView1.FullRowSelect = true;  // Seleccionar toda la fila
            listView1.GridLines = true;      // Mostrar líneas de cuadrícula

            // Agregar columnas
            listView1.Columns.Add("Nombre", 150);
            listView1.Columns.Add("Tamaño", 100);
            listView1.Columns.Add("Fecha Modificación", 100);

            ftp = new Ftp(UsuariActiu.ftpserver, UsuariActiu.ftpuser, UsuariActiu.ftppass);

            EntrarDirectoriInicial();

            //ObtenerDir();
        }

        private void EntrarDirectoriInicial()
        {
            string[] carperas = rutainicial.TrimStart('/').Split('/');
            ObtenerDir();
            if (carperas.Length > 0)
            {
                foreach (string s in carperas) {
                    ftp.CambiarDeCarpeta(s);
                    ObtenerDir();
                }
            }
        }


        List<strFtpElemento> _contenido = new List<strFtpElemento>();

        private void ObtenerDir()
        {
            listView1.Items.Clear();

            ftp.GetDir();

            lblRuta.Text = ftp.GetCarpetaActual();

            _contenido = ftp.ObtenerDir();

            foreach (strFtpElemento item in _contenido)
            {
                ListViewItem listItem = new ListViewItem(item.Nombre);

                if (item.EsCarpeta)
                {
                    listItem.SubItems.Add("Carpeta");
                }
                else
                {
                    listItem.SubItems.Add(item.Tamaño.ToString() + " bytes");
                }

                listItem.SubItems.Add(item.FechaCompleta?.ToString("dd-MM-yyyy HH:mm") ?? "N/A");

                listView1.Items.Add(listItem);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            string nombreSeleccionado = listView1.SelectedItems[0].Text;

            var elemento = _contenido.FirstOrDefault(ev => ev.Nombre == nombreSeleccionado);

            if (elemento != null)
            {
                if (elemento.EsCarpeta)
                {
                    ftp.CambiarDeCarpeta(nombreSeleccionado);
                    ObtenerDir();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetornRuta = lblRuta.Text; 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombreCarpeta = Interaction.InputBox("Ingrese el nombre de la nueva carpeta:", "Crear Carpeta FTP", "");

            if (string.IsNullOrWhiteSpace(nombreCarpeta))
            {
                SetLogColor = Color.Red;
                SetLog = "Nombre válido.";
                return;
            }

            ftp.NuevaCarpeta(nombreCarpeta);
            ObtenerDir();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                SetLogColor = Color.Red;
                SetLog = "Selecciona la carpeta a eliminar.";
                return;
            }

            string nomCarpeta = listView1.SelectedItems[0].Text;

            ftp.EliminarDirectorio(nomCarpeta);
            ObtenerDir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                SetLogColor = Color.Red;
                SetLog = "Selecciona el fitxer a eliminar.";
                return;
            }

            string nom = listView1.SelectedItems[0].Text;

            ftp.EliminarFichero(nom);
            ObtenerDir();
        }
    }
}
