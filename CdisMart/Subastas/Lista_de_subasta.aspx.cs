using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart.Subastas
{
    public partial class Lista_de_subasta : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "Tema1";

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    //Page.Theme = "Tema1";
                    //grd_subastas.DataSource = cargarSubastas();
                    //grd_subastas.DataBind();
                    //string url = HttpContext.Current.Request.Url.AbsolutePath;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('"+url+"')", true);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }


        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public List<Object> cargarSubastas()
        {
            AuctionBLL subasta = new AuctionBLL();
            List<object> listSubastas = new List<object>();

            listSubastas = subasta.cargarSubastas();

            return listSubastas;
        }

        protected void grd_subastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}