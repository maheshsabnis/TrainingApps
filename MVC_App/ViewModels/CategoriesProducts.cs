using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_App.Models;
using MVC_App.Services;
namespace MVC_App.ViewModels
{
	public class CategoriesProducts
	{
		public List<Categories> Categories { get; set; }
		public List<Products> Products { get; set; }
	}
}
