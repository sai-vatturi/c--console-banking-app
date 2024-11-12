using System;
namespace CsharpConsoleBankingApplication
{
	public class User
	{
		// use encapsulation to secure credentials
		private string username;
		private string password;
		private List<Account> accounts;

		public User(string username, string password)
		{
			this.username = username;
			this.password = password;
			accounts = new List<Account>();
		}

		public void Display()
		{
			Console.WriteLine($"Username: {this.username} \n Password: {this.password}");
		}

	}
}

