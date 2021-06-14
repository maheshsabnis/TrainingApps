using System;
using System.Collections.Generic;
using System.Text;
using CS_DB_Access.Models;
namespace CS_DB_Access
{
	public interface IService
	{
		bool GetCategory(int id);
	}

	/// <summary>
	/// The Dal is dependant on the CitusTrainingContext
	/// This means that to instantiate the Dal we need an instance of CitusTrainingContext
	/// </summary>
	public class Dal : IService
	{
		CitusTrainingContext context;

		public Dal(CitusTrainingContext c)
		{
			context = c;
		}

		public bool GetCategory(int id)
		{
			var cat = context.Categories.Find(id);
			if (cat != null) return true;
			return false;
		}
	}
}
