using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

    }
}
