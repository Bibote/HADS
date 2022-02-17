﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logica = new LogicaNegocio.LogicaNegocio();
            string email = Request.Params["mbr"];
            string numconf = Request.Params["numconf"];
            Label1.Text=logica.validateUser(email, Int32.Parse(numconf));



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}