using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_App.Models;
using MVC_App.Services;
namespace MVC_App
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
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddDbContext<CitusTrainingContext>(options=> {
				options.UseSqlServer(Configuration.GetConnectionString("AppConnetcion"));
			});

			services.AddScoped<IService<Categories, int>, CategoryService>();
			services.AddScoped<IService<Products,int>,ProductsService>();


			// enabling session support
			// ENabling a Cache on Hosting Server of ASP.NET Core App 
			services.AddDistributedMemoryCache();
			services.AddSession(options => 
			{
				// server will maintain the session state
				// and if it is idel for 20 mins then it will be times out
				options.IdleTimeout = TimeSpan.FromMinutes(20);
			});


			// the Object model for Registering the MvcOptions for
			// accepting  Requests for MVC Controllers and API Controllers
			// AddControllersWithViews() , if te cotroller returns the View() as 
			// response then this method will be used to process request for MVC
			// COntroller, else if the response if JSON then request for API COntroller will be processed
			services.AddControllersWithViews();
			// The method that accepts request for Razor Pages
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseSession(); // applying the session middlware to inform the HttpContext that the session is required
			// The Authentication and Authorization must be loaded after routing but befor the Endpoing
			app.UseAuthentication();
			app.UseAuthorization();
			// Endpoint will actually hit the COntroller (MVC / API) / Page
			// befor this conteoller or page is hit, the Secueirty must be verified
			app.UseEndpoints(endpoints =>
			{
				// map the requwst for MVC Controller as well as API COntroller
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				// map the request to RAzor View by matching the Request path
				endpoints.MapRazorPages();
			});
		}
	}
}
