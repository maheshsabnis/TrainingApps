﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_App.Models;
using MVC_App.Services;
using Microsoft.AspNetCore.Http;
using MVC_App.SessionExtensions;
using MVC_App.CustomFilters;
using Microsoft.AspNetCore.Authorization;

namespace MVC_App.Controllers
{
	/// <summary>
	/// applying the Action Filter on Controller level
	/// </summary>
	//[MyExceptionFilter]

	public class CategoryController : Controller
	{
		private readonly IService<Categories, int> catService;
		public CategoryController(IService<Categories, int>  s)
		{
			catService = s;
		}
		//[Authorize(Roles = "Manager,Clerk,Operator")]
		[Authorize(Policy = "readpolicy")]
		public async  Task<IActionResult> Index()
		{
			var res = await catService.GetAsync();
			return View(res);
		}
		//[Authorize(Roles ="Manager,Clerk")]
		[Authorize(Policy = "writepolicy")]
		public IActionResult Create()
		{
			return View(new Categories());
		}

		[HttpPost]
		public async Task<IActionResult> Create(Categories data)
		{
			//try
			//{
				if (ModelState.IsValid)
				{
				if (data.BasePrice < 0) throw new Exception("Price cannot be zero");
				if (data.CategoryName == string.Empty) throw new Exception("Modle is invalid");
					var res = await catService.CreateAsync(data);
					
					return RedirectToAction("Index");
				}
				else
				{
					return View(data);
				}
			//}
			//catch (Exception ex)
			//{
			//	return View("Error", new ErrorViewModel()
			//	{
			//		ControllerName = RouteData.Values["controller"].ToString(),
			//		ActionName = RouteData.Values["action"].ToString(),
			//		ErrorMessage = $"{ex.Message} \n Detailed Exception {ex.InnerException.Message}"
			//	}) ;
			//}
		}

		public async Task<IActionResult> Edit(int id)
		{
			var res = await catService.GetAsync(id);
			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id,Categories data)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var res = await catService.UpdateAsync(id, data);
					return RedirectToAction("Index");
				}
				else
				{
					return View(data);
				}
			}
			catch (Exception ex)
			{
				return View("Error");		
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
