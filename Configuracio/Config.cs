using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using UsuariActiuNameSpace;
using Utils;

namespace Configuracio
{
    public static class Config
    {
        public static class Colores
        {
            private static Color colorFondoBoton = Color.FromArgb(29, 17, 67);
            private static Color colorPerfilInteriorBoton = Color.FromArgb(85, 84, 128);
            private static Color colorPerfilExteriorBoton = Color.FromArgb(126, 157, 201);

            public static class Formularios
            {
                public static Color BackColor
                {
                    get
                    {
                        return Color.Black;
                    }
                }
            }

            public static class Cabecera
            {
                public static Color BackColor
                {
                    get
                    {
                        return colorPerfilInteriorBoton;
                    }
                }
                public static Color ForeColor
                {
                    get
                    {
                        return Color.White;
                    }
                }
            }

            public static class Botones
            {
                public static Brush FontColor
                {
                    get
                    {
                        return Brushes.White;
                    }
                }

                public static Color BackColor
                {
                    get
                    {
                        return colorFondoBoton;
                    }
                }

                public static Color ColorLineaInterior
                {
                    get
                    {
                        return colorPerfilInteriorBoton;
                    }
                }

                public static Color ColorLineaExterior
                {
                    get
                    {
                        return colorPerfilExteriorBoton;
                    }
                }
            }

        }

        private const string fitxerconfiguracio = "config.xml";
        private static XmlDocument doc;
        private static string _path;

        public static void RevisionsAFer()
        {
            // existeix el fitxer de configuració?
            RevisarFitxerXmlConfiguracio();

        }

        private static void RevisarFitxerXmlConfiguracio()
        {
            doc = new XmlDocument();

            _path = Funcions.ObtindreCarpetaPrograma(fitxerconfiguracio);

            bool guardarcambios = false;

            if (File.Exists(_path))
            {
                doc.Load(_path);
                string originalXml = doc.InnerXml;
                ReisarXml();
                guardarcambios = doc.InnerXml != originalXml;
            }
            else
            {
                CrearXmlConfiguracio(_path);
                guardarcambios = true;
            }

            if (guardarcambios)
            {
                GuardarConfiguracio();
            }

            CarregarConfigXml();
        }

        private static void GuardarConfiguracio()
        {
            doc.Save(_path);
        }

        #region "Xml"

        private static void ReisarXml()
        {
            RevisarNodeFtp();
            RevisarNodeMail();
            RevisarNodeSql();
        }

        private static void CarregarConfigXml()
        {
            CarregarConfigXmlFtp();
            CarregarConfigXmlMail();
            CarregarConfigXmlSql();
        }

        private static void CrearXmlConfiguracio(string ruta)
        {
            XmlNode root = doc.CreateElement("root");
            doc.AppendChild(root);

            CrearXmlFtp();
            CrearXmlMail();
            CrearXmlSql();
        }

        #endregion

        #region "Ftp"

        private static void CarregarConfigXmlFtp()
        {
            XmlElement root = doc.DocumentElement;
            XmlNode nodoFtp = root["ftp"];

            XmlNode nodoFtpServer = nodoFtp["ftpserver"];
            UsuariActiu.ftpserver = nodoFtpServer.InnerText;

            XmlNode nodoFtpUser = nodoFtp["ftpuser"];
            UsuariActiu.ftpuser = nodoFtpUser.InnerText;

            XmlNode nodoFtpPass = nodoFtp["ftppass"];
            UsuariActiu.ftppass = nodoFtpPass.InnerText;

            XmlNode nodoFtpLocalPath = nodoFtp["ftplocalpath"];
            UsuariActiu.ftplocalpath = nodoFtpLocalPath.InnerText;

            XmlNode nodoFtpRemotePath = nodoFtp["ftpremotepath"];
            UsuariActiu.ftpremotepath = nodoFtpRemotePath.InnerText;
        }

