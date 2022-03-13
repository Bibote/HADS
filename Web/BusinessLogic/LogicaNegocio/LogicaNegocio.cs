using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data;

namespace LogicaNegocio
{
    public class LogicaNegocio
    {
        private BaseDatos.BaseDatos bd = new BaseDatos.BaseDatos();
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

        public string logIn(string mail, string pass)
        {
            bd.conectar();
            string s = bd.logIn(mail, pass);

            bd.cerrarconexion();
            return s;
        }

        public bool emailRegistered(string mail)
        {
            bd.conectar();
            bool res = bd.emailRegistered(mail);
            bd.cerrarconexion();

            return res;
        }

        public string updatePass(string mail, string pass, int num)
        {
            bd.conectar();
            string a=bd.updatePassword(mail, pass, num);
            bd.cerrarconexion();
            return a;
        }

        public string getCodPass(string mail)
        {
            bd.conectar();
            string num =bd.getNumPass(mail);
            bd.cerrarconexion();
            return num;
        }

        public string addTarea(string cod, string des, string codas, int horas, bool explo, string tipo)
        {
            bd.conectar();
            string s = bd.addTarea(cod, des, codas, horas, explo, tipo);
            bd.cerrarconexion();
            return s;
        }

        public DataSet obtainAlumnoAsignaturas(string emailaux)
        {
            bd.conectar();
            DataSet dataset1 = bd.obtenerAsignaturasAlumno(emailaux);
            bd.cerrarconexion();

            return dataset1;
        }

        public DataSet obtainAlumnoTareas(string emailaux)
        {
            bd.conectar();
            DataSet dataset2 = bd.obtenerTareasAlumno(emailaux);
            bd.cerrarconexion();

            return dataset2;
        }

    }
}
