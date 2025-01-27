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
using Utils;
using System.IO;
using System.Xml.Schema;
using UsuariActiuNameSpace;

namespace FormUsers
{
    public partial class frmManteniment_Users : frmBaseBBDD
    {
        private ReportDocument cryRpt;
        public frmManteniment_Users()
        {
            InitializeComponent();

            this.NuevoRegistroCreado += FrmHijo_NuevoRegistroCreado;
            this.DatosActualizados += FrmHerencia_DatosActualizados;

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

            campsNoVuits = new List<string>()
            {
                "CodeUser","UserName","Login","Mail"
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

            pictureBox1.Click += PictureBox_Click;
            swTextbox4.ValidacioFallida += ValidacioFallidaMail;
        }

        private void ValidacioFallidaMail(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Red;
            SetLogColor = Color.Red;
            SetLogActivarTimer = true;
            SetLog = "Correu electrònic no vàlid.";
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            string ruta = Funcions.RutaImagen("Seleccionar Imatge");

            if (ruta != "")
            {
                byte[] imagenBytes = File.ReadAllBytes(ruta);
                ActualizarImagen(imagenBytes);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string valor = textBox5.Text;

            if (valor == "")
            {
                return;
            }

            Enabled = false;

            try
            {
                cryRpt = new ReportDocument();
                cryRpt.Load("tarjaIdentificacio.rpt");

                SetCredentials();

                string formula = "{Users.idUser} = ";
                formula += $"{valor}";

                cryRpt.RecordSelectionFormula = formula;

                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();

                panel1.Visible = true;
            }
            catch (Exception ex)
            {
                SetLogColor = Color.Red;
                SetLogActivarTimer = true;
                SetLog = ex.Message;
            }
            finally
            {
                Enabled = true;
            }

        }

        public override void ClickEnGrid(DataGridViewCellEventArgs e)
        {
            base.ClickEnGrid(e);
            panel1.Visible = false;
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

        private void FrmHijo_NuevoRegistroCreado(object sender, NuevoRegistroEventArgs e)
        {
            string g = "";
        }

        private void FrmHerencia_DatosActualizados(object sender, EventArgs e)
        {
            clsModeloDatos dm = new clsModeloDatos();

            string query = @"
                    select UserName,Photo
                    from Users as u left join UserRanks as r on u.idUserRank=r.idUserRank
                    left join UserCategories as c on u.idUserCategory=c.idUserCategory
                    left join Species as s on u.idSpecie=s.idSpecie
                    left join Planets as p on u.idPlanet=p.idPlanet
                    where idUser=@idUser
                ";

            int idUser = UsuariActiu.usuari.IdUser;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idUser", idUser));

            DataSet ds = dm.PortarPerConsulta(query, parametros);
            DataRow row = ds.Tables[0].Rows[0];

            UsuariActiu.usuari.UserName = (string)row["UserName"];
            UsuariActiu.usuari.Photo = (byte[])row["Photo"];
            UsuariActiu.ActualizarInformacion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string valor = textBox5.Text;

            if (valor == "")
            {
                return;
            }

            Enabled = false;

            int _idUser = Convert.ToInt32(valor);

            Form frm = new frmImprimir(_idUser);
            frm.ShowDialog();

            Enabled = true;
        }
    }
}
