using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EchoOfRebellion.Formularios
{
    public partial class frmTemp : Form
    {
        public frmTemp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tabla = "Regions";

            frmManteniment_Regions frm = new frmManteniment_Regions();
            frm.Tabla = tabla;
            frm.Query = "select idRegion,CodeRegion,DescRegion,Remarks from Regions";
            frm.Titulo = $"Mantenimiento tabla '{tabla}'";
            frm.SetId = "idRegion";
            frm.SetCaselles = new List<casella>() {
                new casella(){ nom="id", ample=100 , visible=true, alineacio=CasellaAlineacio.Centrat},
                new casella() { nom ="name", ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { nom="name2", ample=300, visible = true},
            };
            //frm.QueryUpdate = "select * from Regions";

            //frm.Columnas.Add(new ManualTextBox.Columa()
            //{
            //    nombre = "ID",
            //    tamaño = 0
            //});

            //frm.Columnas.Add(new ManualTextBox.Columa()
            //{
            //    nombre = "Código",
            //    tamaño = 50
            //});

            //frm.Columnas.Add(new ManualTextBox.Columa()
            //{
            //    nombre = "Descripción",
            //    tamaño = 80
            //});

            //frm.Columnas.Add(new ManualTextBox.Columa()
            //{
            //    nombre = "Observaciones",
            //    tamaño = 100
            //});

            //frm.Columnas.Add(new ManualTextBox.Columa()
            //{
            //    nombre = "idRegion",
            //    tamaño = 0
            //});

            //frm.Columnas.Add(new ManualTextBox.Columa()
            //{
            //    nombre = "Región",
            //    tamaño = 50
            //});

            //frm.Combos.Add(new ManualTextBox.Combo()
            //{
            //    id = "idRegion",
            //    valor = "CodeRegion",
            //    tabla = "Regions",
            //    binding = "idRegion",
            //    columna = 5
            //});

            frm.ShowDialog();


        }
    }
}
