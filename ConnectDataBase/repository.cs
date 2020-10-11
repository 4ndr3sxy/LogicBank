using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDataBase
{
    public class Repository
    {
        public IQueryable<user> getUsers()
        {
            db_blue_bankEntities ctx = new db_blue_bankEntities();
            return ctx.users;
        }

        public IQueryable<user> getUser(String id)
        {
            db_blue_bankEntities ctx = new db_blue_bankEntities();
            return ctx.users.Where(X => X.id == id).Select(x=>x);
        }
    }
}
