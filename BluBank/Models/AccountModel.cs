using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluBank.Models
{
    public class AccountModel
    {
        private string id1;
        private int balance1;
        private DateTime date_created1;
        private DateTime date_updated1;

        public String id { get => id1; set => id1 = value; }
        public int balance { get => balance1; set => balance1 = value; }
        public DateTime date_created { get => date_created1; set => date_created1 = value; }
        public DateTime date_updated { get => date_updated1; set => date_updated1 = value; }
    }
}