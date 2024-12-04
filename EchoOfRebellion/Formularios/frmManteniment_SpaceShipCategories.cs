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

namespace EchoOfRebellion.Formularios
{
    public partial class frmManteniment_SpaceShipCategories : frmBaseBBDD
    {
        public frmManteniment_SpaceShipCategories()
        {
            InitializeComponent();

            string tabla = "SpaceShipCategories";

            Data data = new Data()
            {
                autoLabel = true,
                taule = tabla,
                querySelect = @"select idSpaceShipCategory,CodeSpaceShipCategory,DescSpaceShipCategory from SpaceShipCategories",
                queryUpdate = @"select idSpaceShipCategory,CodeSpaceShipCategory,DescSpaceShipCategory from SpaceShipCategories",
                id = "idSpaceShipCategory",
                titol = $"Mantenimiento tabla '{tabla}'"
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella(){ nom="id", ample=100 , visible=true, alineacio=CasellaAlineacio.Centrat},
                new casella() { nom ="name", ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { nom="name2", ample=300, visible = true},
            };
        }

        private void frmManteniment_ShipCategories_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
        }
    }
}
