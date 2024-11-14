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
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;
        }

        private void frmUsuarioCambioPassword_Load(object sender, EventArgs e)
        {
            Titulo("Establecer una contraseña");
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {

        }
    }
}
