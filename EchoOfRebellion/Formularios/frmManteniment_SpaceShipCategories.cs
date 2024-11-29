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
        }

        private void frmManteniment_ShipCategories_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
        }
    }
}
