using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_API.Models
{
	/// <summary>
	/// The class that will manage the connection with Database to store 
	/// USer and Roles Tables
	/// </summary>
	public class SecurityContext : IdentityDbContext
	{
		/// <summary>
		/// Access the mapping for tables defined by the base class
		/// </summary>
		/// <param name="options"></param>
		public SecurityContext(DbContextOptions<SecurityContext> options):base(options)
		{

		}
	}
}
