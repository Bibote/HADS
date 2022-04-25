using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using System.Security.Cryptography;

namespace Web
{
    
    public partial class Registro : System.Web.UI.Page
    {
        private string comprobado = "NO";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var logica = new LogicaNegocio.LogicaNegocio();
           
            
            Random r = new Random();
            int rando = Int32.Parse(r.Next(100000, 999999).ToString());
            int randopass = Int32.Parse(r.Next(100000, 999999).ToString());
            logica.SendEmail(TextBox1.Text, "http://hads22-062.azurewebsites.net/confirmar.aspx?mbr=" + TextBox1.Text + "&numconf="+rando);
            string contra = logica.encriptar(TextBox4.Text);
            if(comprobado.Equals("SI"))
            {
                Label1.Text = logica.storeUser(TextBox1.Text, TextBox2.Text, TextBox3.Text, rando, false, RadioButtonList1.SelectedValue, contra, randopass);
            }
            else
            {
                Label1.Text = "Web solo para usuarios matriculados";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            es.ehusw.Matriculas cliente= new es.ehusw.Matriculas();
            comprobado = cliente.comprobar(TextBox1.Text);
            if (comprobado.Equals("SI"))
            {
                Label2.Text = "Está matriculado";
            }
            else
            {
                Label2.Text = "No está matriculado";
            }
        }
    }
}