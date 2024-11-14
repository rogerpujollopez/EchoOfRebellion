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
    public partial class frmSplashUsuario : frmBase
    {
        private Timer timer;

        public frmSplashUsuario()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;

            timer = new Timer
            {
                Interval = 2000
            };

            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();

        }

        private void frmSplashUsuario_Load(object sender, EventArgs e)
        {
            Titulo("Bienvenido!!!");
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
