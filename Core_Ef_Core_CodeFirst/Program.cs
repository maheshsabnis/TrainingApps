using System;
using System.Linq;
using Core_Ef_Core_CodeFirst.Models;
namespace Core_Ef_Core_CodeFirst
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
			 	ManageDatabase();
				var person = new Person()
				{
					//PersonId = 101,
					PersonName = "Mahesh",
					Age = 67
				};

				person.SetEmail("m.s@ms.com");

				var ctx = new TrainingDbContext();
				ctx.Persons.Add(person);
				ctx.SaveChanges();
				Console.WriteLine("Data Added Successfully, Press Any Key to read records");
				Console.ReadLine();

				// Reading
				foreach (var item in ctx.Persons.ToList())
				{
					Console.WriteLine($"{item.PersonId} {item.PersonName} {item.Age} {item.GetEmail()}");
				}		
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error Ocured {ex.Message}");
			}
			Console.ReadLine();
		}

		static void ManageDatabase()
		{
			// get an instance of DbContext
			using (var dbContext = new TrainingDbContext())
			{
				// If database is already exists Delete it (Not Recommended in production)
				dbContext.Database.EnsureDeleted();
				// create a fresh database
				dbContext.Database.EnsureCreated();
			}
		}
	}
}
