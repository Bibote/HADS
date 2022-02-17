using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public int codigo;
        public string emailaux;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var logica = new LogicaNegocio.LogicaNegocio();

            if (logica.emailRegistered(TextBox1.Text))
            {
                Random r = new Random();
                int rando = Int32.Parse(r.Next(100000, 999999).ToString());
                logica.SendEmail(TextBox1 .Text , "El codigo de verificación es: " + rando);
                codigo = rando;
                emailaux = TextBox1.Text;
                Label1.Text = "Codigo enviado!";
            }
            else
            {
                Label1.Text = "El email no esta registrado";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if ((Int32.Parse(TextBox2.Text) == codigo) && (TextBox3.Text == TextBox4.Text))
            {
                var logica = new LogicaNegocio.LogicaNegocio();

                logica.updatePass(emailaux, TextBox3.Text);

                Response.Redirect("inicio.aspx");

            }
            else
            {
                Label2.Text = "Error, prueba otra vez";
            }
        }
    }
}