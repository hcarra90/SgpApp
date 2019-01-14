using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Layer.Functions
{
    public static class FuncionesEmail
    {
        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool EnvioEmail(string filename,string to,string mensaje,string titulo)
        {
            bool resultado = false;
            string from= ConfigurationManager.AppSettings["From"].ToString();
            string usuarioEmail = ConfigurationManager.AppSettings["EmailUser"].ToString();
            string passEmail = ConfigurationManager.AppSettings["EmailPassword"].ToString();

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("mail.massainursery.cl");

            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = titulo;
            mail.Body = mensaje;

            mail.Attachments.Add(new Attachment(filename));

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new
            System.Net.NetworkCredential(usuarioEmail, passEmail);
            
            try
            {
                SmtpServer.Send(mail);
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            

            return resultado;
        }
    }
}
