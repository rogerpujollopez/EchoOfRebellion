using FormBase;
using MiFtp;
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

namespace FormProcessarComanda
{
    public partial class frmProcessarComandes : frmBase
    {
        public frmProcessarComandes()
        {
            InitializeComponent();
        }

        private Ftp ftp;

        private void frmProcessarComandes_Load(object sender, EventArgs e)
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

        }

        private void EntrarDirectoriInicial()
        {
            string[] carperas = UsuariActiu.ftpremotepath.TrimStart('/').Split('/');
            ObtenerDir();
            if (carperas.Length > 0)
            {
                foreach (string s in carperas)
                {
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Busquem fitxers al ftp


        }
    }
}
