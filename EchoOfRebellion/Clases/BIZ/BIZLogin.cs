using EchoOfRebellion.Clases.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EchoOfRebellion.Clases.Utils;
using EchoOfRebellion;
using static BiblioModeloDatos.DM.DMModel;
using System.Windows.Forms;


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

        public static bool EsPasswordValido(string pass)
        {
            return true;
        }

        public static bool RevisarCondicionesRestablecer(string usuario, string nuevoPassword, string confirmarPassword)
        {
            if (!DMLogin.UsuarioExiste(usuario))
            {
                MessageBox.Show("El usuario no existe.");
                return false;
            }

            else if (nuevoPassword != confirmarPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return false;
            }

            else if (!BIZLogin.EsPasswordValido(nuevoPassword))
            {
                MessageBox.Show("La contraseñas no es válida.");
                return false;
            }

            return true;
        }

        public static bool RestablecerPassword(string usuario, string nuevoPassword, string mail)
        {
            string salt = Funcions.CreateSalt();

            string passwordHasheado = (salt + nuevoPassword).Hash256();

            // Actualizar la contraseña con hash y salt
            bool esOk = DMLogin.ActualizarPasswordConHash(usuario, salt, passwordHasheado, mail);

            return esOk;
        }
        public static int EnviarMail(string usuario, string mail)
        {
            int code = int.Parse(Funcions.CreateNumRNG().ToString().Substring(3));
            Comunicacio.EnviarMail(usuario, mail, "Código de verificacion",
                $"Codigo de verifiacion: {code}"
                );
            return code;
        }
    }
}