        public static void GuardarCarregarConfigXmlFtp()
        {
            XmlElement root = doc.DocumentElement;
            XmlNode nodoFtp = root["ftp"];

            XmlNode nodoFtpServer = nodoFtp["ftpserver"];
            nodoFtpServer.InnerText = UsuariActiu.ftpserver;

            XmlNode nodoFtpUser = nodoFtp["ftpuser"];
            nodoFtpUser.InnerText = UsuariActiu.ftpuser;

            XmlNode nodoFtpPass = nodoFtp["ftppass"];
            nodoFtpPass.InnerText = UsuariActiu.ftppass;

            XmlNode nodoFtpLocalPath = nodoFtp["ftplocalpath"];
            nodoFtpLocalPath.InnerText = UsuariActiu.ftplocalpath;

            XmlNode nodoFtpRemotePath = nodoFtp["ftpremotepath"];
            nodoFtpRemotePath.InnerText = UsuariActiu.ftpremotepath;

            GuardarConfiguracio();
        }

        private static void RevisarNodeFtp()
        {
            XmlElement root = doc.DocumentElement;

            bool errornodo;

            XmlNode nodo = root["ftp"];
            if (nodo == null)
            {
                errornodo = true;
            }
            else
            {
                XmlNode nodoFtpServer = nodo["ftpserver"];
                XmlNode nodoFtpUser = nodo["ftpuser"];
                XmlNode nodoFtpPass = nodo["ftppass"];
                XmlNode nodoFtplocalpath = nodo["ftplocalpath"];
                XmlNode nodoFtpremotepath = nodo["ftpremotepath"];

                errornodo = (nodoFtpServer == null || nodoFtpUser == null || nodoFtpPass == null || nodoFtplocalpath == null || nodoFtpremotepath == null);
            }

            if (errornodo)
            {
                if (nodo != null)
                {
                    root.RemoveChild(nodo);
                }
                CrearXmlFtp();
            }
        }

        private static void CrearXmlFtp()
        {
            XmlElement root = doc.DocumentElement;

            XmlNode ftp = doc.CreateElement("ftp");
            root.AppendChild(ftp);
            XmlNode ftpserver = doc.CreateElement("ftpserver");
            ftpserver.InnerText = "";
            ftp.AppendChild(ftpserver);
            XmlNode ftpuser = doc.CreateElement("ftpuser");
            ftpuser.InnerText = "";
            ftp.AppendChild(ftpuser);
            XmlNode ftppass = doc.CreateElement("ftppass");
            ftppass.InnerText = "";
            ftp.AppendChild(ftppass);
            XmlNode ftplocalpath = doc.CreateElement("ftplocalpath");
            ftplocalpath.InnerText = "";
            ftp.AppendChild(ftplocalpath);
            XmlNode ftpremotepath = doc.CreateElement("ftpremotepath");
            ftpremotepath.InnerText = "";
            ftp.AppendChild(ftpremotepath);
        }

        #endregion

        #region "Mail"

        private static void CarregarConfigXmlMail()
        {
            XmlElement root = doc.DocumentElement;
            XmlNode nodoMail = root["mail"];

            XmlNode nodoMailServer = nodoMail["mailserver"];
            UsuariActiu.mailserver = nodoMailServer.InnerText;

            XmlNode nodoMailUser = nodoMail["mailuser"];
            UsuariActiu.mailuser = nodoMailUser.InnerText;

            XmlNode nodoMailPass = nodoMail["mailpass"];
            UsuariActiu.mailpass = nodoMailPass.InnerText;
        }

        public static void GuardarCarregarConfigXmlMail()
        {
            XmlElement root = doc.DocumentElement;
            XmlNode nodoMail = root["mail"];

            XmlNode nodoMailServer = nodoMail["mailserver"];
            nodoMailServer.InnerText = UsuariActiu.mailserver;

            XmlNode nodoMailUser = nodoMail["mailuser"];
            nodoMailUser.InnerText = UsuariActiu.mailuser;

            XmlNode nodoMailPass = nodoMail["mailpass"];
            nodoMailPass.InnerText = UsuariActiu.mailpass;

            GuardarConfiguracio();
        }

