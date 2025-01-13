using FormBaseBBDD;
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
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace FormUsers
{
    public partial class frmManteniment_Users : frmBaseBBDD
    {
        private ReportDocument cryRpt;
        public frmManteniment_Users()
        {
            InitializeComponent();

            string tabla = "Users";

            Data data = new Data()
            {
                autoLabel = true,
                taule = tabla,
                querySelect = @"
                    select idUser,u.idUserRank,u.idUserCategory,u.idPlanet,u.idSpecie,
                    CodeUser,UserName,Login,Photo,Mail,r.DescRank,c.DescCategory,p.DescPlanet,s.DescSpecie
                    from Users as u left join UserRanks as r on u.idUserRank=r.idUserRank left join UserCategories as c on u.idUserCategory=c.idUserCategory
                    left join Planets as p on u.idPlanet=p.idPlanet left join Species as s on u.idSpecie=s.idSpecie
                ",
                queryUpdate = @"select idUser,idUserRank,idUserCategory,idPlanet,idSpecie,CodeUser,UserName,Login,Photo,Mail from Users",
                id = "idUser",
                titol = $"Mantenimiento tabla '{tabla}'"
            };

            SetData = data;

            SetCaselles = new List<casella>() {
                new casella() { visible = false },
                new casella() { visible = false },
                new casella() { visible = false },
                new casella() { visible = false },
                new casella() { visible = false },
                new casella() { ample = 100, visible = true, alineacio=CasellaAlineacio.Centrat },
                new casella() { ample = 100, visible = true },
                new casella() { ample = 100, visible = true },
            };

            SetLlistes = new List<llista>()
            {
                new llista() { id="idUserRank", query="select idUserRank,CodeRank,DescRank from UserRanks order by DescRank"},
                new llista() { id="idUserCategory", query="select idUserCategory,CodeCategory,DescCategory,AccessLevel from UserCategories order by DescCategory"},
                new llista() { id="idPlanet", query="select idPlanet,CodePlanet,DescPlanet from Planets order by DescPlanet"},
                new llista() { id="idSpecie", query="select idSpecie,CodeSpecie,DescSpecie from Species order by DescSpecie"},
            };
        }

        private void frmManteniment_Users_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            swCodi1.ViewDataColumns = new List<int> { 2, 1 };
            swCodi2.ViewDataColumns = new List<int> { 2, 1, 3 };
            swCodi3.ViewDataColumns = new List<int> { 2, 1 };
            swCodi4.ViewDataColumns = new List<int> { 2, 1 };

            InicializarFormulario(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cryRpt = new ReportDocument();
            cryRpt.Load("tarjaIdentificacio.rpt");

            SetCredentials();

            cryRpt.RecordSelectionFormula = "{Users.idUser} = " +
            Convert.ToInt32(textBox5.Text);

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }

        private void SetCredentials()
        {

            SqlConnectionStringBuilder builder = clsModeloDatos.GetConnectionStringBuilder();

            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = builder.DataSource;
            crConnectionInfo.DatabaseName = builder.InitialCatalog;
            crConnectionInfo.UserID = builder.UserID;
            crConnectionInfo.Password = builder.Password;

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            Tables CrTables = cryRpt.Database.Tables;

            foreach (Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
        }
    }
}
