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
                return ex.Message;
            }

            return (numregs + " registro(s) insertado(s) en la BD ");
        }

        public string validateUser(string mail, int num)
        {
            var st = "SELECT * FROM Usuarios WHERE 'email'=";
        }
    }
}
