using BiblioModeloDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariActiuNameSpace;
using System.Security.Cryptography;
using static BiblioModeloDatos.DM.DMModel;
using EchoOfRebellion.Clases.Utils;

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
                coalesce(Photo,'') as UncPhoto,CodePlanet,
                sec.CodeSector,sec.DescSector,coalesce(sec.Remarks,'') as RemarksSector,reg.CodeRegion,reg.DescRegion,coalesce(reg.Remarks,'') as RemarksRegion,long,lat,parsecs,
                fil.CodeFiliation,fil.DescFiliations,PlanetPicture as UrlPlanetPicture,IPPlanet,PortPlanet,PortPlanet1,coalesce(Mail,'') as Mail,Password,PasswordTmp
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
                bool siPassEmpty = r.IsNull("Password");
                bool siPassTmpEmpty = r.IsNull("PasswordTmp");

                if (siSalt && !siPassEmpty && siPassTmpEmpty)
                {
                    // Revisar password
                    string bbddPassword = r["Password"].ToString();


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
                        UrlPlanetPicture = r.IsNull("UrlPlanetPicture") ? "" : r["UrlPlanetPicture"].ToString(),
                        IPPlanet = r.IsNull("IPPlanet") ? "" : r["IPPlanet"].ToString(),
                        PortPlanet = r.IsNull("PortPlanet") ? 0 : (int)r["PortPlanet"],
                        PortPlanet1 = r.IsNull("PortPlanet1") ? 0 : (int)r["PortPlanet1"],
                        Mail = r["Mail"].ToString(),
                    };
                    result = 1;
                }
                else
                {
                    if (siPassTmpEmpty)
                    {
                        return 0;
                    }

                    string bbddPassword = r["PasswordTmp"].ToString();

                    if (bbddPassword != password)
                    {
                        return 0;
                    }

                    result = 2;
                }
            }

            return result;

            // 0 KO
            // 1 OK
            // 2 OK, pero no tiene Salt
        }

        public static bool UsuarioExiste(string usuario)
        {
            string consulta;
            clsModeloDatos m = new clsModeloDatos();

            consulta = "SELECT COUNT(*) FROM Users WHERE Login = @usuario";
            var parametros = new Dictionary<string, object> { { "@usuario", usuario } };
            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            return ds.Tables[0].Rows[0][0].ToString() != "0";
        }
        public static bool ActualizarPasswordConHash(string usuario, string salt, string passwordHasheado, string mail)
        {

            string consulta = "update Users set Password=@password,Salt=@salt,Mail=@mail,PasswordTmp=null where Login = @usuario";

            var parametros = new Dictionary<string, object>
            {
                { "@password", passwordHasheado },
                { "@salt", salt },
                { "@usuario", usuario },
                { "@usuario", mail },
            };

            clsModeloDatos m = new clsModeloDatos();
            int registrosAfectados = m.ExecutaConParametros(consulta, parametros);

            return registrosAfectados > 0;
        }

    }
}
