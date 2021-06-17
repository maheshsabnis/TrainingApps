using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable
using System.ComponentModel.DataAnnotations;
namespace Core_API.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryRowId { get; set; }
        [Required(ErrorMessage = "Category Id is required")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Base Price is required")]
        [NumericValidator(ErrorMessage = "Base Price annot be -ve")]
        public int BasePrice { get; set; }
        [Required(ErrorMessage = "Sub Category Name is required")]
        public string SubCategoryName { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }



    public class NumericValidatorAttribute : ValidationAttribute
    {
		public override bool IsValid(object value)
		{
            if (Convert.ToInt32(value) < 0)
            {
                return false;
            }
            return true;
		}
	}

         
}
