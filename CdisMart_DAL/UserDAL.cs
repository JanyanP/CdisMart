using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class UserDAL
    {
        CdisMartEntities modelo;

        public UserDAL()
        {
            modelo = new CdisMartEntities();
        }
        public Users consultarUser(string user)
        {
            var usuario = (from mUser in modelo.Users
                           where mUser.UserName == user
                           select mUser).FirstOrDefault();
            return usuario;
        }

        public void agregarUser(Users usuario)
        {
            modelo.Users.Add(usuario);
            modelo.SaveChanges();
        }

        public Users cargarUserName(int userId)
        {
            var usuario = (from mUser in modelo.Users
                           where mUser.UserId == userId
                           select mUser).FirstOrDefault();
            return usuario;
        }
    }
}
