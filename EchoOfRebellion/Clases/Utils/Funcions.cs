using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EchoOfRebellion.Clases.Utils
{
    public static class Funcions
    {
        public static string CreateSalt()
        {
            DateTime today = DateTime.Today;
            string strHash = today.ToString("yyyyMMddHHmmssfff");
            return strHash.Hash256();
        }

        public static int CreateNumRNG()
        {
            using (RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider())
            {
                byte[] valor = new byte[4];

                rngCrypt.GetBytes(valor);

                int valor3 = BitConverter.ToInt32(valor, 0);

                valor3 = Math.Abs(valor3);

                return valor3;
            }
        }
        public static bool ValidacionLogin(string login)
        {
            string regexLogin = @"^[a-zA-Z0-9]+$";

            //MauroLopez31 = true

            bool esValid = Regex.IsMatch(login, regexLogin);
            
            return esValid;
        }
        public static bool ValidacionPassword(string password)
        {
            string regexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";

            //Ml7482hl = true

            bool esValid = Regex.IsMatch(password, regexPassword);

            return esValid;
        }
    }
}
