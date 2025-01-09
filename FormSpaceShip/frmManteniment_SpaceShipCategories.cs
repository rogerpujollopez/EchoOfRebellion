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

namespace FormSpaceShip
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
                new casella() { visible = false },
                new casella() { ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { ample=400, visible = true},
            };
        }

        private void frmManteniment_ShipCategories_Load(object sender, EventArgs e)
        {
            InicializarFormulario(this);
        }
    }
}
