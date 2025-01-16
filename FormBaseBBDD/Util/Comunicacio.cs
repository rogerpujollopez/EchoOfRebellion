using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Windows.Forms;

namespace FormBaseBBDD.Util
{
    internal class Comunicacio
    {
        public static bool EnviarMail(string nomDestinatari, string mailDestinatari, string asumpte, string missatge)
        {
            string usu = ConfigurationManager.AppSettings["MailUser"];
            string pass = ConfigurationManager.AppSettings["MailPassword"];
            string smtp = ConfigurationManager.AppSettings["SmtpServer"];

            bool enviat = false;

            try
            {
                SmtpClient smtpClient = new SmtpClient(smtp)
                {
                    Port = 587, // Puerto para TLS
                    Credentials = new NetworkCredential(usu, pass),
                    EnableSsl = true // Habilitar SSL/TLS
                };

                // Crear el mensaje de correo
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(usu),
                    Subject = asumpte,
                    Body = missatge,
                    IsBodyHtml = false // Cambia a true si quieres enviar contenido HTML
                };
                mailMessage.To.Add(mailDestinatari);

                // Enviar el correo
                smtpClient.Send(mailMessage);

                enviat = true;
            }
            catch (Exception)
            {
                //Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }

            return enviat;
        }
    }
}
