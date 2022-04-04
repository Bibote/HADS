using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Web
{
    public partial class exportartareas : System.Web.UI.Page
    {
        DataView dv;
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
            String path = Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml");
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
            
            tareas.WriteXml(path);
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            xml.DocumentElement.SetAttribute("xmlns:has","http://ji.ehu.es/has");
            xml.Save(path);
            Label1.Text = "Xml exportado";

        }

        private void gridswap()
        {
            DataSet filtradas = (DataSet)Session["tareas"];
            dv = filtradas.Tables[0].DefaultView;
            dv.RowFilter = "codAsig='"+DropDownList1.SelectedValue+"'";

            GridView1.DataSource = dv;

            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet tareas = new DataSet();

            DataTable dt = dv.ToTable();
            tareas.DataSetName = "tareas";
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
            string path = Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".json");
            string json = JsonConvert.SerializeObject(dt);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(json);

            }
            Label1.Text = "Json exportado";
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