using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Web
{
    
    public partial class Registro : System.Web.UI.Page
    {
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
            logica.SendEmail(TextBox1.Text, "http://localhost/PracticaHAS/confirmar.aspx?mbr=" +TextBox1.Text + "&numconf="+rando);

            Label1.Text= logica.storeUser(TextBox1.Text, TextBox2.Text, TextBox3.Text, rando, false, RadioButtonList1.SelectedValue, TextBox4.Text, randopass);
            
            
          
  
  


        }
   


    }
}