<<<<<<< HEAD
﻿using EchoOfRebellion;
=======
﻿using EchoOfRebellion.Formularios;
>>>>>>> dev
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
<<<<<<< HEAD
            ShowSplashThenLogin();
            //Application.Run(new frmMenuPrincipal());
=======
            //ShowSplashThenLogin();
            Application.Run(new frmTemp());
>>>>>>> dev
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


<<<<<<< HEAD
                using (var frmain = new frmMenuPrincipal())
=======
                using (frmMenuPrincipal frmain = new frmMenuPrincipal())
>>>>>>> dev
                {
                    frmain.ShowDialog();
                }
            }


        }

    }
}
