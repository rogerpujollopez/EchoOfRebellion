using Configuracio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;

namespace FormBase
{
    public partial class frmBase : Form
    {
        System.Windows.Forms.Timer timer;

        public frmBase()
        {
            InitializeComponent();

            this.KeyPreview = true;

            if (UsuariActiu.usuari != null)
            {
                Usuario(UsuariActiu.usuari.UserName);
            }
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            BackColor = Config.Colores.Formularios.BackColor;

            PanelTop.BackColor = Config.Colores.Cabecera.BackColor;

            var labels = PanelTop.Controls.OfType<Label>();

            foreach (Label label in labels)
            {
                label.BackColor = Config.Colores.Cabecera.BackColor;
                label.ForeColor = Config.Colores.Cabecera.ForeColor;
            }

            lineTitulo.BackColor = Config.Colores.Cabecera.ForeColor;

            ActualizarHora();

            timer = new System.Windows.Forms.Timer()
            {
                Interval = 1000,
                Enabled = false
            };
            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();
        }

        //public void TituloBorrar(string titulo)
        //{
        //    lblTitulo.Text = titulo;
        //}

        protected string Titulo
        {
            set
            {
                lblTitulo.Text = value;
                AjustarLinea();
            }
        }

        protected void AjustarLinea()
        {
            lineTitulo.Width = Math.Max(lblTitulo.Width, lblUsuario.Width);
        }

        protected void Usuario(string usuario)
        {
            lblUsuario.Text = usuario;
            AjustarLinea();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            ActualizarHora();
        }

        private void ActualizarHora()
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

        private void frmBase_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(e);
        }

        protected virtual void HandleKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }

    }
}
