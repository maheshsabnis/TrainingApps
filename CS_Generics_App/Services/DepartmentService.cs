using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Generics_App.Models;
namespace CS_Generics_App.Services
{
	/// <summary>
	/// Cohisive class that contians all operations for Same Model
	/// </summary>
	public class DepartmentService : IService<Department, int>
	{
		private DepartmentsDb database;

		public DepartmentService()
		{
			database = new DepartmentsDb();
		}

		public Department Create(Department model)
		{
			database.Add(model);
			return model;
		}

		public Department Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Department> Get()
		{
			return database.ToList();
		}

		public Department Get(int id)
		{
			throw new NotImplementedException();
		}

		public Department Update(int id, Department model)
		{
			throw new NotImplementedException();
		}
	}
}
