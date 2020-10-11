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
        //creation model factory and context initial
        private db_blue_bankEntities dbContext = new db_blue_bankEntities();
        ModelFactory _mf;//ModelFactory intermediary between model of EF and Controller

        //builder
        public AccountController()
        {
            _mf = new ModelFactory();
        }

        //get Account unique 
        [HttpGet]
        public IEnumerable<AccountModel> Get(string id)
        {
            //repository added to erre in loop of references between user and account
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

        //update account
        [HttpPut]
        public IHttpActionResult UpdateAccount(string id, [FromBody] AccountTransactionModel accT)
        {
            Boolean getAccount = dbContext.accounts.Count(x => x.id == id) > 0;

            if (getAccount)
            {
                //get account to update
                account accountObj = dbContext.accounts.Find(id);

                //scaled to more options
                switch (accT.TypeT)
                {
                    //consign
                    case "c":
                        accountObj.balance += accT.Money;
                        break;
                    //remove
                    case "r":
                        accountObj.balance -= accT.Money ;
                        break;
                    default:
                        return NotFound();
                }
                //update
                dbContext.Entry(accountObj).State = EntityState.Modified;
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //delete account
        [HttpDelete]
        public IHttpActionResult DeleteAccount(string id)
        {
            //get account
            var usr = dbContext.accounts.Find(id);

            if (usr != null)
            {
                //delete
                dbContext.accounts.Remove(usr);
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
