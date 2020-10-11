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
    public class AccountController : ApiController
    {
        private db_blue_bankEntities dbContext = new db_blue_bankEntities();
        ModelFactory _mf;

        public AccountController()
        {
            _mf = new ModelFactory();
        }

        //get Account unique 
        [HttpGet]
        public IEnumerable<AccountModel> Get(string id)
        {
            Repository r = new Repository();
            return r.getAccount(id).ToList().Select(x => _mf.CreateA(x));
        }

        //Add new Account
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

        [HttpPut]
        public IHttpActionResult UpdateAccount(string id, string type, [FromBody] account acc)
        {
            Boolean getAccount = dbContext.accounts.Count(x => x.id == id) > 0;
            int nBalance = 0;
            
            if (getAccount)
            {
                IEnumerable<AccountModel> varAccounts = Get(id);
                AccountModel ac = varAccounts.First();
                nBalance = ac.balance;
                switch (type)
                {
                    case "c":
                        acc.balance = acc.balance + nBalance;
                        break;
                    case "r":
                        acc.balance = acc.balance - nBalance;
                        break;
                    default:
                        return NotFound();
                }
                dbContext.Entry(acc).State = EntityState.Modified;
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
        public IHttpActionResult DeleteUser(string id)
        {
            var usr = dbContext.users.Find(id);

            if (usr != null)
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
