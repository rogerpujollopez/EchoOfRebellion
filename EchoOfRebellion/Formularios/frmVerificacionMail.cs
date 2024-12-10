﻿using EchoOfRebellion.Clases.BIZ;
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
    public partial class frmVerificacionMail : Form
    {
        //private bool verificado;
        private int code, count;
        private string usuario, nuevoPassword, mail;
        public frmVerificacionMail(int Code, string Usuario, string NuevoPassword, string Mail)
        {
            InitializeComponent();
            code = Code;
            usuario = Usuario;
            nuevoPassword = NuevoPassword;
            mail = Mail;
            count = 0;
        }

        private void imgArrow_Click(object sender, EventArgs e)
        {
            txtCodeEmail.Clear();
            this.Close();
        }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();

            Form cambioPassForm = Application.OpenForms["frmUsuarioCambioPassword"];
            if (cambioPassForm != null)
            {
                cambioPassForm.Close();
            }

            Form loginForm = Application.OpenForms["frmLogin"];
            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                new frmLogin().Show();
            }
        }

        //public bool Verificado
        //{
        //    get
        //    {
        //        return verificado;
        //    }
        //}

        private void bttnEnviarCodigo_Click(object sender, EventArgs e)
        {
            if (txtCodeEmail.Text == code.ToString())
            {
                BIZLogin.RestablecerPassword(usuario, nuevoPassword, mail);
                panelSuccess.Visible = true;
               
                txtCodeEmail.Enabled = false;
                bttnEnviarCodigo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Código erroneo");
            }
        }

        private void labelReenviar_Click(object sender, EventArgs e)
        {
            if (count<3)
            {
                code = BIZLogin.EnviarMail(usuario, mail);
                MessageBox.Show("Código reenviado");
            }
            else
            {
                MessageBox.Show("Has llegado al máximo de codigos, habla con el administrador");
            }
        }
    }
}
