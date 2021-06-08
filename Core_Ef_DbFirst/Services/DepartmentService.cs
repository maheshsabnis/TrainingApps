using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core_Ef_DbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Ef_DbFirst.Services
{
	public class DepartmentService : IService<Department, int>
	{
		private CitusTrgContext context;

		public DepartmentService()
		{
			context = new CitusTrgContext();
		}

		public async Task<Department> CreateAsync(Department entity)
		{
			try
			{
				// The value of newly created entity will be returned
				var res = await context.Department.AddAsync(entity);
				await context.SaveChangesAsync();
				return res.Entity; // newly created entity object
			}
			catch (Exception ex)
			{
				// throw
				throw ex;
			}
		}

		public async Task<bool> DeleteAsync(int id)
		{
			try
			{
				// search record
				var recordToDelete = await context.Department.FindAsync(id);
				if (recordToDelete == null) return false; // record not found
														  // delete the record
				context.Department.Remove(recordToDelete);
				await context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<IEnumerable<Department>> GetAsync()
		{
			try
			{
				var result = await context.Department.ToListAsync();
				return result;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<Department> GetAsync(int id)
		{
			try
			{
				var result = await context.Department.FindAsync(id);
				return result;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<Department> UpdateAsync(int id, Department entity)
		{
			try
			{
				var result = await context.Department.FindAsync(id);
				if (result == null) throw new Exception($"Record not found, update operation is failed");

				result.DeptUniqueId = entity.DeptUniqueId;
				result.DeptNo = entity.DeptNo;
				result.DeptName = entity.DeptName;
				result.Location = entity.Location;

				// modify the record 
				//context.Entry(result).State = EntityState.Modified;
				await context.SaveChangesAsync();
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
