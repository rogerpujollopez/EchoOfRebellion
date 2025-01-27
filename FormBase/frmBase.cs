using Configuracio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;

namespace FormBase
{
    public partial class frmBase : Form
    {
        private Timer timer;
        private Timer logTimer;
        public frmBase()
        {
            InitializeComponent();

            UsuariActiu.InformacionActualizada += ClaseEstatica_InformacionActualizada;
            pbu.Click += Pbu_Click;

            this.KeyPreview = true;

            ActualizarUsuari();
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

            logTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000, // 5 segundos
                Enabled = false
            };
            logTimer.Tick += LogTimer_Tick;
        }

        protected void ActualizarUsuari()
        {
            if (UsuariActiu.usuari != null)
            {
                Usuario(UsuariActiu.usuari.UserName);
                using (var ms = new MemoryStream(UsuariActiu.usuari.Photo))
                {
                    pbu.Image = Image.FromStream(ms); // Convertir los bytes en una imagen y asignarla al PictureBox
                }
                int height = PanelTop.Height - (pbu.Top * 2);

                pbu.Width = pbu.Height = height;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UsuariActiu.InformacionActualizada -= ClaseEstatica_InformacionActualizada;
            base.OnFormClosed(e);
        }

        private void ClaseEstatica_InformacionActualizada(object sender, EventArgs e)
        {
            ActualizarInformacion();
        }

        protected virtual void ActualizarInformacion()
        {
            ActualizarUsuari();
        }

        protected string Titulo
        {
            set
            {
                lblTitulo.Text = value;
                AjustarLinea();
            }
        }

        private void AjustarLinea()
        {
            lineTitulo.Width = Math.Max(lblTitulo.Width, lblUsuario.Width);
        }

        private void Usuario(string usuario)
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

        private bool activarTimerLog = false;

        public bool SetLogActivarTimer
        {
            set
            {
                activarTimerLog = value;
            }
        }

        public string SetLog
        {
            set
            {
                label1.Text = value;
                Refresh();

                logTimer.Stop();

                if (activarTimerLog)
                {
                    logTimer.Start();
                }
            }
        }

        public Color SetLogColor
        {
            set
            {
                label1.ForeColor = value;
            }
        }

        private void LogTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            logTimer.Stop();
        }

        private void Pbu_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
