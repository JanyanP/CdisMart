using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CdisMart
{
    public class TemaCdisMart: System.Web.UI.Page
    {
        protected void Page_PreInit(object sender,EventArgs e)
        {
            if (HttpContext.Current.Request.Url.AbsoluteUri== "https://localhost:44340/Subastas/Lista_de_subasta")
            {
                Page.Theme = "Tema1";
            }
            
        }
        /*
        protected void Page_PreInit2(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Page.Theme = "Tema2";
            }

        }

        protected void Page_PreInit3(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Page.Theme = "Tema3";
            }

        }*/
    }
}