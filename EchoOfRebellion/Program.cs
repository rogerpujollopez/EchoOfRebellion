using EchoOfRebellion;
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
            //Application.Run(splash);
        }

        private static void ShowSplashThenLogin()
        {
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
                using (var frmain = new frmMenuPrincipal())
                {
                    frmain.ShowDialog();
                }
            }


        }

    }
}
