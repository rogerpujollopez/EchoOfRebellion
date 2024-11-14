using Configuracio;
using EchoOfRebellion.Clases.BIZ;
using EchoOfRebellion.Clases.Utils;
using MisControles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Schema;
using UsuariActiuNameSpace;
using static BiblioModeloDatos.DM.DMModel;

namespace EchoOfRebellion
{
    public partial class frmLogin : Form
    {
        private System.Windows.Forms.Timer timerDesplazamiento;
        private System.Windows.Forms.Timer timerParpadeo;
        int segundos = 0;

        private bool busy = false;
        private bool quieroSalir = false;
        private bool verCuentaAtras = false;

        List<PictureBox> leds = new List<PictureBox>();

        public frmLogin()
        {
            InitializeComponent();
            InicializarTimerDesplazamiento();
            InicializarListaLeds();

            //swTextbox1.BackColorGetFocus = Color.Cyan;
            //swTextbox1.BackColorLostFocus = Color.Gray;
            //swTextbox1.BackColorError = Color.IndianRed;

            //swLabelWithTimer1.ColorFons = Color.Black;
            //swLabelWithTimer1.ColorText = Color.Red;
            //swLabelWithTimer1.ColorTextParpelleig = Color.FromArgb(255, 102, 102);
            //swLabelWithTimer1.IntervalDurada = 5000;

            swCuentaAtras1.Top -= swCuentaAtras1.Height;
            swCuentaAtras1.CuentaFinalizada += Crash;
        }

        private void InicializarTimerDesplazamiento()
        {
            timerDesplazamiento = new System.Windows.Forms.Timer();
            timerDesplazamiento.Interval = 50; // 50 ms para el desplazamiento suave
            timerDesplazamiento.Tick += Timer_Tick_Desplazamiento;

            timerParpadeo = new System.Windows.Forms.Timer();
            timerParpadeo.Interval = 1000; // 1 segundo para el parpadeo
            timerParpadeo.Tick += Timer_Tick_Parpadeo;
        }

        private void InicializarListaLeds()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox && pictureBox.Tag?.ToString() == "led")
                {
                    pictureBox.Visible = false;
                    leds.Add(pictureBox);
                }
            }
        }

        int posicion = 0;
        int offset = 3;

        private void Timer_Tick_Desplazamiento(object sender, EventArgs e)
        {
            if (posicion < swCuentaAtras1.Height)
            {
                posicion += offset;
                swCuentaAtras1.Top += offset;
            }
            else
            {
                timerDesplazamiento.Enabled = false;
            }
        }

        private void Timer_Tick_Parpadeo(object sender, EventArgs e)
        {
            HiloParpadeo();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            //swLabelWithTimer1.TextLabel = "abcdefghijklmn";
            //swLabelWithTimer1.Activar();
            Salir();
        }

        private void Salir()
        {
            if (Missatgeria.Sortir())
            {
                Cerrar();
            }
        }

        private void lblSubmit_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private void HiloParpadeo()
        {
            if (!quieroSalir && !busy)
            {
                busy = true;
                ThreadPool.QueueUserWorkItem(state => Parpadeo());
            }
        }

        private void Crash(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void Parpadeo()
        {
            AccionLeds(Properties.Resources.LedsRojo_Flojo);
            Thread.Sleep(50);

            AccionLeds(Properties.Resources.LedsRojo_Alto);
            Thread.Sleep(50);

            AccionLeds(Properties.Resources.LedsRojo_Flojo);
            Thread.Sleep(50);

            AccionLeds(Properties.Resources.LedsRojo_Alto);
            Thread.Sleep(50);

            AccionLeds(Properties.Resources.LedsRojo_Flojo);
            busy = false;
        }

        private void AccionLeds(Image nuevaImagen)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => ActualizarImagenEnLeds(nuevaImagen)));
            }
            else
            {
                ActualizarImagenEnLeds(nuevaImagen);
            }
        }

        private void ActualizarImagenEnLeds(Image nuevaImagen)
        {
            foreach (PictureBox led in leds)
            {
                led.Image = nuevaImagen;
                led.Refresh();
            }
        }

        private void Cerrar()
        {
            quieroSalir = true;

            while (busy)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            };

            this.Close();
        }

        private void Press_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Salir();
                    break;
                case Keys.Enter:
                    RevisarEnter();
                    break;
            }
        }

        private void RevisarEnter()
        {
            if (txtUsuario.Text != "" && txtPass.Text != "") 
            {
                // Validamos
                Validar();
            }
            else
            {
                SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void Validar()
        {
            string usuari = txtUsuario.Text;
            string pass = txtPass.Text;

            int resultado = BIZLogin.BizLogin(usuari, pass);

            switch (resultado)
            {
                case 1: // OK
                    OcultarContador();
                    Cerrar();
                    break;
                case 2: // OK + new pass
                    OcultarContador();
                    frmUsuarioCambioPassword frm = new frmUsuarioCambioPassword();
                    frm.ShowDialog();
                    Cerrar();
                    break;
                default:
                    if (!verCuentaAtras)
                    {
                        ValidacionKo();
                    }
                    break;
            }
        }

        private void OcultarContador()
        {
            swCuentaAtras1.Activado = false;
            timerDesplazamiento.Enabled = false;
            timerParpadeo.Enabled = false;

            foreach (PictureBox led in leds)
            {
                led.Visible = false;
            }
            //swCuentaAtras1.Visible = false;
        }

        private void ValidacionKo()
        {
            verCuentaAtras = true;
            swCuentaAtras1.Segundos = 15;
            swCuentaAtras1.Activado = true;

            int minutos = 1;
            segundos = minutos * 60;

            timerDesplazamiento.Enabled = true;

            foreach (PictureBox led in leds)
            {
                led.Visible = true;
            }

            HiloParpadeo();
            timerParpadeo.Enabled = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            BackColor = Config.Colores.Formularios.BackColor;
        }
    }
}
