using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblioModeloDatos;
using CrystalDecisions.CrystalReports.Engine;
using EchoOfRebellion.Reports;
using Utils;
using System.Reflection;
using System.IO;
using EDILibrary;

namespace EchoOfRebellion.Formularios
{
    public partial class frmTemp : Form
    {
        public frmTemp()
        {
            InitializeComponent();
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
            //configxml.RevisionsAFer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ruta = @"C:\Users\Administrador\Desktop\DAM\S2AM\ABP\17 - Gestió de comandes\RAREDI_1.edi";

            string[] lines = File.ReadAllLines(ruta);

            int idOrder = Edi.EDItoOrder(lines);


            MessageBox.Show($"Pedido {idOrder} ok");
        }

        private void btnFactories_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
