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
            if (logica.logIn(TextBox1.Text,TextBox2.Text)) {
                Response.Redirect("app.aspx");
            }
            else
            {
                Label1.Text = "Usuario no validado o incorrecto";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContrasena.aspx");
        }
    }
}