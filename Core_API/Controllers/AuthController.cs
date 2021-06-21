using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_API.Models;
using Core_API.Services;
namespace Core_API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AuthService authService;
		public AuthController(AuthService auth)
		{
			authService = auth;
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterUser user)
		{

			if (ModelState.IsValid)
			{
				var isUserRegistered = await authService.RegisterUser(user);
				if (isUserRegistered == false)
				{
					return Conflict("This user is already available");
				}
				var response = new ResponseData()
				{
					Message = $"The User {user.Email} is registered successfully"
			    };
				return Ok(response);
		    }
			else
			 {
				return BadRequest(ModelState);
			 }
	    }

		[HttpPost]
		public async Task<IActionResult> Login(LoginUser user)
		{
			if (ModelState.IsValid)
			{
				var authToken = await authService.AuthUser(user);
				if (authToken == string.Empty)
				{
					return Unauthorized("Login Failed");
				}
				var response = new ResponseData()
				{
					 Message = authToken
				};
				return Ok(authToken);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
     }
	
}
