using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Generics_App.Models;
namespace CS_Generics_App.Services
{
	public class EmployeeService : IService<Employee, int>
	{
		private EmployeesDb database;

		public EmployeeService()
		{
			database = new EmployeesDb();
		}

		public Employee Create(Employee model)
		{
			database.Add(model);
			return model;
		}

		public Employee Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Employee> Get()
		{
			return database;
		}

		public Employee Get(int id)
		{
			throw new NotImplementedException();
		}

		public Employee Update(int id, Employee model)
		{
			throw new NotImplementedException();
		}
	}
}
