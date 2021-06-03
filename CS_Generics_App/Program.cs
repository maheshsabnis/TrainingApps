using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Generics_App.Models;
using CS_Generics_App.Services;
namespace CS_Generics_App
{
	class Program
	{
		static void Main(string[] args)
		{
			IService<Department, int> deptServ = new DepartmentService();


			deptServ.Create(new Department() {DeptNo=20,DeptName="HR",Location="Mumbai", Capacity=20 });

			var depts = deptServ.Get();

			foreach (var item in depts)
			{
				Console.WriteLine($"{item.DeptNo} {item.DeptName} {item.Location} {item.Capacity}");
			}

			IService<Employee, int> empServ = new EmployeeService();

		 

			  



			Console.ReadLine();
		}
	}
}
