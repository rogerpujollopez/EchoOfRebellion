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

namespace FormSectors
{
    public partial class frmManteniment_Sectors : frmBaseBBDD
    {
        public frmManteniment_Sectors()
        {
            InitializeComponent();

            string tabla = "Sectors";

            Data data = new Data()
            {
                autoLabel = true,
                taule = "Sectors",
                querySelect = @"select idSector,s.idRegion,CodeSector,DescSector,s.Remarks,r.DescRegion from Sectors as s left join Regions as r on s.idRegion=r.idRegion",
                queryUpdate = @"select idSector,CodeSector,DescSector,Remarks,idRegion from Sectors",
                id = "idSector",
                titol = $"Mantenimiento tabla '{tabla}'"
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella(){ nom="id", ample=100 , visible=true, alineacio=CasellaAlineacio.Centrat},
                new casella() { nom ="name", ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { nom="name2", ample=300, visible = true},
            };

            // ds Combo
            SetLlistes = new List<llista>()
            {
                new llista() { id="idRegion", query="select idRegion,CodeRegion,DescRegion as Region from Regions order by Region"}
            };

        }

        private void frmManteniment_Sectors_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
        }

        //protected override void HandleKeyDown(KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //    }
        //}

    }
}
