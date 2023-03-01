using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CdisMart_DAL;
using System.Transactions;

namespace CdisMart_BLL
{
    public class AuctionBLL
    {
        public void agregarAuction(Auction auction)
        {
            AuctionDAL subasta = new AuctionDAL();
            
            DateTime fechaActual = DateTime.Today;

            if (auction.StartDate >= fechaActual)
            {
                if (auction.EndDate > auction.StartDate)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        subasta.agregarAuction(auction);
                        ts.Complete();
                    }
                }
                else
                {
                    throw new Exception("La fecha de fin debe ser mayor a la de inicio");
                }
            }
            else
            {
                throw new Exception("La fecha de inicio debe ser mayor o igual a la actual");
            }
            
        }

        public List<Object> cargarSubastas()
        {
            AuctionDAL subasta = new AuctionDAL();
            return subasta.cargarSubastas();
        }

        public Auction cargarSubasta(int id)
        {
            AuctionDAL subasta = new AuctionDAL();
            return subasta.cargarSubasta(id);
        }

        public List<Object> cargarSubastasPorUser(int id)
        {
            AuctionDAL subasta = new AuctionDAL();
            return subasta.cargarSubastasPorUser(id);
        }

        public void modificarSubastaOfertaMasAlta(int idAuction, int oferta, int winner)
        {
            using(TransactionScope ts= new TransactionScope())
            {
                AuctionDAL subasta = new AuctionDAL();
                subasta.modificarSubastaOfertaMasAlta(idAuction, oferta, winner);
                ts.Complete();
            }
            
        }

        public DataTable cargarSubastasTabla()
        {
            AuctionDAL subasta = new AuctionDAL();
            return subasta.cargarSubastasTabla();
        }

    }
}
