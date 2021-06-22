using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_App.Models;
using MVC_App.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using MVC_App.SessionExtensions;
namespace MVC_App.Controllers
{
	public class ProductController : Controller
	{
		private readonly IService<Products, int> prdService;
		private readonly IService<Categories, int> catService;
		public ProductController(IService<Products, int>  s, IService<Categories, int> c)
		{
			prdService = s;
			catService = c;
		}
		public async  Task<IActionResult> Index()
		{
			// read data from Session
			var id = HttpContext.Session.GetInt32("CatRowId");
			var cat = HttpContext.Session.GetObject<Categories>("Cat");
			if (id == 0)
			{
				var res = await prdService.GetAsync();
				return View(res);
			}
			else
			{
				var data = await prdService.GetAsync();
				var res = data.Where(p=>p.CategoryRowId == id);
				return View(res);
			}
		
		}

		public IActionResult Create()
		{
			var src = new Products();
			ViewData["CategoryRowId"] = new SelectList(catService.GetAsync().Result.ToList(), "CategoryRowId", "SubCategoryName"); 
			return View(src);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Products data)
		{
			if (ModelState.IsValid)
			{
				var res = await prdService.CreateAsync(data);
				return RedirectToAction("Index");
			}
			else
			{
				return View(data);
			}
		}

		public async Task<IActionResult> Edit(int id)
		{
			var res = await prdService.GetAsync(id);
			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id,Products data)
		{
			if (ModelState.IsValid)
			{
				var res = await prdService.UpdateAsync(id,data);
				return RedirectToAction("Index");
			}
			else
			{
				return View(data);
			}
		}

		public async Task<IActionResult> Delete(int id)
		{
			var res = await prdService.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
