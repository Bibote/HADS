using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace LogicaNegocio
{
    public class LogicaNegocio
    {
        public LogicaNegocio()
        {
            
        }
        public void SendEmail(String destinatario, String input)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.ehu.eus");

                mail.From = new MailAddress("msaez034@ikasle.ehu.eus");
                mail.To.Add(destinatario);
                mail.Subject = "Test Mail";
                mail.Body = input;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("msaez034@ikasle.ehu.eus", "Mosquito8-");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
