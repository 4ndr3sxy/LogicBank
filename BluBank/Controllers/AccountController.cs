using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConnectDataBase;

namespace BluBank.Controllers
{
    public class AccountController : ApiController
    {
        private db_blue_bankEntities dbContext = new db_blue_bankEntities();

        //get Accounts createds
        [HttpGet]
        public IEnumerable<account> Get()
        {
            //return new string[] { "value1", "value2" };
            using (db_blue_bankEntities accountEntities = new db_blue_bankEntities())
            {
                return accountEntities.accounts.ToList();
            }
        }

        //Add new account
        [HttpPost]
        public IHttpActionResult AddAccount([FromBody]account acc)
        {
            if (ModelState.IsValid)
            {
                dbContext.accounts.Add(acc);
                dbContext.SaveChanges();
                return Ok(acc);
            }
            else
            {
                return BadRequest();
            }
        }

        //delete account
        [HttpDelete]
        public IHttpActionResult DeleteAccount(String id)
        {
            var acc= dbContext.accounts.Find(id);

            if (acc != null)
            {
                dbContext.accounts.Remove(acc);
                dbContext.SaveChanges();
                return Ok(acc);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
