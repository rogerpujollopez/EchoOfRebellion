using Configuracio;
using FormBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;
using Utils;

namespace FormConfiguracio
{
    public partial class frmConfiguracio : frmBase
    {
        public frmConfiguracio()
        {
            InitializeComponent();
            SetLogActivarTimer = true;
        }

        private void frmConfiguracio_Load(object sender, EventArgs e)
        {
            txtUrl.Text = UsuariActiu.ftpserver;
            txtUsu.Text = UsuariActiu.ftpuser;
            txtPass.Text= UsuariActiu.ftppass;
            txtlocal.Text = UsuariActiu.ftplocalpath;
            txtremote.Text = UsuariActiu.ftpremotepath;

            txtmailserver.Text = UsuariActiu.mailserver;
            txtmailuser.Text = UsuariActiu.mailuser;
            txtmailpass.Text = UsuariActiu.mailpass;

            txtsqlserver.Text = UsuariActiu.sqlserver;
            txtsqlbbdd.Text = UsuariActiu.sqlbbdd;
            txtsqluser.Text = UsuariActiu.sqluser;
            txtsqlpass.Text = UsuariActiu.sqlpass;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuariActiu.ftpserver = txtUrl.Text;
            UsuariActiu.ftpuser = txtUsu.Text;
            UsuariActiu.ftppass = txtPass.Text;
            UsuariActiu.ftplocalpath = txtlocal.Text;
            UsuariActiu.ftpremotepath = txtremote.Text;

            Config.GuardarCarregarConfigXmlFtp();

            SetLogColor = Color.LightGreen;
            SetLog = "Dades del ftp guardades correctament";
        }

        private void btnGuardarMail_Click(object sender, EventArgs e)
        {
            UsuariActiu.mailserver = txtmailserver.Text;
            UsuariActiu.mailuser = txtmailuser.Text;
            UsuariActiu.mailpass = txtmailpass.Text;

            Config.GuardarCarregarConfigXmlMail();

            SetLogColor = Color.LightGreen;
            SetLog = "Dades del mail guardades correctament";
        }

        private void btnGuardarSql_Click(object sender, EventArgs e)
        {
            UsuariActiu.sqlserver = txtsqlserver.Text;
            UsuariActiu.sqlbbdd = txtsqlbbdd.Text;
            UsuariActiu.sqluser = txtsqluser.Text;
            UsuariActiu.sqlpass = txtsqlpass.Text;

            Config.GuardarCarregarConfigXmlSql();

            SetLogColor = Color.LightGreen;
            SetLog = "Dades del sql guardades correctament";
        }

        private void btnlocal_Click(object sender, EventArgs e)
        {
            string path = txtlocal.Text=="" ? Funcions.ObtindreCarpetaPrograma() : txtlocal.Text;

            string carpetaSeleccionada = Funcions.SeleccionarCarpeta(path);
            if (!string.IsNullOrEmpty(carpetaSeleccionada))
            {
                txtlocal.Text = carpetaSeleccionada;
            }
        }

        private void btnremote_Click(object sender, EventArgs e)
        {
            string carpetaSeleccionada = Funcions.SeleccionarCarpeta(txtlocal.Text);
            if (!string.IsNullOrEmpty(carpetaSeleccionada))
            {
                txtlocal.Text = carpetaSeleccionada;
            }
        }
    }
}
