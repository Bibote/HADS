using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.profes.impoexpo
{
    public partial class tiempos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            net.azurewebsites.soapserve.ServidorSoap cliente = new net.azurewebsites.soapserve.ServidorSoap();
            string num= cliente.getTimes(DropDownList1.SelectedValue);
            if (num.Equals("")){
                Label1.Text = "No hay horas trabajadas en esta asignatura.";
            }
            else
            {
                Label1.Text = "La cantidad media de horas de esta asignatura es: " + num;
            }


        }
    }
   
}