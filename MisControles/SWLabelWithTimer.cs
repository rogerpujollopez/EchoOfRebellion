using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisControles
{
    public partial class SWLabelWithTimer : UserControl
    {
        System.Windows.Forms.Timer timer;
        System.Windows.Forms.Timer timerParpelleig;

        private int intervalo = 5000;
        private Color colorFons;
        private Color colorText;
        private Color colorTextHigh;

        private int offset_h = 6;
        private bool busy = false;
        private bool quieroSalir = false;

        public SWLabelWithTimer()
        {
            InitializeComponent();
            Visible = false;
            timer = new System.Windows.Forms.Timer()
            {
                Enabled = false,
                Interval = intervalo
            };
            timer.Tick += Timer_Tick;
            lbltext.SizeChanged += LblText_SizeChanged;
            lbltext.AutoSize = true;

            timerParpelleig = new System.Windows.Forms.Timer()
            {
                Enabled = false,
                Interval = 1000
            };
            timerParpelleig.Tick += TimerParpelleig_Tick;
        }

        private void LblText_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(lbltext.Width, lbltext.Height + offset_h);
        }

        private void TimerParpelleig_Tick(object sender, EventArgs e)
        {
            //timerParpelleig.Interval = 1000;
            HiloParpadeo();
        }

        private void HiloParpadeo()
        {
            if (!quieroSalir && !busy)
            {
                busy = true;
                ThreadPool.QueueUserWorkItem(state => Parpelleig());
            }
        }

        private void Parpelleig()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => ActualizarParpelleig()));
            }
            else
            {
                ActualizarParpelleig();
            }
        }

        private void ActualizarParpelleig()
        {
            //lbltext.ForeColor = colorText;
            //lbltext.Refresh();
            //Thread.Sleep(100);

            lbltext.ForeColor = colorTextHigh;
            lbltext.Refresh();
            Thread.Sleep(100);

            lbltext.ForeColor = colorText;
            lbltext.Refresh();
            Thread.Sleep(100);

            lbltext.ForeColor = colorTextHigh;
            lbltext.Refresh();
            Thread.Sleep(100);

            lbltext.ForeColor = colorText;
            lbltext.Refresh();
            busy = false;
        }


        public void Activar()
        {
            Visible = true;
            timer.Enabled = true;
            lbltext.BackColor = colorFons;
            this.BackColor = colorFons;
            lbltext.ForeColor = colorText;
            timerParpelleig.Enabled = true;
            HiloParpadeo();
        }

        public void Desactivar()
        {
            timerParpelleig.Enabled = false;
            timer.Enabled = false;
            Visible = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Desactivar();
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Interval durada")]
        public int IntervalDurada
        {
            get { return intervalo; }
            set
            {
                timer.Enabled = false;
                intervalo = Math.Min(Math.Max(2000, intervalo), 15000);
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Text del label")]
        public string TextLabel
        {
            get { return lbltext.Text; }
            set
            {
                lbltext.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Color Fons")]
        public Color ColorFons
        {
            get
            {
                return colorFons;
            }
            set
            {
                colorFons = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Color Text")]
        public Color ColorText
        {
            get
            {
                return colorText;
            }
            set
            {
                colorText = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Color Text Parpelleig")]
        public Color ColorTextParpelleig
        {
            get
            {
                return colorTextHigh;
            }
            set
            {
                colorTextHigh = value;
            }
        }
    }
}
