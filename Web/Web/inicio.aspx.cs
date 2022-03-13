using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string contrasena = TextBox2.Text;

            
            string s = logica.logIn(nombre,contrasena);
            if (Equals(s, "Alumno")){
                Session["Nombre"] = nombre;
                Session["Tipo"] = s;

                Response.Redirect("alumnoMain.aspx");
            }
            else if(s.Equals("Profesor"))
            {
                Session["Nombre"] = nombre;
                Session["Tipo"] = s;

                Response.Redirect("profesor.aspx");
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