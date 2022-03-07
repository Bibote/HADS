using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class insertarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var logica = new LogicaNegocio.LogicaNegocio();
            Label1.Text = logica.addTarea(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedValue, Int32.Parse(TextBox4.Text),false, DropDownList2.SelectedValue);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("tareassProfesor.aspx");
        }
    }
}