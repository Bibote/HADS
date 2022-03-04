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
            string s = logica.logIn(TextBox1.Text, TextBox2.Text);
            Label1.Text = s;
            if (Equals(Label1.Text, s)){
                Session["Nombre"] = TextBox1.Text;
                Session["Tipo"] = s;

                Response.Redirect("alumnoMain.aspx");
            }
            else if(s.Equals("Profesor"))
            {
                Session["Nombre"] = TextBox1.Text;
                Session["Tipo"] = s;

                Response.Redirect("profeMain.aspx");
            }
            else
            {
                Label1.Text = s;
            }
      
            
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContrasena.aspx");
        }
    }
}