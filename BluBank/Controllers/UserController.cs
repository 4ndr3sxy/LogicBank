using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConnectDataBase;

namespace BluBank.Controllers
{
    public class UserController : ApiController
    {
        private db_blue_bankEntities dbContext = new db_blue_bankEntities();
    }
}
