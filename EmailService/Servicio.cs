using System.Net;
using System.Net.Mail;
using System.Configuration;
using System;

namespace EmailService
{
    public class Servicio
    {
        private SmtpClient server;

        public Servicio()
        {
            server = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["EmailHost"],
                Port = int.Parse(ConfigurationManager.AppSettings["EmailPort"]),
                EnableSsl = bool.Parse(ConfigurationManager.AppSettings["EmailEnableSsl"]),
                Credentials = new NetworkCredential(
                             ConfigurationManager.AppSettings["CorreoOutlook"],
                             ConfigurationManager.AppSettings["ClaveCorreoOutlook"]
                         )
            };
        }


        public void EnviarCorreo(string destino, string asunto, string mensaje)
        {
            try
            {
                string remitente = ConfigurationManager.AppSettings["CorreoOutlook"];

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(remitente),
                    Subject = asunto,
                    Body = mensaje,
                    IsBodyHtml = true
                };
                mail.To.Add(destino);

                server.Send(mail);
            }
            catch (Exception ex)
            {
                // Podés loguear o mostrar este error en un Label
                throw new Exception("Error al enviar correo: " + ex.Message);
            }
        }

        public void Registro(string destino,  string clave)
        {
            string asunto = "Registro exitoso";
            string mensaje = $"<h1>Bienvenido</h1>" +
                             "<p>Tu registro ha sido exitoso.</p>" +
                             "<p>Tu clave es: " + clave + "</p>" +
                             "<p>Gracias por registrarte.</p>";

            EnviarCorreo(destino, asunto, mensaje);
        }


        public void CambioDeContraseña(string destino, string clave)
        {
            string asunto = "Cambio de contraseña exitoso";
            string mensaje = $"<h1>Contraseña actualizada</h1>" +
                             "<p>Tu contraseña se ha cambiado correctamente.</p>" +
                             $"<p>Tu nueva clave es: {clave}</p>" +
                             "<p>Si no realizaste este cambio, por favor contactanos de inmediato.</p>";


            EnviarCorreo(destino, asunto, mensaje);
        }

        public void RecuperarContraseña(string destino, string clave)
        {
            string asunto = "Recuperación de contraseña";
            string mensaje = $"<h1>Recuperación de contraseña</h1>" +
                             "<p>Hemos recibido una solicitud para recuperar tu contraseña.</p>" +
                             $"<p>Tu clave es: {clave}</p>" +
                             "<p>Si no realizaste esta solicitud, por favor contactanos de inmediato.</p>";
            EnviarCorreo(destino, asunto, mensaje);
        }
    }
}

//revisar EmailService