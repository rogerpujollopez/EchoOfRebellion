using FormRegions;
using FormSectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EchoOfRebellion.Formularios
{
    public partial class frmTemp : Form
    {
        public frmTemp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmManteniment_Sectors frm = new frmManteniment_Sectors();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmManteniment_Users frm = new frmManteniment_Users();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmManteniment_Regions frm = new frmManteniment_Regions();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmManteniment_UserCategories frm = new frmManteniment_UserCategories();
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmManteniment_SpaceShipCategories frm = new frmManteniment_SpaceShipCategories();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmManteniment_SpaceShipTypes frm = new frmManteniment_SpaceShipTypes();
            frm.ShowDialog();
        }

    }
}
