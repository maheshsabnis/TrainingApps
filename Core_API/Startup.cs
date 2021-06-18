using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_API.Models;
using Microsoft.EntityFrameworkCore;
using Core_API.Services;
using Core_API.CustomMiddlewares;
using Microsoft.AspNetCore.Identity;

namespace Core_API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Register the CitusTrainingContext class in DI Container
			services.AddDbContext<CitusTrainingContext>(options=> {
				options.UseSqlServer(Configuration.GetConnectionString("AppConnetcion"));
			});


			// Register the SecurityContext class in DI Container\
			// this class will be used to map with Identity tables to control Application security 
			services.AddDbContext<SecurityContext>(options => {
				options.UseSqlServer(Configuration.GetConnectionString("SecurityConnetcion"));
			});

			// Register the Application Identity for User Management 

			services.AddDefaultIdentity<IdentityUser>(options=> {
				options.SignIn.RequireConfirmedAccount = false;
			}).AddEntityFrameworkStores<SecurityContext>(); // use the SecurityContext for SignIn


			// define CORS Policies
			services.AddCors(options=> {
				options.AddPolicy("corspolicy", policy=> {
					policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
				});
			   
			});


			// Registration of Custom Depednencies
			services.AddScoped<IService<Categories, int>, CategoryService>();
			services.AddScoped<IService<Products, int>, ProductsService>();
			// accept and process requests for APIs 
			services.AddControllers().AddJsonOptions(options=> 
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
			}); 
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				// Show the Default Exception Page 
				app.UseDeveloperExceptionPage();
			}

			// configure the CORS middleware
			app.UseCors("corspolicy");


			// the ROuting Middleware that will be used to read the Request URL and check itb in Route Dictionary
			// for Mapping
			app.UseRouting();

			// Securtity
			// Add Middleware for Authentication
			app.UseAuthentication();
			app.UseAuthorization();

			// Use Custom Middleware

			app.UseExceptionMiddleware();


			// Map the Incomming HTTP Requests with the
			// MVC Controllers
			// API Controllers
			// Razor Pages
			app.UseEndpoints(endpoints =>
			{
				// USe the Routing Map by Routing Middleware to map with
				// the API Controller
				endpoints.MapControllers();
			});
		}
	}
}
