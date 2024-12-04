using FormBaseBBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormRegions
{
    public partial class frmManteniment_Regions : frmBaseBBDD
    {
        public frmManteniment_Regions()
        {
            InitializeComponent();

            string tabla = "Regions";

            Data data = new Data()
            {
                autoLabel = true,
                taule = tabla,
                querySelect = @"select idRegion,CodeRegion,DescRegion,Remarks from Regions",
                queryUpdate = @"select idRegion,CodeRegion,DescRegion,Remarks from Regions",
                id = "idRegion",
                titol = $"Mantenimiento tabla '{tabla}'"
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella(){ nom="id", ample=100 , visible=true, alineacio=CasellaAlineacio.Centrat},
                new casella() { nom ="name", ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { nom="name2", ample=300, visible = true},
            };

            // ds Combo
            //SetLlistes = new List<llista>()
            //{
            //    new llista() { id="idRegion", query="select idRegion,CodeRegion,DescRegion as Region from Regions order by Region"}
            //};

        }

        private void frmManteniment_Regions_Load(object sender, EventArgs e)
        {

            this.SuspendLayout();

            InicializarFormulario();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
