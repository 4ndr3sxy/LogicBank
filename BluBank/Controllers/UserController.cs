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

        //get users createds
        [HttpGet]
        public IEnumerable<user> Get()
        {
            using (db_blue_bankEntities userEntities = new db_blue_bankEntities())
            {
                return userEntities.users.ToList();
            }
        }

        //Add new user
        [HttpPost]
        public IHttpActionResult AddUser([FromBody]user usr)
        {
            if (ModelState.IsValid)
            {
                dbContext.users.Add(usr);
                dbContext.SaveChanges();
                return Ok(usr);
            }
            else
            {
                return BadRequest();
            }
        }

        //delete user
        [HttpDelete]
        public IHttpActionResult DeleteUser(String id)
        {
            var usr = dbContext.users.Find(id);

            if(usr != null)
            {
                dbContext.users.Remove(usr);
                dbContext.SaveChanges();
                return Ok(usr);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
