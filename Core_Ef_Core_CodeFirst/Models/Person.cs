using System;
using System.Collections.Generic;
using System.Text;

namespace Core_Ef_Core_CodeFirst.Models
{
	/// <summary>
	/// Entity class
	/// </summary>
	public class Person
	{
		public int PersonId { get; set; }
		public string PersonName { get; set; }
		public int Age { get; set; }
		private string Email;

		public void SetEmail(string email)
		{
			Email = email;
		}

		public string GetEmail()
		{
			return Email;
		}
	}
}
