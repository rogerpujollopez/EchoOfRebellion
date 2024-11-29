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
    public partial class frmManteniment_Sectors : frmBaseBBDD
    {
        public frmManteniment_Sectors()
        {
            InitializeComponent();
        }

        private void frmManteniment_Sectors_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
        }
    }
}
