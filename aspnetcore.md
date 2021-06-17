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
		- This contains all API Controllers un API Project
``` csharp
[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
	}
```

- ControllerBase, the BASE class for all Controllers in ASP.NET Core (MVP and API controllers)
	- This defines methods for Request Processing for Controller
	- The Response Types
	- The class defines methods for Http Responses from API based on execution of action method
		- Methods from COntroller Returns 'ActionResult' class type that implements 'IActionResult' interface.
		- The ActionResult class define ExecuteResult(ActionContext) and ExecuteResultAsync(ActionContext) methods.
		- These method accept ActionContext the represents the current action methodm executing
			- The Result from Action Method can be
				- View/RedirectToAction (MVC-Controller)
				- HTTP Status Result (API Controllers)
					- OkResult() / OkObjectResult() / NotFoundObjectResult / NotFOundResult etc.
				- File Resources
- RouteAttribute
	- CLass that defines ROute Expression for API Controller so that it can match with 'Routing-Middleware' to execute the controller with its method and generate result
- ApiControllerAttribute
	- Represent thst the current COntroller is APIController
	- Map the Http Post and Put requests with CLR Object and process them


# Practices to be followed for Designing APIs
1. Make sure that the Models are validated befor Writing data. Make sure that the ModelState.IsValid must be checked for Model validation in an Action method before the write operations to the database are executed
	- Alternatives
		- Apply Data Annotation Validations on ENtity Classes
		- Create Custom Annotation Validators
		- If the Model class code is not available (means you are referring dll containing Model classes), then write explict data validations in the Action method using if..else conditions
2. Make sure that, the Action Method uses Exception Throw and Exception Handling logic
	- try..catch
	- Global Exception Middleware
3. MAke sure that the Posted data in various ways(?) must be accepted by the API and Process it
	- VArious ways are
		- Data Posted in Body
		- Data Posted as QueryString
		- Data Posted as Route Parameter
		- Data Posted as Form
	- Use the Model BInders to Map the Posted data in various ways to the CLR Object
		- FromBody
			- Map data received from HTTP Body with CLR Object
		- FromQuery
			- - Map data received from HTTP Query String with CLR Object
		- FromRoute
			- Map data received from HTTP ROute Parameters with CLR Object
		- FromForm
			- Map data received from HTTP FormModel object with CLR Object

4. Make sure that the API has the required Cross-Origin-Resource-Sharing (CORS) policy set
	- services.AddCors(policy), in ConfigureServices() method of Startup class
	- app.UserCors("Policyname") in Configure() method of Startup Class
		- Policyname is the policy configuration defined using AddCors() method


# Hands-on-Labs API

# Date : 17-06-2021

1. Complete Application by Creating Category And Product APIs for CRUD Operations
2. Create a Search API that will have Search Method with Following Parameters
	- Search(CatName, filter, PrdName)
		- filter can be 'AND' or 'OR'
		- if filter is 'AND' then Serach Should return result as CatName AND PrdName
		- if filter is 'OR' then Serach Should return result as CatName OR PrdName
3. Create a API that will have a Post Method which Save Category and Product data with One-to-many relationships
	- for one category, multiple products must be created in Single Http Post request
		- Post(Category, List<Product>), approach 1
		- CReate a ViewModel Class as
			- public class CatPrd {Catogory object, List<Product> Products}
				Post(CatPrd), approach 2

