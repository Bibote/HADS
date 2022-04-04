using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Web
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var businessLogic = new LogicaNegocio.LogicaNegocio();
                SqlDataAdapter dataAdapteraux = businessLogic.todasLasTareas();
                DataSet datasetaux = new DataSet();
                dataAdapteraux.Fill(datasetaux);
                DataTable dataTable1 = new DataTable();
                dataTable1 = datasetaux.Tables[0];
                Session["dataSetTareas"] = datasetaux;
                Session["dataTableTareas"] = dataTable1;
                Session["dataAdapterTareas"] = dataAdapteraux;

            }

            string codigoaux = Request.Params["codigo"];
            string heaux = Request.Params["he"];
            
            TextBox1.Text = (string)Session["nombre"];
            TextBox2.Text = codigoaux;
            TextBox3.Text = heaux;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable1 = (DataTable)Session["dataTableTareas"];

            SqlDataAdapter dataAdapteraux = (SqlDataAdapter)Session["dataAdapterTareas"];

            var verificacion = dataTable1.Select("email = '" + (String)Session["nombre"] + "' and codTarea = '" + TextBox2.Text + "'");

            if (verificacion.Length == 0)
            {
                var datarowaux = dataTable1.NewRow();

                datarowaux["email"] = (string)Session["Nombre"];
                datarowaux["codTarea"] = TextBox2.Text;
                datarowaux["hEstimadas"] = Int32.Parse(TextBox3.Text);
                datarowaux["hReales"] = Int32.Parse(TextBox4.Text);

                dataTable1.Rows.Add(datarowaux);

                SqlCommandBuilder builderaux = new SqlCommandBuilder(dataAdapteraux);
                builderaux.GetInsertCommand();

                dataAdapteraux.Update((DataSet)Session["dataSetTareas"]);

                ((DataSet)Session["dataSetTareas"]).AcceptChanges();

                Label1.Text = "Tarea añadida";
            }
            else
            {
                Label1.Text = "Error";
            }

        }

    }
}