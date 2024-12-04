using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils
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

                valor3 = Math.Abs(100000 + (valor3 % 900000));

                return valor3;
            }
        }

        public static string RandomText_Basic(int longitud)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";

            return _Random_Basic(longitud, alphabet);
        }

        public static string RandomNumber_Basic(int longitud)
        {
            const string alphabet = "0123456789";

            return _Random_Basic(longitud, alphabet);
        }

        private static string _Random_Basic(int longitud, string alphabet)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int RandomNumber;
            RandomNumber = rand.Next(100000, 999999);
            string ret = "";
            for (Int32 t = 0; t < longitud; t++) { ret += alphabet.Substring(rand.Next(0, alphabet.Length - 1), 1); }

            return ret;
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
