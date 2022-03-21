using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class exportartareas : System.Web.UI.Page
    {
        DataView dv, dd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cargardropdown();
                var businessLogic = new LogicaNegocio.LogicaNegocio();
                Session["tareas"] = businessLogic.getTareas();
                gridswap();
            }
            else
            {
                gridswap();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet xmlExport = new DataSet();
            DataTable dt = dv.ToTable();

            if (dt != null & dt.Rows.Count > 0)
            {
                xmlExport.Tables.Add(dt);
            }
            xmlExport.WriteXml(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml"));



        }

        private void gridswap()
        {
            DataSet filtradas = (DataSet)Session["tareas"];
            dv = filtradas.Tables[0].DefaultView;
            dv.RowFilter = "codAsig='"+DropDownList1.SelectedValue+"'";

            GridView1.DataSource = dv;

            GridView1.DataBind();
        }

        private void cargardropdown()
        {
            DataSet bobi = (DataSet)Session["asignaturas"];
            DropDownList1.DataSource = bobi;
            DropDownList1.DataTextField = "codAsig";
            DropDownList1.DataValueField = "codAsig";
            try
            {
                DropDownList1.DataBind();
            }
            catch
            {
                Label1.Text =bobi.ToString();
            }
        }

        
    }
}