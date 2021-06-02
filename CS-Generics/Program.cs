using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Generics
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> lstInt = new List<int>();
			lstInt.Add(10);
			lstInt.Add(20);
			lstInt.Add(30);
			foreach (var item in lstInt)
			{
				Console.WriteLine(item);
			}
			List<string> lstString = new List<string>();
			lstString.Add("Mahesh");
			lstString.Add("Vikram");
			lstString.Add("Suprotim");
			foreach (var item in lstString)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine(lstString.BinarySearch("Vikram"));

			List<Employee> lstEmp = new List<Employee>();
			lstEmp.Add(new Employee() { EmpNo=101,EmpName="A"});
			lstEmp.Add(new Employee() { EmpNo = 102, EmpName = "B" });
			lstEmp.Add(new Employee() { EmpNo = 103, EmpName = "C" });
			foreach (var item in lstEmp)
			{
				Console.WriteLine($"EmpNo = {item.EmpNo} and EmpName = {item.EmpName}");
			}


			GenericStack<int> stkInt = new GenericStack<int>();
			stkInt.Push(10);
			stkInt.Push(20);
			stkInt.Push(30);
			stkInt.Push(40);
			stkInt.Push(50);
			stkInt.List(); 
			Console.WriteLine($"Poped item {stkInt.Pop()}");
			Console.WriteLine("Remaining values");

			stkInt.List();

			Console.ReadLine();
		}
	}

	public class Employee
	{
		public int EmpNo { get; set; }
		public string EmpName { get; set; }
	}
}
