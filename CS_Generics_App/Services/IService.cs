using CS_Generics_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Generics_App.Services
{
	/// <summary>
	/// Multi-Type Generic
	/// </summary>
	/// <typeparam name="TModel">Is the Model class 
	/// e.g. Department, Employee on Which CRUD operations are performed
	/// The TModel will always be a class</typeparam>
	/// <typeparam name="TKey">The 'in' means input type parameter to a method, that will 
	/// be a Key using which recome can be updated, Deleted, Searched like Primary key </typeparam>
	//public interface IService<TModel, in TKey> where TModel : class // constraints, the TModel will be only of typeof Model base class
	public interface IService<TModel, in TKey> where TModel : Model
	{
		// Read all records from Collections
		IEnumerable<TModel> Get();
		// Read a single record based on Key
		TModel Get(TKey id);
		// CReate a new Record
		TModel Create(TModel model);
		// Update record based on key
		TModel Update(TKey id, TModel model);
		// Delete record based on key
		TModel Delete(TKey id);
	}
}
