using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioModeloDatos.DM
{
    public class DMModel
    {
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
        }

    }
}
