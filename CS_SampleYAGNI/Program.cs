using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SampleYAGNI
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public class AuthService
	{
		public bool Register(string uname, string pwd)
		{
			bool isCReated = true;

			// check fo non empty

			checkNullOrEMpty(uname);
			checkNullOrEMpty(pwd);


			checkUnameLength(uname);
			checkpwdlength(pwd);

			// logic for check uname as email, if not return false
			checkEmail(uname);
			// logic for usename exist, if already exist return false

			// logic for check strong pwd if not return false

			// logic for enctrupting pwd

			// register user



			return isCReated;

		}


		public bool Login(string uname, string pwd)
		{

			checkNullOrEMpty(uname);
			checkNullOrEMpty(pwd);

			return true;
		}


		public bool checkNullOrEMpty(string value)
		{
			if (string.IsNullOrEmpty(value)) return false;
			return true;
		}

		public bool checkUnameLength(string value)
		{
			if (value.Length < 10) return false;
			
			return true;
		}

		public bool checkpwdlength(string value)
		{
			if (value.Length < 8) return false;
			return true;
		}


		public bool checkEmail(string value)
		{
			// check if value is RegulaeExpression for email
			return true;
		}


	}
}
