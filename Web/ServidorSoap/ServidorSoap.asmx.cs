using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServidorSoap
{
    /// <summary>
    /// Descripción breve de ServidorSoap
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServidorSoap : System.Web.Services.WebService
    {
        private BaseDatos.BaseDatos bd = new BaseDatos.BaseDatos();
        [WebMethod]
        public string getTimes(string cod)
        {
            bd.conectar();
            string resul= bd.getTimes(cod);
            bd.cerrarconexion();
            return resul;
        }
    }
}
