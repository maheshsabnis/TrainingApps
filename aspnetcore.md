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
		- Rules for writing Custom Middlewares
			- The class containing Logic for Custom Middleware must be COnstructor Injected using 'RequestDelegate' object
			- This class must contain an method of name 'InvokeAsync()' this method must accept 'HttpContext' object. The custom midleware logic mustb be written in this method
			- Create a Static class with static method. This method must be used as extension method for IApplicationBuilder. i.e. This method will accept first parameter as 'this IApplicationBuilder app'
				- IN this method register the Custom Middleware class as 'Middleware'
					- app.UserMiddleware<T>();
						- T is the the name of the Custom Middleware class which is ctor ibjected using RequestDelegate
			- Finally use this Static method in 'Configure()' method of Startup class to use the middleware in pipeline

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

5. The Identity with Tokens
	- Microsoft.AspNetCore.Identity.UI
		- Provodes Identity classed for User and Role Management
	- Microsoft.AspNetCore.Identity.EntityFrameworkCore
		- Provides an integration with EF core for Storing Users,Roles, information in SQLServer Database
	- Microsoft.AspNetCore.Authentication.JwtBearer
		- Provides JWT Authentication for APIs
	- SYstem.IdentityModel.Tokens.Jwt
		- Provides set of classed to create JWT 
	- IdentityDbContext
		- CLass used to connect with database to map wth ASP.NET Identity Tables
			- AspNetUsers, AspNetRoles, AspNetUsersInRoles, etc.
		- IdentityUser
			- Class mapped with AspNetUsers to store Application Users Information
		- IdentityRole
			- Class mapped with AspNetRoles to store Application Roles Information
		- AspNetUsersInRoles
			- Table to store Roles-To-Users mapping
	
6. The ASP.NET COre uses a Razor View LIbrary for rendering UI for ASP.NET COre Identity
	- Microsoft.AspNetCore.Identity.UI Package
		- Contains Views for
			- Register User, Login User, EmailConfirmation, Forgot Password, etc. 
		- This is a Common UI for Razor View Apps, MVC apps
			- If needed this can be customized based on requirements
		- AddRAzorPages()
			- Will accept and process requests for Razor View, seperate from the MVC ENvironment. THis will look for the page and execute it
7. ASP.NET COre Views
	- RazorPage<TModel> is base class for Views in ASP.NET Core
	- TModel is the Model class bound to view
	- TageHelpers
		- Server-Side HTML Attributed applied on HTML elemets to set its behavior
		- aps-for
			- Bind the Public scalar property of Model class with HTML element
		- asp-items
			- Geerate HTML elements based on collection
			- Generally used for <select> element
		- asp-controller
			- Post the request to the Controller
		- asp-action
			- Post the request to the action
		- asp-validation-for
			- Load and execute validation for Model Property on UI 
	- @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
		- @addTagHelper will register the namespace containing TagHelpeerrs in the project

	- To load colleciton in <select> element use asp-items and iterate over it to generate options	
	- Using PArtial Views
		- These are view those provides View Reusability for showing repeated data
			- The Paritial View is rendered using the Page View (aks Stringly Typed View)
8. ASP.NET Core Breaking Changes
	- Session Provider Changes
		- Session is stored in Local Cache on the server
		- The UseSession() middlware and AddSession() service must be enabled for the HttpContext on Host to make sure that the HttpContext will connect to the Cache to verify the sesison information
		- The ISession contractb interface is provided by ASP.NET Core with
			- Set(<string Key>, byte[]) and TryGetValue(string key, out bute[]) methods
				- Key is the identification of the session value in cache
				- Since the data is stored in cache memory, it will be serialized in Binary format  
		-  Microsoft.AspNetCore.Http;
			- Use this namespace to access 'SessionExtension' methods to save
				- Integer and Seting values in Session Store
		- We can store CLR object in Binary Serialized form in Session Store and by creatig a customm extension the CLR object can be stored in Session in JSON or any other form as per the requirement 
	- Providing more power to the MVC Controllers
		- Scenarios
			- Handling  Exceptions
				- Action Level
					- try..catch block
					- use the Error view to show error messages
				- Controller Level
				- Application Level
			- Implement the Custom Exception FIlters to handle the exception and navigate to the custom error page
				- The class for Custom Exception Filter must be derived from ExceptionFilterAttribute class. THis class contais OnException(ExceptionContext) / OnExceptionAsync(ExceptionContext) method
					- ExceptionContext, object is responsible to listen and handle exception and return the Error Response (e.g. View)  



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
# Date : 21-Jun-2021

4. Create a middleware in ASP.NET API to log each incomming request in database and even if the exception occures then this exeception information must be stored in database table. The table deasign will be as follows
	- LogId: Idenntity Key int
	- LogGUID: Guid
	- Request Date and Time
	- Controller Name
	- Action method
	- Exception Handled

# Date 22-Jun-2021
1. Modiy the ProductController to edit Product Record based on selected Propeduct from Index view of the product. Make sure that, the Edit View showes SubCategoryName list having the SubCategoryName selected for the product being updated.
2. CReate a Single View that will show List of Categories and Products on Same View in Tabular form. When a Category is selected from the Category Table, the Product Table should show only products in selected category  
	- Single View that will show List of Categories and Products on Same View in Tabular form
		- FAct of ASP.NET COre MVC Veiws
			- Only one model can be passed to view
				- CReate a mode that will contain List of Categories and List of Products
			- Create a controller that will use this model and oass to the view so that View can use it.
# Date 23-Jun-2021
3. Create a view that will show a drop down where the List of Sub Categories will be displayed. The Same view will also show list of All products in Table by default. When a Sub Category is selected from the dropdown then only selected Products for the SubCategory must be displayed in Sorted order by Price of the Product. 
4. Handle the Exception in Action Method and navigate to the error page. When we click on 'Go BAck' link on the Erro Page, the Page (and hence the action) should show the data  that has coused the error with error message on this page for value tat has coused the error.
5. Combine the Exception FItes with Logic of Logging the Requests and Exceptions in Database. (Offline and show by MOnday)
	- Create seperate Exception Error Pages for Database Exception and any other exception and navigate to these pages when the excption occur using same exception filter 