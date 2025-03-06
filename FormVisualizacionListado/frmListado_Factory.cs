using BiblioModeloDatos;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using FormBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormVisualizacionListado
{
    public partial class frmListado_Factory : frmBase
    {
        private ReportDocument cryRpt;
        private short idOrder;
        public short IdOrder
        {
            get { return idOrder;  }
            set { idOrder = value; }
        }
        public frmListado_Factory()
        {
            InitializeComponent();
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
        private void GenerarCystalReport()
        {
            cryRpt = new ReportDocument();
            cryRpt.Load("ListadoFactories.rpt");

            SetCredentials();

            cryRpt.RecordSelectionFormula = "{Orders.idOrder} = " + Convert.ToInt32(idOrder);

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
        private void frmListado_Factory_Load(object sender, EventArgs e)
        {
            GenerarCystalReport();
        }
    }
}
