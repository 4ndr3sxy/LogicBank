using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConnectDataBase;

namespace BluBank.Models
{
    public class ModelFactory
    {
        public UserModel CreateU(user usr)
        {
            return new UserModel()
            {
                id = usr.id,
                name = usr.name,
                last_name = usr.last_name,
                addres = usr.addres,
                phone = usr.phone,
                city = usr.city,
                country = usr.country,
                user_login = usr.user_login,
                password_login = usr.password_login,
                date_created =(DateTime) usr.date_created,
                date_updated =(DateTime) usr.date_updated,
                accounts = usr.accounts.Select(a => CreateA(a))
            };
        }

        public AccountModel CreateA(account acc)
        {
            return new AccountModel()
            {
                id = acc.id,
                balance = acc.balance,
                date_created = (DateTime)acc.date_created,
                date_updated = (DateTime)acc.date_updated
            };
        }
    }
}