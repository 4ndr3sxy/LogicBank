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
            logLog4Net.log.Info("Ingreso a GET(string id) en Account con valor de id="+id);
            //repository added to erre in loop of references between user and account
            Repository r = new Repository();
            return r.getAccount(id).ToList().Select(x => _mf.CreateA(x));
        }

        //Add new Account
        [HttpPost]
        public IHttpActionResult AddAccount([FromBody]account acc)
        {
            logLog4Net.log.Info("Ingreso a POST([FromBody]account acc) en Account con informacion:" +
                "\n id:"+acc.id+"\n saldo:"+acc.balance + "\n cuenta de id:"+ acc.fk_user_id +"\n fecha creado:" + acc.date_created + 
                "\n fecha actualizacion:" +acc.date_updated);
            if (ModelState.IsValid)
            {
                dbContext.accounts.Add(acc);
                dbContext.SaveChanges();
                logLog4Net.log.Info("Cuenta con id " +acc.id+ " agregado exitosamente");
                return Ok(acc);
            }
            else
            {
                logLog4Net.log.Error("Error al agregar nueva cuenta "+BadRequest().ToString());
                return BadRequest();
            }
        }

        //update account
        [HttpPut]
        public IHttpActionResult UpdateAccount(string id, [FromBody] AccountTransactionModel accT)
        {
            logLog4Net.log.Info("Ingreso a PUT(string id, [FromBody] AccountTransactionModel accT) en Account con informacion:" +
                "\n tipo transaccion:" + accT.TypeT + "\n cantidad dinero:" + accT.Money);
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
                        if(accountObj.balance > accT.Money && accT.Money >= 10000)
                        {
                            accountObj.balance -= accT.Money;
                        }
                        else
                        {
                            logLog4Net.log.Error("Monto a retirar mayor al dinero en cuenta o retiro menor al establecido.\n" +
                                " Error en cuenta id: " + id);
                            return NotFound();
                        }
                        
                        break;
                    default:
                        logLog4Net.log.Error("Tipo de transaccion incorrecta para id:"+id);
                        return NotFound();
                }
                //update
                dbContext.Entry(accountObj).State = EntityState.Modified;
                dbContext.SaveChanges();
                logLog4Net.log.Info("PUT realizado exitosamente de id:" + id);
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
