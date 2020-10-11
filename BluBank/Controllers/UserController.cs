using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConnectDataBase;
using BluBank.Models;
using System.Data.Entity;

namespace BluBank.Controllers
{
    public class UserController : ApiController
    {
        private db_blue_bankEntities dbContext = new db_blue_bankEntities();
        ModelFactory _mf;

        public UserController()
        {
            _mf = new ModelFactory();
        }

        //get users createds
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            Repository r = new Repository();
            return r.getUsers().ToList().Select(x => _mf.Create(x));
        }

        [HttpGet]
        public IEnumerable<UserModel> Get(string id)
        {
            Repository r = new Repository();
            return r.getUser(id).ToList().Select(x => _mf.Create(x));
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

        [HttpPut]
        public IHttpActionResult UpdateUser(String id,[FromBody] user usr)
        {
            var getUser = dbContext.users.Count(x => x.id == id) > 0;

            if (getUser)
            {
                dbContext.Entry(usr).State = EntityState.Modified;
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
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
