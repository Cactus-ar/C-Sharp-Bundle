using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gmailAPI
{
    //Ejemplo de acceso a la api de gmail
    //necesita Google APIs Client Library for working with Gmail v1.

    class Program
    {
     
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";

        static void Main(string[] args)
        {
            UserCredential credential;

            //credentials,json es creado por google desde la consola de devs
            //adjuntar al proyecto el archivo y en las propiedades setear copiar siempre
            //obviamente archivo de este ejemplo ha sido modificado y no contiene credenciales adecuadas
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                
                string credPath = "token.json"; 
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //Enviar el mail
            string de = "sasa@gmail.com";
            string para = "saaaaas@gmail.com";
            string asunto = "un mailsito de prueba";
            string cuerpo = "el cuerpo de prueba";

            Message mensajeParaEnviar = crearMensaje(crearEmail(de, para, asunto, cuerpo));
            mensajeParaEnviar = service.Users.Messages.Send(mensajeParaEnviar, "me").Execute();
            
            Console.WriteLine($"Resultado: {mensajeParaEnviar.Id}");
            Console.WriteLine($"Resultado: {mensajeParaEnviar.InternalDate}");
            Console.Read();
        }

        private static Message crearMensaje(MailMessage mensaje)
        {
            MimeMessage mensajeMime = MimeMessage.CreateFromMailMessage(mensaje);
            Message mensajeFini = new Message();
            mensajeFini.Raw = Base64UrlEncode(mensajeMime.ToString());
            return mensajeFini;
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }


        private static MailMessage crearEmail(string de, string para, string asunto, string cuerpo)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(de);
            email.To.Add(new MailAddress(para));
            email.Subject = asunto;
            email.Body = cuerpo;
            email.IsBodyHtml = true;
            return email;
        }
    }
}
