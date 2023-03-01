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
    public partial class Historial : System.Web.UI.Page
    {
        private double suma = 0;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "Tema2";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    //Page.Theme = "Tema2";
                    int IdSubasta = int.Parse(Request.QueryString["AuctionId"]);
                    cargarSubasta(IdSubasta);
                    //grd_historial.DataSource = cargarHistorial(IdSubasta);
                    //grd_historial.DataBind();
                    //sumarMontos(IdSubasta);
                    
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }


        public List<Object> cargarHistorial(int SubastaId)
        {
            AuctionRecordBLL historial = new AuctionRecordBLL();
            List<object> listHistorial = new List<object>();

            listHistorial = historial.cargarHistorial(SubastaId);

            return listHistorial;
        }

        public void cargarSubasta(int id)
        {
            AuctionBLL auction = new AuctionBLL();
            Auction subasta = new Auction();
            try
            {
                subasta = auction.cargarSubasta(id);
                
                lblNombreProducto.Text = subasta.ProductName.ToString();
                lblDescripcion.Text = subasta.Description.ToString();
                Label1.Text = subasta.AuctionId.ToString();



            }
            catch (Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + e.Message + "')", true);
            }

        }

        public void sumarMontos(int IdSubasta)
        {
            decimal total = 0;
            decimal monto=0;
            string valor="";
                
            foreach(GridViewRow row in grd_historial.Rows)
            {
                valor = row.Cells[1].Text;
                monto = decimal.Parse(valor);
                total = total + monto;
            }

            lblTotal.Text = total.ToString();
            
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

        protected void grd_historial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                suma = suma + double.Parse(e.Row.Cells[1].Text);

            }
            else
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Total: ";
                    e.Row.Cells[1].Text = suma.ToString();
                }
            }
        }
    }
}