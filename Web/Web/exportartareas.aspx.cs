using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

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
            DataSet tareas = new DataSet();
            DataTable dt = dv.ToTable();
            tareas.DataSetName="tareas";
            dt.TableName = "tarea";
            dt.Columns[0].ColumnMapping = MappingType.Attribute;
            dt.Columns.RemoveAt(2);
            dt.Columns[2].ColumnName = "hestimada";
            dt.Columns[3].SetOrdinal(4);
            dt.Columns[4].ColumnName = "tipotarea";
            dt.Columns[2].ColumnName = "hestimadas";
            if (dt != null & dt.Rows.Count > 0)
            {
                tareas.Tables.Add(dt);
            }
            
            tareas.WriteXml(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml"));
            Label1.Text = "Tarea exportada";



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
            DropDownList1.DataTextField = "codigoAsig";
            DropDownList1.DataValueField = "codigoAsig";
            try
            {
                DropDownList1.DataBind();
            }
            catch
            {
                Label1.Text = "Este profesor no tiene asignaturas";
            }
        }


        
    }
}