using System;
using System.Net.Mail;
using System.Net;
using System.Text;
using static System.Collections.Specialized.BitVector32;


namespace Negocio
{
    public class EmailService
    {
        private MailMessage mensaje;
        private SmtpClient servicioCorreo;
        private string plantillaHTML;

        //CONSTRUCTOR
        public EmailService()
        {
            servicioCorreo = new SmtpClient();
            servicioCorreo.Credentials = new NetworkCredential("hardfishstore@hotmail.com", "HardFish1");
            servicioCorreo.EnableSsl = true;
            servicioCorreo.Host = "smtp.office365.com";
            servicioCorreo.Port = 587;
        }

        //ARMAR CORREO
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
        //ENVIAR CORREO
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
        //CERRAR CONEXION (Ver si es necesario utilizar)
        public void CerrarConexion()
        {
            try
            {
                servicioCorreo.Dispose();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
