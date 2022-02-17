using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LogicaNegocio
{
    class BaseDatos
    {
        private static SqlConnection conexion = new SqlConnection();
        private static SqlCommand comando = new SqlCommand();
        public BaseDatos()
        {

        }
        public string conectar()
        {
            try
            {
                conexion.ConnectionString = "Data Source=tcp:hads22062.database.windows.net,1433;Initial Catalog=HADS2206;Persist Security Info=False;User ID=adminpotente;Password=contraseña8-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                conexion.Open();
            }
            catch (Exception ex)
            {
                return "ERROR DE CONEXIÓN: " + ex.Message;
            }

            return "CONEXION OK";
        }

        public void cerrarconexion()
        {
            conexion.Close();
        }

        public String addUser(string mail, string nombre, string apellidos, int num, bool confimado, string tipo, string pass, int codpass)
        {
            var st = "insert into Usuarios values ('" + mail + " ','" + nombre + " ','" + apellidos + " ','" + num + " ','" + confimado + " ','" + tipo + " ','" + pass + " ','" + codpass + " ')";
            int numregs;
            comando = new SqlCommand(st, conexion);
            try
            {
                numregs = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return "Ha ocurrido algún error en el servidor";
            }

            return ("Enviado un email para verificar el usuario");
        }
        public bool userExistCode(string mail,int code)
        {
            var st = "select count(*) from Usuarios Where email='"+mail+"' and numconfir='"+code+"'";
            comando = new SqlCommand(st, conexion);
            if (comando.ExecuteScalar().ToString().Equals("1"))
            {
                return true;
            }
            else return false;
   
        }

        public string validateUser(string mail, int code)
        {
            if (userExistCode(mail,code))
            {
                var st = "UPDATE Usuarios SET confirmado='" +true+ "'  Where email='" + mail + "' and numconfir='" + code + "'";
                int numregs;
                comando = new SqlCommand(st, conexion);
                try
                {
                    numregs = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                return ("Usuario validado");
            }
            return "Link invalido";
        }

        public bool logIn(string mail, string pass)
        {
            var st = "select count(*) from Usuarios Where email='" + mail + "' and pass='" + pass + "' and confirmado='"+true+"'";
            comando = new SqlCommand(st, conexion);
            if (comando.ExecuteScalar().ToString().Equals("1"))
            {
                return true;
            }
            else return false;
        }

        public bool emailRegistered(string mail)
        {
            var st = "select count(*) from Usuarios Where email='" + mail + "'";
            comando = new SqlCommand(st, conexion);
            if (comando.ExecuteScalar().ToString().Equals("1"))
            {
                return true;
            }
            else return false;
        }

        public void updatePassword(string email, string pass)
        {
            var st = "update Usuarios Set pass='" + pass + "' Where email='" + email + "'";
            comando = new SqlCommand(st, conexion);
            comando.ExecuteNonQuery();

        }

    }
}
