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
        private readonly DMLogin dmUsuarios;

        public BIZLogin()
        {
            dmUsuarios = new DMLogin();
        }
        public static int BizLogin(string usuari, string password)
        {
            int result;
            bool isValidLogin, isValidPassword;

            isValidLogin = Funcions.ValidacionLogin(usuari);

            if (isValidLogin)
            {
                isValidPassword = Funcions.ValidacionPassword(password);
                if (isValidPassword)
                {
                    result = DMLogin.DmLogin(usuari, password);
                }
                else
                {
                    result = 3;
                }
            }
            else
            {
                result = 3;
            }

            return result;
        }

        public static bool EsPasswordValido(string pass)
        {
            return true;
        }

        public static bool RevisarCondicionesRestablecer(string usuario, string nuevoPassword, string confirmarPassword)
        {
            bool isValidPassword;

            if (!DMLogin.UsuarioExiste(usuario))
            {
                MessageBox.Show("El usuario no existe.");
                return false;
            }

            isValidPassword = Funcions.ValidacionPassword(nuevoPassword);
            if (isValidPassword)
            {
                if (nuevoPassword != confirmarPassword)
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
                                
            return false;
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
