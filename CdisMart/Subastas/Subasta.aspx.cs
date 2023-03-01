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
    
    public partial class Subasta : System.Web.UI.Page
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
                    //Page.Theme = "Tema3";
                    int id = int.Parse(Request.QueryString["AuctionId"]);
                    cargarSubasta(id);
                    
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            

        }


        protected void btnOferta_Click(object sender, EventArgs e)
        {
            int idSubasta = int.Parse(Request.QueryString["AuctionId"]);
            agregarRecord(idSubasta);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Oferta realizada')", true);
            Response.Redirect("~/Subastas/Lista_de_subasta.aspx");
        }

    

        public void cargarSubasta(int id)
        {
            AuctionBLL auction = new AuctionBLL();
            Auction subasta = new Auction();
            UserBLL aux = new UserBLL();
            Users usuario = new Users();
            try
            {
                subasta = auction.cargarSubasta(id);
                int winner = (int)subasta.Winner;
                usuario = aux.cargarUserName(winner);
                int usuarioLogeado = (int)Session["ID"];
                DateTime fechaFin = DateTime.Now;

                lblNumSubasta.Text = subasta.AuctionId.ToString();
                lblNombreProducto.Text = subasta.ProductName.ToString();
                lblDescripcion.Text = subasta.Description.ToString();
                lblFechaInicio.Text = subasta.StartDate.ToString();
                lblFechaFin.Text = subasta.EndDate.ToString();
                lblOfertaAlta.Text = subasta.HighestBid.ToString();
                lblUsuarioOfertaAlta.Text = usuario.UserName.ToString();

                if (usuarioLogeado == subasta.UserId)
                {
                    txtOferta.Enabled = false;
                    btnOferta.Enabled = false;
                    throw new Exception("No se le permite ofertar en esta subasta");

                }

                if (fechaFin>subasta.EndDate)
                {
                    txtOferta.Enabled = false;
                    btnOferta.Enabled = false;
                    throw new Exception("La subasta ha finalizado");

                }
            }
            catch(Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + e.Message + "')", true);
            }
            
        }

        public void agregarRecord(int idSubasta)
        {
            AuctionRecordBLL historial = new AuctionRecordBLL();
            AuctionRecord record = new AuctionRecord();
            
            Auction subasta = new Auction();///////////////////////
            AuctionBLL auction = new AuctionBLL();//////////////////
            AuctionBLL aux = new AuctionBLL();//////////////////
            subasta = auction.cargarSubasta(idSubasta);////////////
            decimal ofertaMasAlta = (decimal)subasta.HighestBid;
            
            try
            {
                record.AuctionId = idSubasta;
                record.BidDate = DateTime.Now;
                record.UserId = (int)Session["ID"];

                int ofertaUser = int.Parse(txtOferta.Text);
                DateTime ahora = DateTime.Now;
                int usuarioLogeado = (int)Session["ID"];
                

               /* lblOferta.Text = ofertaUser.ToString();
                Label1.Text = ofertaMasAlta.ToString();
                */
                if (ofertaUser > 0 && ofertaUser < 1000000)
                {
                    if (ofertaUser > ofertaMasAlta)
                    {
                        record.Amount = ofertaUser;
                        historial.agregarRecord(record);
                        aux.modificarSubastaOfertaMasAlta(idSubasta, ofertaUser, usuarioLogeado);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Oferta realizada')", true);
                    }
                    else
                    {
                        throw new Exception("La oferta debe ser mayor que la oferta actual");
                    }
                }
                else
                {
                    throw new Exception("Oferta fuera de la cantidad permitida (1-1,000,000)");
                }
            }catch(Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('"+e.Message+"')", true);
            }
            
            
            //MODIFICAR PROCEDIMIENTOS CON TRANSACTIONS

        }
        /*
        public DateTime obtenerFechaFin(int id)
        {
            //modificar el registro de subasta por si cambia el monto
            //de la oferta más alta
            //
            //tambien se hace una busqueda del registro con el monto mas alto
            //como parametro, (busqueda en la tabla de AuctionRecord y se muestra
            //el usuario correspondiente al monto

            AuctionBLL auction = new AuctionBLL();
            Auction subasta = new Auction();

            subasta = auction.cargarSubasta(id);

            return subasta.EndDate;

        }

        public int obtenerCreador(int AuctionId)
        {
            AuctionBLL auction = new AuctionBLL();
            Auction subasta = new Auction();

            subasta = auction.cargarSubasta(AuctionId);

            return subasta.UserId;
        }

        public void modificarSubastaOfertaMasAlta(int AuctionId, int HighestBid, int Winner)
        {
            AuctionBLL auction = new AuctionBLL();
            
            auction.modificarSubastaOfertaMasAlta(AuctionId, HighestBid, Winner);
        }

        public Auction cargarObjetoSubasta(int id)
        {
            Auction subasta = new Auction();
            AuctionBLL auction = new AuctionBLL();

            subasta = auction.cargarSubasta(id);

            return subasta;
        }
        */
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

        
    }
}