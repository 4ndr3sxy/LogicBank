using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluBank.Models
{
    public class AccountModel
    {
        public String id { get; set; }
        public int balance { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
    }
}