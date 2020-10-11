using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluBank.Models
{
    //object created to control of transacctions in accounts
    public class AccountTransactionModel
    {
        //encapsulation
        private string typeT;
        private int money;

        public string TypeT { get => typeT; set => typeT = value; }
        public int Money { get => money; set => money = value; }


        //posibility of creation of methods to consign, remove and more
    }
}