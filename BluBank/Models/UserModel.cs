using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluBank.Models
{
	public class UserModel
	{
		public string id { get; set; }
		public string name { get; set; }
		public string last_name { get; set; }
		public string addres { get; set; }
		public string phone { get; set; }
		public string city { get; set; }
		public string country { get; set; }
		public string user_login { get; set; }
		public string password_login { get; set; }
		public DateTime date_created { get; set; }
		public DateTime date_updated { get; set; }

		public IEnumerable<AccountModel> accounts { get; set; }
	}
}