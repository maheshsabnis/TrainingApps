using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_App.Models;
using MVC_App.Services;
using Microsoft.AspNetCore.Http;
using MVC_App.SessionExtensions;
namespace MVC_App.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IService<Categories, int> catService;
		public CategoryController(IService<Categories, int>  s)
		{
			catService = s;
		}
		public async  Task<IActionResult> Index()
		{
			var res = await catService.GetAsync();
			return View(res);
		}

		public IActionResult Create()
		{
			return View(new Categories());
		}

		[HttpPost]
		public async Task<IActionResult> Create(Categories data)
		{
			if (ModelState.IsValid)
			{
				var res = await catService.CreateAsync(data);
				return RedirectToAction("Index");
			}
			else
			{
				return View(data);
			}
		}

		public async Task<IActionResult> Edit(int id)
		{
			var res = await catService.GetAsync(id);
			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id,Categories data)
		{
			if (ModelState.IsValid)
			{
				var res = await catService.UpdateAsync(id,data);
				return RedirectToAction("Index");
			}
			else
			{
				return View(data);
			}
		}

		public async Task<IActionResult> Delete(int id)
		{
			var res = await catService.DeleteAsync(id);
			return RedirectToAction("Index");
		}

		public IActionResult ShowProducts(int id)
		{
			HttpContext.Session.SetInt32("CatRowId",id);
			var cat = catService.GetAsync(id).Result;
			HttpContext.Session.SetObject<Categories>("Cat", cat);
			return RedirectToAction("Index","Product");
		}
	}
}
