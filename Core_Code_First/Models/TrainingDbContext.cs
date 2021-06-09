using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core_Code_First.Models
{
	public class TrainingDbContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CitusTraining;Integrated Security=SSPI;MultipleActiveResultSets=true");	
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// use the fluent API to establish One-to-Many Relationship with Foreign Key
			modelBuilder.Entity<Product>()
					   .HasOne(c => c.Category) // navigation key for One-to-One Ralationship
					   .WithMany(c => c.Products) // One-to-Many Relationships from Category-to-Product
					   .HasForeignKey(p => p.CategoryRowId); // Map the CategoryRowId of Product with CategoryRowId of Category to use it as Foreign Key
			
			// defining Unique constraints 
			modelBuilder.Entity<Category>(entity=> {
				entity.HasIndex(c => c.CategoryId).IsUnique();
			});

			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasIndex(p => p.ProductId).IsUnique();	
			});


			// defining computed column

			modelBuilder.Entity<Product>()
				.Property(p => p.SalesPrice)
				.HasComputedColumnSql("ALTER TABLE dbo.Products ADD SalesPrice as Price + (Price * 0.2)");			


			// seed data aka the default data to be added while the database is generated / updated
			//Category[] categories = new Category[]
			//{
			//	 new Category() {CategoryRowId=4, CategoryId="Cat-003", CategoryName="Electrical", BasePrice=20,SubCategoryName="Light Bulb"} ,
			//	 new Category() {CategoryRowId=5, CategoryId="Cat-004", CategoryName="Electrical", BasePrice=2000,SubCategoryName="Kitchen Appliances"} 
			//}; 
			//modelBuilder.Entity<Category>().HasData(categories);
		}				 
	}
}
