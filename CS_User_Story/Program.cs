using System;
using System.Collections.Generic;
namespace CS_User_Story
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		
	}

	public class AuthService
	{

		public string Login(string uname, string pwd)
		{
			if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pwd))
			{
				return "User Name or Pasword can ot be null or empty";
			}
			else
			{ 
				if(uname == "Mahesh" && pwd == "mahesh")
				{
					return "Login Successful";
				}
				return "Incorrect User Name or Password";
			}
		}

		public bool AuthUser(string uname, string pwd)
		{
			UsersDb db = new UsersDb();
			bool isAuthenticated = false;

			var user = db.Find(x => x.UserName == uname);
			if (user == null)
			{
				return isAuthenticated;
			}
			if (user.Password.Trim() != pwd.Trim())
			{
				return isAuthenticated;
			}

			isAuthenticated = true;


			return isAuthenticated;
		}

	}


	public class User
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}


	public class UsersDb : List<User>
	{
		public UsersDb()
		{
			Add(new User() { UserName="Mahesh", Password="mahesh"});
			Add(new User() { UserName = "Tejas", Password = "tejas" });
			Add(new User() { UserName = "Vivek", Password = "vivek" });
			Add(new User() { UserName = "Satish", Password = "satish" });
			Add(new User() { UserName = "Mukesh", Password = "mukesh" });
			Add(new User() { UserName = "Sandeep", Password = "sandeep" });
			Add(new User() { UserName = "Vinay", Password = "vinay" });
			Add(new User() { UserName = "Tushar", Password = "tusjar" });
		}
	}



	public class Calculator
	{
		public int Add(int a, int b)
		{
			return a + b;
		}

		public int Divide(int a, int b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException("Denominator cannot be zero");
			}
			if (a == 0)
			{
				return 0;
			}

			return a / b;
		}
	}

	public class EmployeeDetails
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Salary { get; set; }
	}
}
