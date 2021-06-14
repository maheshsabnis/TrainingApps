using System;
using CS_DB_Access.Models;
namespace CS_DB_Access
{
	class Program
	{
		static void Main(string[] args)
		{
			CitusTrainingContext context = new CitusTrainingContext();
			Dal dal = new Dal(context);
			// since Dal implement IServie interface 
			// we can pass the Dal instance to the 
			// BizLogic ctor to create its instance
			// because BizLogic ctor accpets IService interface
			BizLogic biz = new BizLogic(dal);


			Console.WriteLine("Enter Category Row Id");
			int id = Convert.ToInt32(Console.ReadLine());
			var result = biz.IsCategoryExist(1);
			Console.WriteLine($"Category Record Found Status based on CategoryRowId {id} is = {result}");

			Console.ReadLine();
		}
	}
}
