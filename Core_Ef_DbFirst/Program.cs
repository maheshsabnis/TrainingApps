using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Ef_DbFirst.Models;
using Core_Ef_DbFirst.Services;
using Core_Ef_DbFirst.Validators;

namespace Core_Ef_DbFirst
{
	class Program
	{
		static async Task Main(string[] args)
		{

			IService<Department, int> serv = new DepartmentService();

			// 1. Printing all records
			try
			{

				var depts = await serv.GetAsync();

				foreach (var item in depts.ToList())
				{
					Console.WriteLine($"{item.DeptUniqueId} {item.DeptNo} {item.DeptName} {item.Location}");
				}

				var newDept = new Department()
				{
					DeptUniqueId = 3,
					DeptNo = "Dept-30",
					DeptName = "SALES",
					Location = "Mumbai-Dadar-West"
				};
				if (InputValidator.DeptValidator(newDept).Count == 0)
				{ 
				
				}
				//newDept = await serv.CreateAsync(newDept);

				//Console.WriteLine("After adding new Record");

				// await serv.UpdateAsync(newDept.DeptUniqueId, newDept);


				await serv.DeleteAsync(newDept.DeptUniqueId);


				depts = await serv.GetAsync();

				foreach (var item in depts.ToList())
				{
					Console.WriteLine($"{item.DeptUniqueId} {item.DeptNo} {item.DeptName} {item.Location}");
				}

			}
			catch (Exception ex)
			{
					Console.WriteLine($"Error Occured {ex.Message}");
			}

			Console.ReadLine();
		}
	}
}
