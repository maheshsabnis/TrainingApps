using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core_Code_First.Models
{
	public class Category
	{
		[Key] // Primary Identity Key
		public int CategoryRowId { get; set; }
		[Required]
		[StringLength(20)]
		public string CategoryId { get; set; }
		[Required]
		[StringLength(100)]
		[ConcurrencyCheck] // Check for Concurrent Updates to generate DbConcurrency Exception
		public string CategoryName { get; set; }

		// adding new property that will generate new column
		[Required]
		[StringLength(100)]
		public string SubCategoryName { get; set; }

		[Timestamp]
		public byte[] RowVersion { get; set; }

		[Required]
		public int BasePrice { get; set; }
		public ICollection<Product> Products { get; set; } // One-To-Many Relationship
	}


	public class Product
	{
		[Key] // Primary Identity Key
		public int ProductRowId { get; set; }
		[Required]
		public string ProductId { get; set; }
		[Required]
		[StringLength(20)]
		[ConcurrencyCheck] // Check for Concurrent Updates to generate DbConcurrency Exception
		public string ProductName { get; set; }
		[Required]
		[StringLength(60)]
		public string Manufacturer { get; set; }
		[Required]
		[StringLength(200)]
		public string Desicription { get; set; }
		[Required]
		public int Price { get; set; }
		 [Required]
		//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int SalesPrice { get; set; }
		[Required]
		public int CategoryRowId { get; set; } // Foreign Key
		public Category Category { get; set; } // Referential Integrity 
	}


}