        private static void RevisarNodeMail()
        {
            XmlElement root = doc.DocumentElement;

            bool errornodo;

            XmlNode nodo = root["mail"];
            if (nodo == null)
            {
                errornodo = true;
            }
            else
            {
                XmlNode mailServer = nodo["mailserver"];
                XmlNode mailUser = nodo["mailuser"];
                XmlNode mailPass = nodo["mailpass"];

                errornodo = (mailServer == null || mailUser == null || mailPass == null);
            }

            if (errornodo)
            {
                if (nodo != null)
                {
                    root.RemoveChild(nodo);
                }
                CrearXmlMail();
            }
        }

        private static void CrearXmlMail()
        {
            XmlElement root = doc.DocumentElement;

            XmlNode nodo = doc.CreateElement("mail");
            root.AppendChild(nodo);
            XmlNode mailserver = doc.CreateElement("mailserver");
            mailserver.InnerText = "";
            nodo.AppendChild(mailserver);
            XmlNode mailuser = doc.CreateElement("mailuser");
            mailuser.InnerText = "";
            nodo.AppendChild(mailuser);
            XmlNode mailpass = doc.CreateElement("mailpass");
            mailpass.InnerText = "";
            nodo.AppendChild(mailpass);
        }

        #endregion

        #region "Sql"

        private static void CarregarConfigXmlSql()
        {
            XmlElement root = doc.DocumentElement;
            XmlNode nodoSql = root["sql"];

            XmlNode nodoSqlServer = nodoSql["sqlserver"];
            UsuariActiu.sqlserver = nodoSqlServer.InnerText;

            XmlNode nodoBbddPass = nodoSql["sqlbbdd"];
            UsuariActiu.sqlbbdd = nodoBbddPass.InnerText;

            XmlNode nodoSqlUser = nodoSql["sqluser"];
            UsuariActiu.sqluser = nodoSqlUser.InnerText;

            XmlNode nodoSqlPass = nodoSql["sqlpass"];
            UsuariActiu.sqlpass = nodoSqlPass.InnerText;
        }

        public static void GuardarCarregarConfigXmlSql()
        {
            XmlElement root = doc.DocumentElement;
            XmlNode nodoSql = root["sql"];

            XmlNode nodoSqlServer = nodoSql["sqlserver"];
            nodoSqlServer.InnerText = UsuariActiu.sqlserver;

            XmlNode nodoSqlBbdd = nodoSql["sqlbbdd"];
            nodoSqlBbdd.InnerText = UsuariActiu.sqlbbdd;

            XmlNode nodoSqlUser = nodoSql["sqluser"];
            nodoSqlUser.InnerText = UsuariActiu.sqluser;

            XmlNode nodoSqlPass = nodoSql["sqlpass"];
            nodoSqlPass.InnerText = UsuariActiu.sqlpass;

            GuardarConfiguracio();
        }

        private static void RevisarNodeSql()
        {
            XmlElement root = doc.DocumentElement;
            bool errornodo;

            XmlNode nodo = root["sql"];
            if (nodo == null)
            {
                errornodo = true;
            }
            else
            {
                XmlNode sqlServer = nodo["sqlserver"];
                XmlNode sqlBbdd = nodo["sqlbbdd"];
                XmlNode sqlUser = nodo["sqluser"];
                XmlNode sqlPass = nodo["sqlpass"];

                errornodo = (sqlServer == null || sqlBbdd == null || sqlUser == null || sqlPass == null);
            }

            if (errornodo)
            {
                if (nodo != null)
                {
                    root.RemoveChild(nodo);
                }
                CrearXmlSql();
            }
        }

        private static void CrearXmlSql()
        {
            XmlElement root = doc.DocumentElement;

            XmlNode nodo = doc.CreateElement("sql");
            root.AppendChild(nodo);

            XmlNode sqlServer = doc.CreateElement("sqlserver");
            sqlServer.InnerText = "";
            nodo.AppendChild(sqlServer);

            XmlNode sqlBbdd = doc.CreateElement("sqlbbdd");
            sqlBbdd.InnerText = "";
            nodo.AppendChild(sqlBbdd);

            XmlNode sqlUser = doc.CreateElement("sqluser");
            sqlUser.InnerText = "";
            nodo.AppendChild(sqlUser);

            XmlNode sqlPass = doc.CreateElement("sqlpass");
            sqlPass.InnerText = "";
            nodo.AppendChild(sqlPass);
        }

        #endregion


    }
}
