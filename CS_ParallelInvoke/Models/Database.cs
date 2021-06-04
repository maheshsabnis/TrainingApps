using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ParallelInvoke.Models
{
	 
	public class EmployeesDb : List<Employee>
	{
		public EmployeesDb()
		{
			Add(new Employee() { EmpNo=101,EmpName="Mahesh", Salary=23000,  DeptNo=10});
			Add(new Employee() { EmpNo = 102, EmpName = "Vikram", Salary = 33000, DeptNo = 20 });
			Add(new Employee() { EmpNo = 103, EmpName = "Suprotim", Salary = 53003, DeptNo = 30 });
			Add(new Employee() { EmpNo = 104, EmpName = "Subodh", Salary = 28004, DeptNo = 40 });
			Add(new Employee() { EmpNo = 105, EmpName = "Vikas", Salary = 49005, DeptNo = 10 });
			Add(new Employee() { EmpNo = 106, EmpName = "Manish", Salary = 56006, DeptNo = 20 });
			Add(new Employee() { EmpNo = 107, EmpName = "Tejas", Salary = 32007, DeptNo = 30 });
			Add(new Employee() { EmpNo = 108, EmpName = "Gajanan", Salary = 89008, DeptNo = 40 });
			Add(new Employee() { EmpNo = 109, EmpName = "Deepak", Salary = 45009, DeptNo = 10 });
			Add(new Employee() { EmpNo = 110, EmpName = "Nitin", Salary = 54001, DeptNo = 20 });
			Add(new Employee() { EmpNo = 111, EmpName = "Ajay", Salary = 78002, DeptNo = 30 });
			Add(new Employee() { EmpNo = 112, EmpName = "Suraj", Salary = 87003, DeptNo = 40 });
			Add(new Employee() { EmpNo = 113, EmpName = "Akash", Salary = 16004, DeptNo = 10 });
			Add(new Employee() { EmpNo = 114, EmpName = "Mukesh", Salary = 96004, DeptNo = 20 });
			Add(new Employee() { EmpNo = 115, EmpName = "Vivek", Salary = 69006, DeptNo = 30 });
			Add(new Employee() { EmpNo = 116, EmpName = "Satish", Salary = 47007, DeptNo = 40 });
		}
	}
		
}
