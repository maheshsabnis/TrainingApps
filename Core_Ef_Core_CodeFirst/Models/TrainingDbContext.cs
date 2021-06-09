using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
namespace Core_Ef_Core_CodeFirst.Models
{
	/// <summary>
	/// The code first approach
	/// define the connection string and mapping explicitely
	/// </summary>
	public class TrainingDbContext : DbContext
	{

		// Table Mapping
		// The Class Person will map with the table of name Persons once the app runs
		public DbSet<Person> Persons { get; set; }

		/// <summary>
		/// Define a connetion string to map with the database
		/// so that tables will be created
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{ 
			optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Training;Persist Security Info=False;User ID=User;Password=PWD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
		}

		/// <summary>
		/// Define mapping
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//					Entity Class		Private member	column name
			modelBuilder.Entity<Person>().Property("Email").HasField("Email");
		}

	}
}
