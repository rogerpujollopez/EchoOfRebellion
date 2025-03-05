using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariActiuNameSpace
{
    public static class UsuariActiu
    {
        public static UsuariComplet usuari;

        public class UsuariComplet
        {
            public int IdUser { get; set; }
            public bool SiSalt { get; set; }
            public string Mail { get; set; }
            public string CodeUser { get; set; }
            public string UserName { get; set; }
            public int IdUserRank { get; set; }
            public string CodeRank { get; set; }
            public string DescRank { get; set; }
            public int AccessLevel { get; set; }
            public string CodeCategory { get; set; }
            public string DescCategory { get; set; }
            public string UncPhoto { get; set; }
            public string CodePlanet { get; set; }
            public string CodeSector { get; set; }
            public string DescSector { get; set; }
            public string RemarksSector { get; set; }
            public string CodeRegion { get; set; }
            public string DescRegion { get; set; }
            public string RemarksRegion { get; set; }
            public double Longitude { get; set; } // 'long' es palabra reservada en C#
            public double Latitude { get; set; }
            public double Parsecs { get; set; }
            public string CodeFiliation { get; set; }
            public string DescFiliations { get; set; }
            public string UrlPlanetPicture { get; set; }
            public string IPPlanet { get; set; }
            public int PortPlanet { get; set; }
            public int PortPlanet1 { get; set; }
            public byte[] Photo { get; set; }

            public List<Permis> Permisos { get; set; }
        }

        public class Permis
        {
            public int ID_Op { get; set; }
            public string Dll { get; set; }
            public string Tipus { get; set; }
            public string Nom { get; set; }
            public byte[] Icona { get; set; }
            public string Desc { get; set; }
        }


        public static event EventHandler InformacionActualizada;

        public static void ActualizarInformacion()
        {
            InformacionActualizada?.Invoke(null, EventArgs.Empty);
        }

        public static string ftpserver { get; set; }
        public static string ftpuser { get; set; }
        public static string ftppass { get; set; }
        public static string ftplocalpath { get; set; }
        public static string ftpremotepath { get; set; }
        public static string ftpprocessedpath { get; set; }

        public static string mailserver { get; set; }
        public static string mailuser { get; set; }
        public static string mailpass { get; set; }

        public static string sqlserver { get; set; }
        public static string sqlbbdd { get; set; }
        public static string sqluser { get; set; }
        public static string sqlpass { get; set; }

    }

}
