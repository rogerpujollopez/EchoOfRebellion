using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EchoOfRebellion.Clases.BIZ;
using EchoOfRebellion.Clases.Utils;
using FormBase;

namespace EchoOfRebellion.Formularios
{
    public partial class frmUsuarioCambioPassword : frmBase
    {
        string user;
        public frmUsuarioCambioPassword(string User)
        {
            InitializeComponent();
            user = User;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;
        }

        private void frmUsuarioCambioPassword_Load(object sender, EventArgs e)
        {
            Titulo = "Establecer una contraseña";
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string usuario = txtConfirmarUsu.Text;
            string nuevoPassword = txtPass.Text;
            string confirmarPassword = txtPass2.Text;
            string mail = txtMail.Text;
            if (txtConfirmarUsu.Text == user)
            {
                bool esok = BIZLogin.RevisarCondicionesRestablecer(usuario, nuevoPassword, confirmarPassword);
                if (esok)
                {
                    int code = BIZLogin.EnviarMail(usuario, mail);

                    frmVerificacionMail frmValidacoEmail = new frmVerificacionMail(code, usuario, nuevoPassword, mail);
                    frmValidacoEmail.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Inserta tu usuario");
            }
            
        }

        private void bttnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
