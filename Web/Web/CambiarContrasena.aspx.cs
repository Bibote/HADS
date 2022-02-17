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
        public string emailaux;
        public int num;
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
                num = Int32.Parse(logica.getCodPass(TextBox1.Text));
                logica.SendEmail(TextBox1 .Text , "El codigo de verificación es: " + num);
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
            if (TextBox3.Text.Equals(TextBox4.Text)) {


                var logica = new LogicaNegocio.LogicaNegocio();
                try
                {
                    Label2.Text = logica.updatePass(TextBox1.Text, TextBox3.Text, Int32.Parse(TextBox2.Text));
                }
                catch
                {
                    Label2.Text = "Ha ocurrido algun error en el sistema";
                }
            }
            else
            {
                Label2.Text = "Las contaseñas no coinciden";
            }

                

         
            
        }
    }
}