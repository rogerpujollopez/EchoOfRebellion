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
    public partial class frmSplash : Form
    {
        //private int posicion = 0;
        //private List<int> offset = new List<int>() { 50, 50, 80, 20, 20, 20, 100, 50, 50, 100 };

        public frmSplash()
        {
            InitializeComponent();
            timerLaser.Enabled = true;
        }

        private void timerLaser_Tick(object sender, EventArgs e)
        {
            Point pos = pictureLaser.Location;
            pos.X += 10;
            pictureLaser.Location = pos;
            //posicion += 1;
            if (pos.X >= 440) 
            {
                timerLaser.Enabled = false;
                this.Close();
            }
        }
    }
}
