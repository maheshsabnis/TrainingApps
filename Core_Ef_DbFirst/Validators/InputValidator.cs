using System;
using System.Collections.Generic;
using System.Text;
using Core_Ef_DbFirst.Models;
namespace Core_Ef_DbFirst.Validators
{
	public static class InputValidator
	{
		public static List<string> DeptValidator(Department department)
		{
			List<string> errors = new List<string>();

			if (department.DeptNo == String.Empty)
				errors.Add("DeptNo is Must");

			return errors;
		}
	}
}
