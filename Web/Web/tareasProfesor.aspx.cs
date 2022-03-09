using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class tareasProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Response.Redirect("tareasProfesor.aspx?param=DropDownList1.SelectedValue");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("insertarTarea.aspx");
        }
    }
}