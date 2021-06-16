# ASP.NET Core Eco-System

1. ASP.NET Core API Porject Structure
	- appsettings.json
		- A Application Level Settings file for defining following settings
			- ConnectionStrings
				- Database Connection Strings
			- Loggings
				- Logger Settings, by default Console Logging 
			- Host Settings
				- Default Settings for All Hosts e.g. IIS, Apache, etc.
				- Can be customized for other Hosts
			- Custom Settings
				- Any other settings e.g. Security Secret, token lifetime, etc.
	- Program.cs
		- ENtry Point to the Application
		- Creates a Host Builder for following Settings
			- Loads and Instantiates the Startup class, the class created in Startup.cs file
				- webBuilder.UseStartup<Startup>();
					- Inject the IConfiuration interface in Constructor of Startup class
			- Configurarion of Host Seetings for
				- Max requests
				- THroughput
				- Kestral Server Settings
					- Default Host for .NET Core Apps
					- COnfigure the Http Request Processing
					- Port COnfigurarion
					- Other ENvironment Settings
					- Http Communication Configuration e.g. Support for Http/2
					- SSL COnfiguration
					- SOcket COnfiguration
	- Startup.cs
			- This class is executed by the Host by default to manage the application lifecycle
				- All Application Level Configuration
				- All Application Dependencies
				- Application Request Pipeline
		- Constructor() injected with IConfiguration
			- IConfiguration reads settings from the appsettings.json
		- ConfigureServices(IServiceCollection) method
			- This method will be invoked immediately after the ctor by the hostong environment
			- IServiceCollection, contract will be passed by the Hosting Env.
``` csharp
public interface IServiceCollection : ICollection<ServiceDescriptor>, IEnumerable<ServiceDescriptor>, IEnumerable, IList<ServiceDescriptor>
	{
	}
```
			- This method is also responsible to accept and process requests for
				- Razor Views or Razor Pages
				- MVC COntrollers with APIs
				- Only APIs
	- ServiceDescriptor is the class that takes the responsibility of DI registration of the Depednencies
		- Configure(IApplicationBuilder, IWebHostEnvironment) method
			- THis method is responsible for Start Execuion of Request Processing using 
				- HttpContext Object and RequestDelegate delegate
					- HttpContext: Represents the current Http Request
					- RequestDelegate: The delegate that decides how the request will be processed
						- Uses IApplicaitonBuilder to decide which Middlewares(?) will be used during requesting processing
							- Middlewares are replecement for HttpModule and HttpHandlers
								- Routing
								- Exception
								- HttpsRedirection
								- Cors
								- Authentication
								- Authorization
								- Endpoint
									- Middleware used to map the incomming request to the controller mentioned in Http Request, internally this uses the RoutingMiddleware
	- Controllers Folder