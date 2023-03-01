using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CdisMart_DAL
{
    public class AuctionDAL
    {
        CdisMartEntities modelo;
        public AuctionDAL()
        {
            modelo = new CdisMartEntities();
        }

        public void agregarAuction(Auction auction)
        {
            modelo.Auction.Add(auction);
            modelo.SaveChanges();
        }

        public List<Object> cargarSubastas()
        {
            var subastas = from mSubastas in modelo.Auction
                           
                           select new
                           {
                               AuctionId = mSubastas.AuctionId,
                               ProductName = mSubastas.ProductName,
                               Description = mSubastas.Description,
                               StartDate = mSubastas.StartDate,
                               EndDate = mSubastas.EndDate,
                               HighestBid = mSubastas.HighestBid,
                               Winner = mSubastas.Winner,
                               UserId = mSubastas.UserId
                           };
            return subastas.AsEnumerable<Object>().ToList();

        }

        public Auction cargarSubasta(int id)
        {
            var subasta = (from mSubastas in modelo.Auction
                           where mSubastas.AuctionId == id
                           select mSubastas).FirstOrDefault();

            return subasta;
        }

        public List<Object> cargarSubastasPorUser(int id)
        {
            var subastas = from mSubastas in modelo.Auction
                           where mSubastas.UserId == id
                           select mSubastas;

            return subastas.AsEnumerable<Object>().ToList();
        }

        public void modificarSubastaOfertaMasAlta(int idAuction, int oferta,int winner)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=CdisMart;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_modificarSubastaOfertaMasAlta";
            command.Connection = connection;

            command.Parameters.AddWithValue("pIdAuction", idAuction);
            command.Parameters.AddWithValue("pHighestBid", oferta);
            command.Parameters.AddWithValue("pWinner", winner);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

        }
    
        public DataTable cargarSubastasTabla()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=CdisMart;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarSubastasTabla";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtSubastas = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtSubastas);

            connection.Close();

            return dtSubastas;
        }
    
    
    }
}
