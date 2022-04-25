using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var logica = new LogicaNegocio.LogicaNegocio();
            string nombre = TextBox1.Text;
            string contrasena = logica.encriptar(TextBox2.Text);


            string s = logica.logIn(nombre, contrasena);
            if (Equals(s, "Alumno")) {
                Session["Nombre"] = nombre;
                FormsAuthentication.SetAuthCookie("Alumno", false);


                logica.connect(nombre, "alumno");
                Response.Redirect("alumnos/alumnoMain.aspx");
            }
            else if (s.Equals("Profesor"))
            {
                logica.connect(nombre, "profesor");
                Session["Nombre"] = nombre;
                FormsAuthentication.SetAuthCookie("Profesor", false);
                if (string.Equals(nombre, "vadillo@ehu.es"))
                {
                    FormsAuthentication.SetAuthCookie("AdminCoor", false);
                }
                
                Response.Redirect("profes/profesor.aspx");
            }
            else if (s.Equals("Admin"))
            {
                Session["Nombre"] = nombre;


                FormsAuthentication.SetAuthCookie("AdminCoor", false);


                Response.Redirect("profes/profesor.aspx");
            }

            else
            {
                Label1.Text = "Email o contraseña incorrecta";
            }



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContrasena.aspx");
        }


    }
}