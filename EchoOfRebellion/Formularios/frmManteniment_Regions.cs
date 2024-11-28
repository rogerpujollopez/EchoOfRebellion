using EchoOfRebellion.Clases.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoOfRebellion.Formularios
{
    public partial class frmManteniment_Regions : frmBaseBBDD
    {
        private int _offset_left, _offset_top;

        public frmManteniment_Regions()
        {
            InitializeComponent();
        }

        private void frmManteniment_Regions_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
        }
    }
}
