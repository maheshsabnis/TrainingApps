using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_LINQ.Models;
namespace CS_LINQ
{
	class Program
	{
		static EmployeesDb employees = new EmployeesDb ();
		static DepartmentsDb departments = new DepartmentsDb();
		static void Main(string[] args)
		{
			// PrintEmployeesByDeptNo(10);

			// TogetherAllOperationsDeclarative(20);
			// TogetherAllOperationsImperative(30);
			//	WhereConditionLogicalOperators();
			// UsingGroupBy();
			// GetMaxSalary();
			// GetMaxSalaryGroupByDept();
			// UsingSimpleJoin();
			UsingInnerJoin();

			Console.ReadLine();
		}

		static void PrintEmployeesByDeptNo(int dno)
		{
			var res1 = employees.Where(e => e.DeptNo == dno);
			Console.WriteLine($"Employees by DeptNo is ={dno}");
			foreach (var item in res1)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptNo}");
			}
			Console.WriteLine();
			Console.WriteLine("Employeed by descending order by EmpNo");
			// soring all employees in descending order using the first result based on deptno
			var res2 = res1.OrderByDescending(e => e.EmpNo);
			foreach (var item in res2)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptNo}");
			}
			Console.WriteLine();
			Console.WriteLine("Show all employeed with EmpName as Uppercase");
			var res3 = res2.Select(e=>e.EmpName.ToUpper());
			foreach (var item in res3)
			{
				Console.WriteLine($"{item}");
			}
		}

		static void TogetherAllOperationsDeclarative(int dno)
		{
			var result = employees.Where(e => e.DeptNo == dno)
								  .OrderByDescending(e => e.EmpNo)
								  .Select(e => e);

			foreach (var item in result)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptNo}");
			}

		}


		static void TogetherAllOperationsImperative(int dno)
		{
			var result = from e in employees
						 where e.DeptNo == dno
						 orderby e.EmpNo descending
						 select e;
			foreach (var item in result)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptNo}");
			}
		}

		// using where condition with logical operators

		static void WhereConditionLogicalOperators()
		{
			var result = from e in employees
						 where e.Salary >= 23000 && e.Salary <= 23005
						 select e;
			foreach (var item in result)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptNo}");
			}
		}

		// using the group by
		static void UsingGroupBy()
		{
			var result = from e in employees
						 group e by e.DeptNo;
			// each group will have a key that is the property on which group is created

			foreach (var deptGroup in result)
			{
				Console.WriteLine($"Department Group {deptGroup.Key}");
				// iterate over each group
				foreach (var item in deptGroup)
				{
					Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptNo}");
				}
			}
		}

		static void GetMaxSalary()
		{
			var result = employees.Max(e => e.Salary);
			Console.WriteLine($"Max Salary = {result}");
		}

		// max salary for each department
		static void GetMaxSalaryGroupByDept()
		{
			var result = from e in employees
						 group e by e.DeptNo into DeptGroup
						 select new  // Anonymous Type
						 {
							 DeptNo = DeptGroup.Key,
							 Salary = DeptGroup.Max(e=>e.Salary)
						 };
			foreach (var item in result)
			{
				Console.WriteLine($"{item.DeptNo} {item.Salary}");
			}
		}

		// using Joins

		static void UsingSimpleJoin()
		{
			// Define the outer sequence, the collection from which reading will start
			// Define the inner sequence, the collection whihc will map / try to map entry from the outer collection

			var result = from d in departments // outer
						 from e in employees // inner
						 where d.DeptNo == e.DeptNo // property map from inner to outer seqiuence
						 select new
						 {
							 EmpNo = e.EmpNo,
							 EmpName = e.EmpName,
							 Salary = e.Salary,
							 DeptName = d.DeptName,
							 Location = d.Location
						 };

			foreach (var item in result)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptName} {item.Location}");
			}
		}

		// using the Join() method with 'join' as operator for
		// simple join

		static void UsingInnerJoin()
		{
			var result = from d in departments // outer
						 join e in employees // inner 
						 on d.DeptNo equals e.DeptNo  // key map
						 select new
						 {
							 EmpNo = e.EmpNo,
							 EmpName = e.EmpName,
							 Salary = e.Salary,
							 DeptName = d.DeptName,
							 Location = d.Location
						 };

			foreach (var item in result)
			{
				Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptName} {item.Location}");
			}
		}
	}
}
