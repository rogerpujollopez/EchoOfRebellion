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
using Utils;

namespace EchoOfRebellion.Clases.DM
{
    internal class DMLogin
    {
        private static string HashPassword(string salt, string nuevoPassword)
        {
            return (salt + nuevoPassword).Hash256();
        }

        public static int DmLogin(string usuari, string password)
        {
            string consulta;

            usuari = usuari.Trim();
            password = password.Trim();

            if (usuari == "" || password == "")
            {
                return 0;
            }

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@Usuari", usuari },
            };

            consulta = @"
                select idUser,case when Salt is null then cast(0 as bit) else CAST(1 as bit) end as SiSalt,CodeUser,UserName,u.idUserRank,r.CodeRank,r.DescRank,c.AccessLevel,c.CodeCategory,c.DescCategory,
                Photo,CodePlanet,
                sec.CodeSector,sec.DescSector,coalesce(sec.Remarks,'') as RemarksSector,reg.CodeRegion,reg.DescRegion,coalesce(reg.Remarks,'') as RemarksRegion,long,lat,parsecs,
                fil.CodeFiliation,fil.DescFiliations,PlanetPicture as UrlPlanetPicture,IPPlanet,PortPlanet,PortPlanet1,coalesce(Mail,'') as Mail,Password,PasswordTmp,Salt
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

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow r = ds.Tables[0].Rows[0];
                bool siSalt = (bool)r["SiSalt"];
                bool siPassEmpty = r.IsNull("Password");
                bool siPassTmpEmpty = r.IsNull("PasswordTmp");

                if (siSalt && !siPassEmpty && siPassTmpEmpty)
                {
                    // Revisar password
                    string bbddPassword = (string)r["Password"];

                    string salt = (string)r["Salt"];
                    string hashPassword = HashPassword(salt, password);

                    if (bbddPassword != hashPassword)
                    {
                        return 0;
                    }

                    int AccessLevel = r.IsNull("AccessLevel") ? 0 : (int)r["AccessLevel"];

                    List<Permis> permisos = new List<Permis>();

                    UsuariActiu.usuari = new UsuariComplet()
                    {
                        IdUser = (int)r["idUser"],
                        SiSalt = (bool)r["SiSalt"],
                        CodeUser = r["CodeUser"].ToString(),
                        UserName = r["UserName"].ToString(),
                        IdUserRank = r.IsNull("idUserRank") ? 0 : (int)r["idUserRank"],
                        CodeRank = r.IsNull("CodeRank") ? "" : r["CodeRank"].ToString(),
                        DescRank = r.IsNull("DescRank") ? "" : r["DescRank"].ToString(),
                        AccessLevel = AccessLevel,
                        CodeCategory = r.IsNull("CodeCategory") ? "" : r["CodeCategory"].ToString(),
                        DescCategory = r.IsNull("DescCategory") ? "" : r["DescCategory"].ToString(),
                        Photo = r.IsNull("Photo") ? null : (byte[])r["Photo"],
                        CodePlanet = r.IsNull("CodePlanet") ? "" : r["CodePlanet"].ToString(),
                        CodeSector = r.IsNull("CodeSector") ? "" : r["CodeSector"].ToString(),
                        DescSector = r.IsNull("DescSector") ? "" : r["DescSector"].ToString(),
                        RemarksSector = r.IsNull("RemarksSector") ? "" : r["RemarksSector"].ToString(),
                        CodeRegion = r.IsNull("CodeRegion") ? "" : r["CodeRegion"].ToString(),
                        DescRegion = r.IsNull("DescRegion") ? "" : r["DescRegion"].ToString(),
                        RemarksRegion = r.IsNull("RemarksRegion") ? "" : r["RemarksRegion"].ToString(),
                        Longitude = r.IsNull("long") ? 0 : Convert.ToInt32(r["long"]),
                        Latitude = r.IsNull("lat") ? 0 : Convert.ToInt32(r["lat"]),
                        Parsecs = r.IsNull("parsecs") ? 0 : Convert.ToInt32(r["parsecs"]),
                        CodeFiliation = r.IsNull("CodeFiliation") ? "" : r["CodeFiliation"].ToString(),
                        DescFiliations = r.IsNull("DescFiliations") ? "" : r["DescFiliations"].ToString(),
                        UrlPlanetPicture = r.IsNull("UrlPlanetPicture") ? "" : r["UrlPlanetPicture"].ToString(),
                        IPPlanet = r.IsNull("IPPlanet") ? "" : r["IPPlanet"].ToString(),
                        PortPlanet = r.IsNull("PortPlanet") ? 0 : Convert.ToInt32(r["PortPlanet"]),
                        PortPlanet1 = r.IsNull("PortPlanet1") ? 0 : Convert.ToInt32(r["PortPlanet1"]),
                        Mail = r["Mail"].ToString(),
                        Permisos = permisos
                    };

                    result = 1;

                    // Carregar permisos

                    parametros = new Dictionary<string, object>()
                    {
                        { "@AccessLevel", AccessLevel },
                    };

                    consulta = @"
                        select ID_Op,Dll,Tipus,Nom,Icona,DescForm from UserOptions where AccessLevel<=@AccessLevel and EsManteniment=1 order by Ordre,Nom
                    ";
                    ds = m.GeneraConsultaCerca(consulta, parametros);

                    string dll, tipu, nom, desc;
                    int id_op;
                    byte[] icona;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        id_op = (int)row[0];
                        dll = (string)row[1];
                        tipu = (string)row[2];
                        nom = (string)row[3];
                        icona = row.IsNull(4) ? null : (byte[])row[4];
                        desc = (string)row[5];

                        permisos.Add(new Permis()
                        {
                            Dll = dll,
                            Icona = icona,
                            ID_Op = id_op,
                            Nom = nom,
                            Tipus = tipu,
                            Desc = desc
                        });
                    }
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

        public static bool LoginExiste(string login)
        {
            string consulta;
            clsModeloDatos m = new clsModeloDatos();

            consulta = "SELECT idUser FROM Users WHERE Login = @Login";
            var parametros = new Dictionary<string, object> { 
                { "@Login", login } 
            };
            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            return ds.Tables[0].Rows.Count != 0;
        }

        public static bool UserNameExiste(string username)
        {
            string consulta;
            clsModeloDatos m = new clsModeloDatos();

            consulta = "SELECT idUser FROM Users WHERE UserName = @UserName";
            var parametros = new Dictionary<string, object> {
                { "@UserName", username }
            };
            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            return ds.Tables[0].Rows.Count != 0;
        }

        public static bool CodeUserExiste(string codeuser)
        {
            string consulta;
            clsModeloDatos m = new clsModeloDatos();

            consulta = "SELECT idUser FROM Users WHERE CodeUser = @CodeUser";
            var parametros = new Dictionary<string, object> {
                { "@CodeUser", codeuser }
            };
            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            return ds.Tables[0].Rows.Count != 0;
        }

        public static bool ActualizarPasswordConHash(string usuario, string salt, string passwordHasheado, string mail)
        {

            string consulta = "update Users set Password=@password,Salt=@salt,Mail=@mail,PasswordTmp=null where Login = @usuario";

            var parametros = new Dictionary<string, object>
            {
                { "@password", passwordHasheado },
                { "@salt", salt },
                { "@usuario", usuario },
                { "@mail", mail },
            };

            clsModeloDatos m = new clsModeloDatos();
            int registrosAfectados = m.ExecutaConParametros(consulta, parametros);

            return registrosAfectados > 0;
        }

    }
}
