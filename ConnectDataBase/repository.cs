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
            return ctx.users.Where(x => x.id == id).Select(x=>x);
        }

        public IQueryable<account> getAccount(String id)
        {
            db_blue_bankEntities ctx = new db_blue_bankEntities();
            return ctx.accounts.Where(x => x.id == id).Select(x => x);
        }
    }
}
