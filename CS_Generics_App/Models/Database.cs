using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Generics_App.Models
{
	public class DepartmentsDb : List<Department>
	{
		public DepartmentsDb()
		{
			Add(new Department() {DeptNo=10,DeptName="IT", Location="Pune",Capacity=200 });
		}
	}

	public class EmployeesDb : List<Employee>
	{
		public EmployeesDb()
		{
			Add(new Employee() { EmpNo=101,EmpName="Mahesh", Salary=23000,  DeptNo=10});
		}
	}
		
}
