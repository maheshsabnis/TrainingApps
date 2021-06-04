using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ParallelInvoke.Models
{

	public abstract class Model
	{ }


	public class Department : Model
	{
		public int DeptNo { get; set; }
		public string DeptName { get; set; }
		public string Location { get; set; }
		public int Capacity { get; set; }
	}

	public class Employee : Model
	{
		public int EmpNo { get; set; }
		public string EmpName { get; set; }
		public int Salary { get; set; }
		public int DeptNo { get; set; }
		public decimal Tax { get; set; }
	}

	public class Customer
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
	}

}
