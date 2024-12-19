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
using Utils;
using System.Reflection;
using static EchoOfRebellion.Clases.Utils.Reflexio;
using EchoOfRebellion.Clases.Utils;

namespace EchoOfRebellion.Formularios
{
    public partial class frmTemp : Form
    {
        public frmTemp()
        {
            InitializeComponent();
        }

        //Reflexio rf;

        private void btnSectors_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormSectors.dll", "FormSectors.frmManteniment_Sectors"); 
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormUsers.dll", "FormUsers.frmManteniment_Users");
            frm.ShowDialog();
        }

        private void btnRegions_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormRegions.dll", "FormRegions.frmManteniment_Regions");
            frm.ShowDialog();
        }

        private void btnUsersCat_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormUsers.dll", "FormUsers.frmManteniment_UserCategories");
            frm.ShowDialog();
        }

        private void btnSpaceCat_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormSpaceShip.dll", "FormSpaceShip.frmManteniment_SpaceShipCategories");
            frm.ShowDialog();
        }

        private void btnSpaceTypes_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormSpaceShip.dll", "FormSpaceShip.frmManteniment_SpaceShipTypes");
            frm.ShowDialog();
        }

        private void btnUsersRangs_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormUsers.dll", "FormUsers.frmManteniment_UserRangs");
            frm.ShowDialog();
        }

        private void btnSelSector_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormSectors.dll", "FormSectors.frmSelector_Sectors");
            frm.ShowDialog();
        }

        private void btnPlanets_Click(object sender, EventArgs e)
        {
            Form frm = GetFormulari("FormPlanetes.dll", "FormPlanetes.frmManteniment_Planetes");
            frm.ShowDialog();
        }

        private void buttonRoger_Click(object sender, EventArgs e)
        {
            clsModeloDatos dm = new clsModeloDatos();


            //string file = @"c:\persona.jpg";
            //byte[] arr = file.LoadFileToArrayBytes();

            //Dictionary<string, object> parametros = new Dictionary<string, object>
            //{
            //    { "Photo", arr } 
            //};
            //string strsql = "update Users set Photo=@Photo where idUser=1";

            //dm.ExecutaConParametros(strsql, parametros);




            string query = @"
                select UserName,c.DescCategory,r.DescRank,s.DescSpecie,p.DescPlanet,CodeUser,Photo
                from Users as u left join UserRanks as r on u.idUserRank=r.idUserRank
                left join UserCategories as c on u.idUserCategory=c.idUserCategory
                left join Species as s on u.idSpecie=s.idSpecie
                left join Planets as p on u.idPlanet=p.idPlanet
                where idUser=1
            ";

            DataSet ds = dm.PortarPerConsulta(query);

            //ds.WriteXmlSchema(@"C:\dataset.xsd");

            ReportDocument cryRpt = new RptUsuario();
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            cryRpt.PrintToPrinter(1, false, 0, 0);


            string g = "";

        }

        private void frmTemp_Load(object sender, EventArgs e)
        {
            //rf = new Reflexio(new DataSet());
        }
    }
}
