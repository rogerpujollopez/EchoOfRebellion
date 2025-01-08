using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Utils
{
    public static class Extensions
    {
        public static Label SituarLabel<T>(this string texto, T control, Color color) where T : Control
        {
            int offset = texto.Length * 8;
            int offset_w = 10; // Desplazamiento horizontal
            int offset_h = 2;  // Desplazamiento vertical

            Label lbl = new Label()
            {
                Name = "lbl" + texto,
                Text = texto,
                Location = new Point(0, 0),
                AutoSize = false,
                Width = offset,
                Height = 13,
                ForeColor = color,
            };

            // Calcular el tamaño del texto en el Label
            Size textSize = TextRenderer.MeasureText(lbl.Text, lbl.Font);

            // Posicionar el Label relativo al Control
            lbl.Location = new Point(control.Location.X - (textSize.Width + offset_w), control.Location.Y + offset_h);

            return lbl;
        }

        public static byte[] LoadFileToArrayBytes(this string FileName)
        {
            return File.ReadAllBytes(FileName);
        }

        public static bool EsMail(this string email)
        {
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format?redirectedfrom=MSDN

            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None);

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                //return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static string Hash256(this string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes);
            }
        }

        public static string Capitalize(this string texto) // hola mundo -> Hola mundo
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }

    }
}
