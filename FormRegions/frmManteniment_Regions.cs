using FormBaseBBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                new casella() { nom = "id", visible = false },
                new casella() { nom = "CodeRegion", ample = 100, visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "DescRegion", ample = 100, visible = true},
                new casella() { nom = "Remarks", ample = 300, visible = true},
            };

            // ds Combo
            //SetLlistes = new List<llista>()
            //{
            //    new llista() { id="idRegion", query="select idRegion,CodeRegion,DescRegion as Region from Regions order by Region"}
            //};

        }

        private void frmManteniment_Regions_Load(object sender, EventArgs e)
        {
            InicializarFormulario(this);
        }
    }
}
