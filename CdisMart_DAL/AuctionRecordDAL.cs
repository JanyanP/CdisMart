using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class AuctionRecordDAL
    {
        CdisMartEntities modelo;

        public AuctionRecordDAL()
        {
            modelo = new CdisMartEntities();
        }

        public void agregarRecord(AuctionRecord record)
        {
            modelo.AuctionRecord.Add(record);
            modelo.SaveChanges();
        }

        public List<Object> cargarHistorial(int id)
        {
            var subastas = from mSubastas in modelo.AuctionRecord
                           where mSubastas.AuctionId == id
                           select new
                           {
                               RecordId = mSubastas.RecordId,
                               AuctionId = mSubastas.AuctionId,
                               UserId=mSubastas.UserId,
                               Amount=mSubastas.Amount,
                               BidDate=mSubastas.BidDate,
                               UserName=mSubastas.Users.UserName
                           };

            return subastas.AsEnumerable<Object>().ToList();
        }

        public List<Object> cargarHistorialPorUser(int idSubasta, int idUser)
        {
            var subastas = from mSubastas in modelo.AuctionRecord
                           where mSubastas.AuctionId == idSubasta && mSubastas.UserId==idUser
                           select mSubastas;

            return subastas.AsEnumerable<Object>().ToList();
        }

    }
}
