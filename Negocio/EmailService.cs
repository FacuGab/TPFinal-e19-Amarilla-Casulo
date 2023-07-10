﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using static System.Collections.Specialized.BitVector32;


namespace Negocio
{
    public class EmailService
    {
        private MailMessage mensaje;
        private SmtpClient servicioCorreo;

        public EmailService()
        {
            servicioCorreo = new SmtpClient();
            servicioCorreo.Credentials = new NetworkCredential("hardfishstore@hotmail.com", "HardFish1");
            servicioCorreo.EnableSsl = true;
            servicioCorreo.Host = "smtp.office365.com";
            servicioCorreo.Port = 587;
        }

        public void ArmarCorreo(string destinatario, string asunto, string contenido)
        {
            try
            {
                mensaje = new MailMessage();
                mensaje.From = new MailAddress("hardfishstore@hotmail.com");
                mensaje.To.Add(destinatario);
                mensaje.Subject = asunto;
                mensaje.Body = contenido;
                mensaje.IsBodyHtml = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EnviarCorreo()
        {
            try
            {
                servicioCorreo.Send(mensaje);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
