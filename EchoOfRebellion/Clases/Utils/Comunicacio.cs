using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EchoOfRebellion.Clases.Utils
{
    internal static class Comunicacio
    {
        public static bool EnviarMail(string nomDestinatari, string mailDestinatari, string asumpte, string missatge)
        {
            string usu = ConfigurationManager.AppSettings["MailUser"];
            string pass = ConfigurationManager.AppSettings["MailPassword"];
            string smtp = ConfigurationManager.AppSettings["SmtpServer"];

            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress("App", usu));
            mensaje.To.Add(new MailboxAddress(nomDestinatari, mailDestinatari));
            mensaje.Subject = asumpte;

            mensaje.Body = new TextPart("plain")
            {
                Text = missatge
            };

            bool enviat = false;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect(smtp, 587, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate(usu, pass);

                    client.Send(mensaje);
                    enviat = true;

                    client.Disconnect(true);
                }
                catch (Exception)
                {
                    //Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                }
            }

            return enviat;
        }

    }
}
