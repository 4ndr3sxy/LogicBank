using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConnectDataBase;

namespace BluBank.Models
{
    public class ModelFactory
    {
        public UserModel Create(user usr)
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

            };
        }
    }
}