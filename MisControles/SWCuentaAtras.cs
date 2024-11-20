using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MisControles
{
    public partial class SWCuentaAtras : UserControl
    {
        private Timer timerSegundos;
        private int segundos;
        private bool _enabled;
        public event EventHandler CuentaFinalizada;

        //private int _offset_h = -20;
        //private int _width, _height;

        public SWCuentaAtras()
        {
            InitializeComponent();
            InicializarTimerSegundos();

            //lbltiempo.Text = "00:00";
            //_width = lbltiempo.Width;
            //_width = lbltiempo.Height;

            //this.Size = new Size(_width, _height + _offset_h);
            //lbltiempo.SizeChanged += LblTiempo_SizeChanged;

            lbltiempo.AutoSize = true;

        }

        //private void LblTiempo_SizeChanged(object sender, EventArgs e)
        //{
        //    this.Size = new Size(lbltiempo.Width, lbltiempo.Height + _offset_h);
        //}

        public int Segundos
        {
            set { 
                segundos = value; 
            }
            get { return segundos; }
        }

        public bool Activado
        {
            set {  
                _enabled = value;
                timerSegundos.Enabled = _enabled;
                DibujarSegundos();
            }
            get { return _enabled; }
        }

        private void InicializarTimerSegundos()
        {
            timerSegundos = new Timer();
            timerSegundos.Interval = 1000; // 1 segundo
            timerSegundos.Tick += Timer_Tick_Segundos;
        }

        private void Timer_Tick_Segundos(object sender, EventArgs e)
        {
            if (segundos > 0)
            {
                segundos--;
                DibujarSegundos();
            } else
            {
                timerSegundos.Enabled = false;
                OnCuentaFinalizada(EventArgs.Empty);
            }
        }

        private void DibujarSegundos()
        {
            lbltiempo.Text = TimeSpan.FromSeconds(segundos).ToString(@"mm\:ss");
        }

        protected virtual void OnCuentaFinalizada(EventArgs e)
        {
            CuentaFinalizada?.Invoke(this, e);
        }

    }
}
