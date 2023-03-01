using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;
using System.Data;
using System.Transactions;

namespace CdisMart_BLL
{
    public class UserBLL
    {
        public void agregarUser(Users usuario)
        {
            using (TransactionScope ts= new TransactionScope())
            {
                UserDAL user = new UserDAL();
                user.agregarUser(usuario);
                ts.Complete();
            }
            
        }

        public Users consultarUser(string user)
        {
            UserDAL usuario = new UserDAL();
            return usuario.consultarUser(user);
        }

        public Users cargarUserName(int userId)
        {
            UserDAL usuario = new UserDAL();
            return usuario.cargarUserName(userId);
        }
    }
}
