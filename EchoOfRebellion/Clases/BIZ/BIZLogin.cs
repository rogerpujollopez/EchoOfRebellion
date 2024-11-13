using EchoOfRebellion.Clases.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BiblioModeloDatos.DM.DMModel;

namespace EchoOfRebellion.Clases.BIZ
{
    internal class BIZLogin
    {
        public static int BizLogin(string usuari, string password) 
        {
            // Revisar Regex usuario

            // Revisar regex pass

            // Si todo ok, enviamos a la bbdd


            int result = DMLogin.DmLogin(usuari, password);

            return result;
        }

    }
}
