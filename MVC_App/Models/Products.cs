using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_App.Models
{
    public partial class Products
    {
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacturer { get; set; }
        public string Desicription { get; set; }
        public int Price { get; set; }
        public int CategoryRowId { get; set; }

        public virtual Categories CategoryRow { get; set; }
    }
}
