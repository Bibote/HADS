using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using System.Data;

namespace Web
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                initializeDropDownList();
                initializeGridView();
            }
        }

        private void initializeDropDownList()
        {
            var businessLogic = new LogicaNegocio.LogicaNegocio();
            DataSet dataset1 = businessLogic.obtainAlumnoAsignaturas((string)Session["Nombre"]);
            asignatura.DataSource = dataset1;
            asignatura.DataTextField = "codigo";
            asignatura.DataValueField = "codigo";
            asignatura.DataBind();
            
        }

        private void initializeGridView()
        {
            var businessLogic = new LogicaNegocio.LogicaNegocio();
            DataSet dataset1 = businessLogic.obtainAlumnoTareas((string)Session["nombre"]);

            DataTable dataTable1 = new DataTable();

            dataTable1 = dataset1.Tables[0];

            Session["dataTableDeTareas"] = dataTable1;

            filtracion();
        }

        private void filtracion()
        {
            DataTable dataTable2 = (DataTable)Session["dataTableDeTareas"];
            DataView dataView1 = new DataView(dataTable2);

            dataView1.RowFilter = "codAsig = '" + asignatura.SelectedValue + "'";

            dataTable2 = dataView1.ToTable();

            dataTable2.Columns.Remove("codAsig");

            GridView1.DataSource = dataTable2;

            GridView1.DataBind();
        }

        protected void asignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtracion();
        }
    }
}