using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart.Subastas
{
    public partial class Creacion_de_subasta : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "Tema3";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int activos = verificarNumSubastasUser();
                    if (activos >= 3)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Limite de subastas activas alcanzado')", true);
                        Response.Redirect("~/Subastas/Lista_De_subasta.aspx");
                    }
                    else
                    {
                        if (activos < 3)
                        {
                            //Page.Theme = "Tema3";
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
                
        }

        protected void btn_Crear_Click(object sender, EventArgs e)
        {

            agregarAuction();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Subasta registrada existosamente.')", true);
            limpiarCampos();
        }

        public int verificarNumSubastasUser()
        {
            int numSubastasActivas = 0;
            List<Object> listSubastasUser = new List<object>();
            AuctionBLL subastas = new AuctionBLL();
            int UserId = (int)(Session["ID"]);
            listSubastasUser = subastas.cargarSubastasPorUser(UserId);
            DateTime ahora = DateTime.Now;

            foreach(Auction registro in listSubastasUser)
            {
                if (registro.EndDate > ahora)
                {
                    numSubastasActivas = numSubastasActivas+1;
                }
            }

            return numSubastasActivas;

        }



        public void agregarAuction()
        {
            AuctionBLL subBLL = new AuctionBLL();
            Auction subasta = new Auction();

            subasta.ProductName = txtNombre.Text;
            subasta.Description = txtDescripcion.Text+" ";
            subasta.StartDate =Convert.ToDateTime(txtFechaInicio.Text);
            subasta.EndDate = Convert.ToDateTime(txtFechaFin.Text);
            subasta.UserId = (int)(Session["ID"]);
            subasta.HighestBid = 0;
            subasta.Winner = 2;

            try
            {
                subBLL.agregarAuction(subasta);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Subasta creada de manera exitosa')", true);
                limpiarCampos();

            }
            catch(Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + e.Message + "')", true);
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



        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
        }
    }
}