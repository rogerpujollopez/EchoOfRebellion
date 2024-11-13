using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;

namespace EchoOfRebellion.Clases.Utils
{
    internal class Missatgeria
    {
        private static string _titol = "Vigila el costat fosc !!!";

        public static bool Sortir()
        {
            string nom = "Padawan";

            if (UsuariActiu.usuari != null)
            {
                nom = UsuariActiu.usuari.UserName;
            }

            string missatge = $"Desitges sortir, {nom}?";
            return Sortir(missatge, _titol);
        }

        public static bool Sortir(string missatge)
        {
            return Sortir(missatge, _titol);
        }

        public static bool Sortir(string missatge, string titol)
        {
            return MessageBox.Show(missatge, titol, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

    }
}
