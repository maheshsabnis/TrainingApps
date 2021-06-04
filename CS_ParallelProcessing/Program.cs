using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CS_ParallelProcessing.Models;
using System.Diagnostics;
namespace CS_ParallelProcessing
{
	class Program
	{
		static void Main(string[] args)
		{
			EmployeesDb database = new EmployeesDb();
			Console.WriteLine($"Sequential Operation starts at {DateTime.Now.ToString()}");
			var sequential = Stopwatch.StartNew();
			for (int i = 0; i < database.Count; i++)
			{
				ProcessTax.CalculateTax(database[i]);
				Console.WriteLine($"Tax for {database[i].EmpNo} {database[i].EmpName} is {database[i].Tax}");
			}
			Console.WriteLine($"Total Time to Calculate the Tax for all employees = {sequential.Elapsed.TotalMilliseconds}");

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Using Parallel Processing");
			var parallel = Stopwatch.StartNew();

			Parallel.For(0, database.Count, i =>
			{
				ProcessTax.CalculateTax(database[i]);
				Console.WriteLine($"Tax for {database[i].EmpNo} {database[i].EmpName} is {database[i].Tax}");
			});
			Console.WriteLine($"Total Time to Calculate the Tax for all employees parallely = {parallel.Elapsed.TotalMilliseconds}");
			Console.ReadLine();
		}
	}

	public static class ProcessTax
	{
		public static Employee CalculateTax(Employee e)
		{
			Thread.Sleep(1000);
			if (e.DeptNo == 20 || e.DeptNo == 40)
			{
				e.Tax = e.Salary * Convert.ToDecimal(0.4);
			}
			else
			{
				e.Tax = e.Salary * Convert.ToDecimal(0.2);
			}
			
			return e;
		}
	}
}
