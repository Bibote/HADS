using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class BaseDatos
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
            var st = "insert into Usuario values ('" + mail + "','" + nombre + "','" + apellidos + "','" + num + "','" + confimado + "','" + tipo + "','" + pass + "','" + codpass + "')";
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
        public bool userExistCode(string mail, int code)
        {
            var st = "select count(*) from Usuario Where email='" + mail + "' and numconfir='" + code + "'";
            comando = new SqlCommand(st, conexion);
            if (comando.ExecuteScalar().ToString().Equals("1"))
            {
                return true;
            }
            else return false;

        }

        public string validateUser(string mail, int code)
        {
            if (userExistCode(mail, code))
            {
                var st = "UPDATE Usuario SET confirmado='" + true + "'  Where email='" + mail + "' and numconfir='" + code + "'";
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

        public string logIn(string mail, string pass)
        {
            string myString = "vacio";
            var st = "select * from Usuario Where email='"+mail+"'and pass='"+pass+"'and confirmado='"+true+"'";
            comando = new SqlCommand(st, conexion);

            SqlDataReader s = comando.ExecuteReader();
            while (s.Read())
            {
                myString = s.GetString(5);
            }
            s.Close();
            return myString;

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

        public string updatePassword(string email, string pass, int num)
        {
            var st = "UPDATE Usuario SET pass='" + pass + "' Where email='" + email + "' and codpass='" + num + "'";
            try
            {
                comando = new SqlCommand(st, conexion);
                if (comando.ExecuteNonQuery().ToString().Equals("1"))
                {
                    return "Contraseña cambiada";
                }
                return "Valores incorrectos";

            }
            catch (Exception ex)
            {
                return "Ha ocurrido algún error en el sistema";
            }


        }

        public string getNumPass(string mail)
        {
            var st = "select codpass from Usuario Where email='" + mail + "'";
            comando = new SqlCommand(st, conexion);
            return comando.ExecuteScalar().ToString();

        }

        public String addTarea(string cod, string des, string codas, int horas, bool explo, string tipo)
        {


            comando = new SqlCommand("addTarea", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("cod", new SqlParameter()).Value = cod;
            comando.Parameters.AddWithValue("des", new SqlParameter()).Value = des;
            comando.Parameters.AddWithValue("codas", new SqlParameter()).Value = codas;
            comando.Parameters.AddWithValue("horas", new SqlParameter()).Value = horas;
            comando.Parameters.AddWithValue("explo", new SqlParameter()).Value = explo;
            comando.Parameters.AddWithValue("tipo", new SqlParameter()).Value = tipo;

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return "Ha ocurrido algún error en el servidor";
            }

            return ("Tarea añadida");
        }

        public SqlDataAdapter collecionDeTareas()
        {
            String query3 = "select * from EstudianteTarea";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query3, conexion);

            return dataAdapter;
        }

        public DataSet obtenerAsignaturasAlumno(string email1)
        {
            String query1 = "Select codigo FROM Asignatura where codigo in ( Select codigoAsig from GrupoClase where codigo in ( Select grupo from EstudianteGrupo where email = '" + email1 + "'))";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query1, conexion);

            DataSet dataSet1 = new DataSet();

            dataAdapter.Fill(dataSet1);

            return dataSet1;
        }

        public DataSet obtenerTareasAlumno(string email1)
        {
            String query2 = "select * from TareaGenerica where explotacion = 1 and codigo not in (select codTarea from EstudianteTarea where email = '" + email1 + "')";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);

            DataSet dataset2 = new DataSet();

            dataAdapter.Fill(dataset2);

            return dataset2;
        }

        public DataSet getTareas()
        {
            string query = "Select * from TareaGenerica";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);

            DataSet dataset = new DataSet();

            dataAdapter.Fill(dataset);
            return dataset;
        }

        public DataSet getAsignaturasProfe(string mail)
        {
            comando = new SqlCommand("getTareasProfesor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("mail", new SqlParameter()).Value = mail;
            SqlDataAdapter sda = new SqlDataAdapter(comando);
            DataSet dataset = new DataSet();
            sda.Fill(dataset);

            return dataset;


        }
    }
}
