using EchoOfRebellion;
using EchoOfRebellion.Clases.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;

namespace EchoOfRebellion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowSplashThenLogin();
            //Application.Run(new frmMenuPrincipal());
        }

        private static void ShowSplashThenLogin()
        {
            //Comunicacio.EnviarMail("Mauro", "mauro.lopez@sarria.salesians.cat", "Envío desde Echo Of Rebellion","Test envío mail");

            using (var splash = new frmSplash())
            {
                splash.ShowDialog(); 
            }

            using (var login = new frmLogin())
            {
                login.ShowDialog();
            }

            if (UsuariActiu.usuari != null)
            {
                using (var frmsplashusu = new frmSplashUsuario())
                {
                    frmsplashusu.ShowDialog();
                }


                using (var frmain = new frmMenuPrincipal())
                {
                    frmain.ShowDialog();
                }
            }


        }

    }
}
