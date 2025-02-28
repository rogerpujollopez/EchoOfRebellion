using EchoOfRebellion.Clases.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EchoOfRebellion.Clases.Utils;
using EchoOfRebellion;
using System.Windows.Forms;
using Utils;
using BiblioModeloDatos;
using UsuariActiuNameSpace;


namespace EchoOfRebellion.Clases.BIZ
{
    internal class BIZLogin
    {
        public static int BizLogin(string usuari, string password)
        {
            int result;

            result = DMLogin.DmLogin(usuari, password);

            return result;
        }

        public static bool RevisarCondicionesRestablecer(string usuario, string nuevoPassword, string confirmarPassword)
        {
            if (!DMLogin.LoginExiste(usuario))
            {
                MessageBox.Show("Este Login ya existe.");
                return false;
            }

            if (nuevoPassword != confirmarPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return false;
            }

            if (Funcions.ValidacionPassword(nuevoPassword))
            {
                MessageBox.Show("La contraseñas no es válida.");
                return false;
            }

            return true;
        }

        public static bool RestablecerPassword(string usuario, string nuevoPassword, string mail)
        {
            string salt = Funcions.CreateSalt();

            string passwordHasheado = HashPassword(salt, nuevoPassword);

            // Actualizar la contraseña con hash y salt
            bool esOk = DMLogin.ActualizarPasswordConHash(usuario, salt, passwordHasheado, mail);

            return esOk;
        }

        private static string HashPassword(string salt, string nuevoPassword)
        {
            return (salt + nuevoPassword).Hash256();
        }


        public static int EnviarMail(string usuario, string mail)
        {
            int code = Funcions.CreateNumRNG();
            Comunicacio.EnviarMail(usuario, mail, "Código de verificacion",
                $"Codigo de verifiacion: {code}"
                );
            return code;
        }

        public static void ActualizarOrdenMenu(List<int> ops)
        {
            int idUser = UsuariActiu.usuari.IdUser;

            DMLogin.ActualizarOrdenMenu(idUser, ops);

        }

    }
}
