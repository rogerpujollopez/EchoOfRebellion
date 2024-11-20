using BiblioModeloDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariActiuNameSpace;
using static BiblioModeloDatos.DM.DMModel;

namespace EchoOfRebellion.Clases.DM
{
    internal class DMLogin
    {
        public static int DmLogin(string usuari, string password)
        {
            string consulta;

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@Usuari", usuari },
                { "@Password", password },
            };

            consulta = @"
                select idUser,case when Salt is null then cast(0 as bit) else CAST(1 as bit) end as SiSalt,CodeUser,UserName,u.idUserRank,r.CodeRank,r.DescRank,c.AccessLevel,c.CodeCategory,c.DescCategory,
                Photo as UncPhoto,CodePlanet,
                sec.CodeSector,sec.DescSector,sec.Remarks as RemarksSector,reg.CodeRegion,reg.DescRegion,reg.Remarks as RemarksRegion,long,lat,parsecs,
                fil.CodeFiliation,fil.DescFiliations,PlanetPicture as UrlPlanetPicture,IPPlanet,PortPlanet,PortPlanet1,coalesce(Mail,'') as Mail
                from Users as u left join UserRanks as r on u.idUserRank=r.idUserRank
                left join UserCategories as c on u.idUserCategory=c.idUserCategory
                left join Planets as p on u.idPlanet=p.idPlanet left join Sectors as sec on p.idSector=sec.idSector left join Regions as reg on sec.idRegion=reg.idRegion
                left join Filiations as fil on p.idFiliation=fil.idFiliation
                where u.Login=@Usuari
            ";
            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            //UsuariComplet u = null;
            UsuariActiu.usuari = null;

            int result = 0;

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow r = ds.Tables[0].Rows[0];
                bool siSalt = (bool)r["SiSalt"];

                if (siSalt)
                {
                    UsuariActiu.usuari = new UsuariComplet()
                    {
                        IdUser = (int)r["idUser"],
                        SiSalt = (bool)r["SiSalt"],
                        CodeUser = r["CodeUser"].ToString(),
                        UserName = r["UserName"].ToString(),
                        IdUserRank = (int)r["idUserRank"],
                        CodeRank = r["CodeRank"].ToString(),
                        DescRank = r["DescRank"].ToString(),
                        AccessLevel = (int)r["AccessLevel"],
                        CodeCategory = r["CodeCategory"].ToString(),
                        DescCategory = r["DescCategory"].ToString(),
                        UncPhoto = r["UncPhoto"].ToString(),
                        CodePlanet = r["CodePlanet"].ToString(),
                        CodeSector = r["CodeSector"].ToString(),
                        DescSector = r["DescSector"].ToString(),
                        RemarksSector = r.IsNull("RemarksSector") ? "" : r["RemarksSector"].ToString(),
                        CodeRegion = r["CodeRegion"].ToString(),
                        DescRegion = r["DescRegion"].ToString(),
                        RemarksRegion = r.IsNull("RemarksRegion") ? "" : r["RemarksRegion"].ToString(),
                        Longitude = Convert.ToInt32(r["long"]),
                        Latitude = Convert.ToInt32(r["lat"]),
                        Parsecs = Convert.ToInt32(r["parsecs"]),
                        CodeFiliation = r["CodeFiliation"].ToString(),
                        DescFiliations = r["DescFiliations"].ToString(),
                        UrlPlanetPicture = r["UrlPlanetPicture"].ToString(),
                        IPPlanet = r["IPPlanet"].ToString(),
                        PortPlanet = Convert.ToInt32(r["PortPlanet"]),
                        PortPlanet1 = Convert.ToInt32(r["PortPlanet1"]),
                        Mail = r["Mail"].ToString(),
                    };
                    result = 1;
                }
                else
                {
                    result = 2; 
                }
            }


            // Revisar Regex usuario

            // Revisar regex pass

            // Si todo ok, enviamos a la bbdd

            return result;

            // 0 KO
            // 1 OK
            // 2 OK, pero no tiene Salt
        }

    }
}
