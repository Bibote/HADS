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
        private BaseDatos bd = new BaseDatos();
        public LogicaNegocio()
        {
            
        }
        public void SendEmail(String destinatario, String input)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("emilioverificador@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Confirmación";
                mail.Body = input;
                mail.Priority = MailPriority.High;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("emilioverificador@gmail.com", "Emiliosena8-");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
            }
        }

        public string storeUser(string mail, string nombre, string apellidos, int num, bool confimado, string tipo, string pass, int codpass)
        {
            bd.conectar();
            string s =bd.addUser(mail, nombre, apellidos, num, confimado, tipo, pass, codpass);
            bd.cerrarconexion();
            return s;
        }

        
        public string validateUser(string mail, int code)
        {
            bd.conectar();
            string s = bd.validateUser(mail, code);
         
            bd.cerrarconexion();
            return s;

        }

        public bool logIn(string mail, string pass)
        {
            bd.conectar();
            bool s = bd.logIn(mail, pass);

            bd.cerrarconexion();
            return s;
        }
    }
}
