using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_App.Controllers
{
	public class RoleController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;

		public RoleController(RoleManager<IdentityRole> role)
		{
			roleManager = role;
		}

		public IActionResult Index()
		{
			var roles = roleManager.Roles.ToList();
			return View(roles);
		}

		public IActionResult Create()
		{
			var role = new IdentityRole();
			return View(role);
		}
		[HttpPost]
		public async Task<IActionResult> Create(IdentityRole role)
		{
			await roleManager.CreateAsync(role);
			return RedirectToAction("Index");
		}
	}
}
