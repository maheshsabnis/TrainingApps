using System;
using Core_Code_First.Models;
namespace Core_Code_First
{
	class Program
	{
		static void Main(string[] args)
		{
			var cat = new Category()
			{ 
			   CategoryId = "Cat-006",
			   CategoryName = "Food",
			    BasePrice = 10,
				 SubCategoryName= "Fast Food"
			};

			var ctx = new TrainingDbContext();
			ctx.Categories.Add(cat);
			ctx.SaveChanges();
			Console.ReadLine();
		}
	}
}
