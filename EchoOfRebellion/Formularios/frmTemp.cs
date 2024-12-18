using FormRegions;
using FormSectors;
using FormUsers;
using FormSpaceShip;
using FormPlanetes;
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
using BiblioModeloDatos;
using CrystalDecisions.CrystalReports.Engine;
using EchoOfRebellion.Reports;

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

        private void button8_Click(object sender, EventArgs e)
        {
            frmManteniment_UserRangs frm = new frmManteniment_UserRangs();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmSelector_Sectors frm = new frmSelector_Sectors();
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmManteniment_Planetes frm = new frmManteniment_Planetes();
            frm.ShowDialog();
        }

        private void buttonRoger_Click(object sender, EventArgs e)
        {
            string query = @"
                select UserName,c.DescCategory,r.DescRank,s.DescSpecie,p.DescPlanet,CodeUser,Photo
                from Users as u left join UserRanks as r on u.idUserRank=r.idUserRank
                left join UserCategories as c on u.idUserCategory=c.idUserCategory
                left join Species as s on u.idSpecie=s.idSpecie
                left join Planets as p on u.idPlanet=p.idPlanet
                where idUser=1
            ";

            clsModeloDatos dm = new clsModeloDatos();
            DataSet ds = dm.PortarPerConsulta(query);

            //ds.WriteXmlSchema(@"C:\dataset.xsd");

            ReportDocument cryRpt = new RptUsuario();
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            cryRpt.PrintToPrinter(1, false, 0, 0);


            string g = "";

        }
    }
}
