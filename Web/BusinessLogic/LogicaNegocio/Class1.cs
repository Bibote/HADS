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

        public static string conectar()
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

        public static void cerrarconexion()
        {
            conexion.Close();
        }
    }
}
