using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluBank.Models
{
	public class UserModel
	{
		private string id1;
		private string name1;
		private string last_name1;
		private string addres1;
		private string phone1;
		private string city1;
		private string country1;
		private string user_login1;
		private string password_login1;
		private DateTime date_created1;
		private DateTime date_updated1;

		public string id { get => id1; set => id1 = value; }
		public string name { get => name1; set => name1 = value; }
		public string last_name { get => last_name1; set => last_name1 = value; }
		public string addres { get => addres1; set => addres1 = value; }
		public string phone { get => phone1; set => phone1 = value; }
		public string city { get => city1; set => city1 = value; }
		public string country { get => country1; set => country1 = value; }
		public string user_login { get => user_login1; set => user_login1 = value; }
		public string password_login { get => password_login1; set => password_login1 = value; }
		public DateTime date_created { get => date_created1; set => date_created1 = value; }
		public DateTime date_updated { get => date_updated1; set => date_updated1 = value; }

		public IEnumerable<AccountModel> accounts { get; set; }
	}
}