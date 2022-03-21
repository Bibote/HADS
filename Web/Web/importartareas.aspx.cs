using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Web
{
    public partial class importartareas : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "")
            {
                if(File.Exists(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml")))
                {
                    Label1.Text = "";
                    Xml1.DocumentSource = Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml");
                    Xml1.TransformSource = Server.MapPath("App_Data/VerTablaTareas.xsl");
                }
                else
                {
                    Label1.Text = "No existe un xml de esas asignaturas";
                }
                
            }
            
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "")
            {
                if (File.Exists(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml")))
                {

                    XmlDocument xmlasig = new XmlDocument();
                    xmlasig.Load(Server.MapPath("App_Data/" + DropDownList1.SelectedValue + ".xml"));
                    XmlNodeList tareas;
                    tareas = xmlasig.GetElementsByTagName("tarea");
                    for (int i = 0; i < tareas.Count; i++)
                    {
                        XmlNodeList hijos = tareas.Item(i).ChildNodes;
                        
                        string cod = tareas.Item(i).Attributes.Item(0).Value.ToString();
                        string des="";
                        string hest = "";
                        string tipo = "";
                        string expl = "";
                        string resul = "";
                        foreach (XmlNode nodo in hijos)
                        {
                            
                            if (nodo.Name.Equals("descripcion"))
                            {
                                des = nodo.InnerText;
                            }
                            if (nodo.Name.Equals("hestimadas"))
                            {
                                hest = nodo.InnerText;
                            }
                            if (nodo.Name.Equals("tipotarea"))
                            {
                                tipo = nodo.InnerText;
                            }
                            if (nodo.Name.Equals("explotacion"))
                            {
                                expl = nodo.InnerText;
  
                            }
                        }
                        var logica = new LogicaNegocio.LogicaNegocio();
                        try
                        {
                            resul =logica.addTarea(cod, des, DropDownList1.SelectedValue, Int32.Parse(hest), Convert.ToBoolean(expl), tipo);
                            Label1.Text = resul;
                        }
                        catch
                        {
                            Label1.Text = resul;
                        }
                        
                        


                    }              
                }
                else
                {
                    Label1.Text = "No existe un xml de esas asignaturas";
                }

            }
        }
    }
}