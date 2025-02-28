using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UsuariActiuNameSpace;
using Utils;

namespace EchoOfRebellion.Clases
{
    public static class RevisionsInicials
    {
        private const string fitxerconfiguracio = "config.xml";

        public static void RevisionsAFer()
        {
            // existeix el fitxer de configuració?
            RevisarFitxerXmlConfiguracio();
            
        }


        private static void RevisarFitxerXmlConfiguracio() 
        {
            XmlDocument doc = new XmlDocument();

            string ruta = Funcions.ObtindreCarpetaPrograma(fitxerconfiguracio);

            bool guardarcambios = false;

            if (File.Exists(ruta))
            {
                doc.Load(ruta);
                string originalXml = doc.InnerXml;
                RevisarNodeFtp(doc);
                guardarcambios = doc.InnerXml != originalXml;
            }
            else
            {
                CrearXmlConfiguracio(ruta, doc);
                guardarcambios = true;
            }

            if (guardarcambios)
            {
                doc.Save(ruta);
            }

            CarregarConfigXml(doc);
        }

        private static void CarregarConfigXml(XmlDocument doc)
        {
            CarregarConfigXmlFtp(doc);
        }

        private static void CarregarConfigXmlFtp(XmlDocument doc)
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



        private static void RevisarNodeFtp(XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;

            bool errornodo = true;
            //string server, user, pass, ftplocalpath, ftpremotepath;

            do
            {
                XmlNode nodoFtp = root["ftp"];
                if (nodoFtp == null)
                {
                    break;
                }
                XmlNode nodoFtpServer = nodoFtp["ftpserver"];
                if (nodoFtp == null)
                {
                    break;
                }
                //server = nodoFtpServer.InnerText;
                XmlNode nodoFtpUser = nodoFtp["ftpuser"];
                if (nodoFtpUser == null)
                {
                    break;
                }
                //user = nodoFtpUser.InnerText;
                XmlNode nodoFtpPass = nodoFtp["ftppass"];
                if (nodoFtpPass == null)
                {
                    break;
                }
                //pass = nodoFtpPass.InnerText;

                XmlNode nodoFtplocalpath = nodoFtp["ftplocalpath"];
                if (nodoFtplocalpath == null)
                {
                    break;
                }
                //ftplocalpath = nodoFtplocalpath.InnerText;

                XmlNode nodoFtpremotepath = nodoFtp["ftpremotepath"];
                if (nodoFtpremotepath == null)
                {
                    break;
                }
                //ftpremotepath = nodoFtpremotepath.InnerText;

            }
            while (false);

            if (errornodo)
            {
                XmlNode nodoFtp = root["ftp"];
                if (nodoFtp != null)
                {
                    root.RemoveChild(nodoFtp);
                }
                CrearXmlFtp(doc);
            }
        }


        private static void CrearXmlConfiguracio(string ruta, XmlDocument doc)
        {
            XmlNode root = doc.CreateElement("root");
            doc.AppendChild(root);

            CrearXmlFtp(doc);
        }

        private static void CrearXmlFtp(XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;

            XmlNode ftp = doc.CreateElement("ftp");
            root.AppendChild(ftp);
            XmlNode ftpserver = doc.CreateElement("ftpserver");
            ftpserver.InnerText = "ftp://sqlserver.S2AM.sdslab.cat";
            ftp.AppendChild(ftpserver);
            XmlNode ftpuser = doc.CreateElement("ftpuser");
            ftpuser.InnerText = "g01";
            ftp.AppendChild(ftpuser);
            XmlNode ftppass = doc.CreateElement("ftppass");
            ftppass.InnerText = "12345aA";
            ftp.AppendChild(ftppass);
            XmlNode ftplocalpath = doc.CreateElement("ftplocalpath");
            ftplocalpath.InnerText = "";
            ftp.AppendChild(ftplocalpath);
            XmlNode ftpremotepath = doc.CreateElement("ftpremotepath");
            ftpremotepath.InnerText = "";
            ftp.AppendChild(ftpremotepath);
        }


    }
}
