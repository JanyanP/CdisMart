using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;
using System.Transactions;

namespace CdisMart_BLL
{
    public class AuctionRecordBLL
    {
        public void agregarRecord(AuctionRecord record)
        {
            using(TransactionScope ts= new TransactionScope())
            {
                AuctionRecordDAL historial = new AuctionRecordDAL();
                historial.agregarRecord(record);
                ts.Complete();
            }
        }

        public List<Object> cargarHistorial(int id)
        {
            AuctionRecordDAL historial = new AuctionRecordDAL();
            return historial.cargarHistorial(id);
        }

        public List<Object> cargarHistorialPorUser(int idSubasta, int idUser)
        {
            AuctionRecordDAL historial = new AuctionRecordDAL();
            return historial.cargarHistorialPorUser(idSubasta, idUser);
        }
    }

}
