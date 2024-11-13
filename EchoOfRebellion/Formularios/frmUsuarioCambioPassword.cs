using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoOfRebellion
{
    public partial class frmUsuarioCambioPassword : frmBase
    {
        public frmUsuarioCambioPassword()
        {
            InitializeComponent();
        }

        private void frmUsuarioCambioPassword_Load(object sender, EventArgs e)
        {
            Titulo("Módulo de mantenimiento");
            Usuario("Supermega nombre del usuario como no puede ser otro");
        }
    }
}
