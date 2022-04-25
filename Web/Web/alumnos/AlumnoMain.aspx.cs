using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Web
{
    public partial class AlumnoMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            var businessLogic = new LogicaNegocio.LogicaNegocio();
            businessLogic.disconnect(Session["Nombre"].ToString());
            Session.Abandon();
            Response.Redirect("../inicio.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GridView1.DataBind();
            GridView2.DataBind();
        }
    }
}