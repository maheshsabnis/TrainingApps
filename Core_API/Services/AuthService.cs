using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Core_API.Services
{
	/// <summary>
	/// Class to contains User Management Logic (Register and Authenticate user)
	/// This class witll also contain  method to generate token when the user is authenticated
	/// </summary>
	public class AuthService
	{
		IConfiguration configuration;
		// the class used to manage the user signin
		SignInManager<IdentityUser> signInManager;
		// class to register application user
		UserManager<IdentityUser> userManager;

		public AuthService(IConfiguration config, SignInManager<IdentityUser> sign, UserManager<IdentityUser> user)
		{
			configuration = config;
			signInManager = sign;
			userManager = user;
		}

		public async Task<bool> RegisterUser(RegisterUser user)
		{
			// store the information from RegisterUSer to IdentityUser so that user can be registered
			// // using ASP.NET Core Identity
			var registerUser = new IdentityUser() { UserName = user.Email, Email = user.Email};
			// creare user, this method will auto-has the password
			var res = await userManager.CreateAsync(registerUser, user.Password);
			if (res.Succeeded)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// THis method will authenticate the user and generate the JSToken
		/// JWT Sections
		/// Header, the algorithm for encryption, provided by .NET Core
		/// Payload, the claims, e.g. User, Role or any other Identity Information, provided by ASP.NET Core Identity
		/// Signeture, the integrity check for the token, create a signeture from verified entity e.g. Verysign 
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<string> AuthUser(LoginUser user)
		{
			string token = string.Empty;
			// authorize the user
			var res = await signInManager.PasswordSignInAsync(user.UserName, user.Password,false, lockoutOnFailure:false);
			if (res.Succeeded)
			{
				// read the secret key
				var secretKey = Convert.FromBase64String(configuration["JWTCoreSettings:SecretKey"]);
				var expiry = Convert.ToInt32(configuration["JWTCoreSettings:ExpiryInMinuts"]);
				// create an instance of IdentityUser so that they will be used in Claims for Token
				// payload
				IdentityUser usr = new IdentityUser(user.UserName);

				// define Token Metadata
				var tokenMetadta = new SecurityTokenDescriptor()
				{
					Issuer = null,
					Audience = null,
					// Setting the Claim for payload
					Subject = new System.Security.Claims.ClaimsIdentity(
						new List<Claim>() { new Claim("username", usr.Id.ToString()) }),
					Expires = DateTime.UtcNow.AddMinutes(expiry), // the server time
					IssuedAt = DateTime.UtcNow, // server current time  form issuing token
					NotBefore = DateTime.UtcNow, // start validation
					// Signeture
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
					 SecurityAlgorithms.HmacSha256Signature)
				};
				// generate the Actual Token based on metadata
				var tokenHandler = new JwtSecurityTokenHandler();
				var tk = tokenHandler.CreateJwtSecurityToken(tokenMetadta);
				token = tokenHandler.WriteToken(tk);
			}
			else
			{
				token = "Login Failed, please verify the credentials";
			}
			return token;
		}
	}
}
