using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_LINQ.Models
{
	public class DepartmentsDb : List<Department>
	{
		public DepartmentsDb()
		{
			Add(new Department() {DeptNo=10,DeptName="IT", Location="Pune",Capacity=200 });
			Add(new Department() { DeptNo = 20, DeptName = "HR", Location = "Pune", Capacity = 20 });
			Add(new Department() { DeptNo = 30, DeptName = "TR", Location = "Pune", Capacity = 40 });
			Add(new Department() { DeptNo = 40, DeptName = "SL", Location = "Pune", Capacity = 10 });
			Add(new Department() { DeptNo = 50, DeptName = "SYS", Location = "Pune", Capacity = 40 });
			Add(new Department() { DeptNo = 60, DeptName = "Warehouse", Location = "Pune", Capacity = 100 });
		}
	}

	public class EmployeesDb : List<Employee>
	{
		public EmployeesDb()
		{
			Add(new Employee() { EmpNo=101,EmpName="Mahesh", Salary=23001,  DeptNo=10});
			Add(new Employee() { EmpNo = 102, EmpName = "Vikram", Salary = 23002, DeptNo = 20 });
			Add(new Employee() { EmpNo = 103, EmpName = "Suprotim", Salary = 23003, DeptNo = 30 });
			Add(new Employee() { EmpNo = 104, EmpName = "Subodh", Salary = 23004, DeptNo = 40 });
			Add(new Employee() { EmpNo = 105, EmpName = "Vikas", Salary = 23005, DeptNo = 10 });
			Add(new Employee() { EmpNo = 106, EmpName = "Manish", Salary = 23006, DeptNo = 20 });
			Add(new Employee() { EmpNo = 107, EmpName = "Tejas", Salary = 23007, DeptNo = 30 });
			Add(new Employee() { EmpNo = 108, EmpName = "Gajanan", Salary = 23008, DeptNo = 40 });
			Add(new Employee() { EmpNo = 109, EmpName = "Deepak", Salary = 23009, DeptNo = 10 });
			Add(new Employee() { EmpNo = 110, EmpName = "Nitin", Salary = 23001, DeptNo = 20 });
			Add(new Employee() { EmpNo = 111, EmpName = "Ajay", Salary = 23002, DeptNo = 30 });
			Add(new Employee() { EmpNo = 112, EmpName = "Suraj", Salary = 23003, DeptNo = 40 });
			Add(new Employee() { EmpNo = 113, EmpName = "Akash", Salary = 23004, DeptNo = 10 });
			Add(new Employee() { EmpNo = 114, EmpName = "Mukesh", Salary = 23004, DeptNo = 20 });
			Add(new Employee() { EmpNo = 115, EmpName = "Vivek", Salary = 23006, DeptNo = 30 });
			Add(new Employee() { EmpNo = 116, EmpName = "Satish", Salary = 23007, DeptNo = 40 });
		}
	}
		
}
