using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core_API.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryRowId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BasePrice { get; set; }
        public string SubCategoryName { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
