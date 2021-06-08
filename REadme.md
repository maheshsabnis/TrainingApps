# Using Delegates

1. The delegate must be defined at namespace level as publically accessible type 
	so that it can be used/reused across all typs of the application
	- The Signeture must match with the method signeture
	- The method will be executed with its reference
2. The deelgate is also responsible for executing the method asynchronously based on 
	request from the caller object
		- The CLR will create a Worker thread to execute method on diferent thread
3. The delegate is also used to perform notification based disconnected communication across 
	multiple objects using Events
		- Events are special delegates
		- They are declared using Delegate
		- The method executed by event always return void (a complete one-way communication)

# .NET Collections
1. Used for Storing data  In Memory aloocated to the .NET Aplication
	- Support CRUD oeprations
	- Each entry in Collection is stored as object, the highest level type in .NET  (Boxing)
	- When data is read from the collection it is casted to a specific type (UnBoxing)
		- The UnBoxing is time comuming process to read data from collections

# .NET Generics
1. Solve the Boxing /UnBoxing issues of collections
2. USed to store data in Memory
3. Uses 'Type-Safe' data in memory(?)
	- The memory know what type of data is stored in the collection
4. Generics
	- System.Collections.Generics
	- Classes
	- Parameters
	- Properties
	- Class Members
	- Methods
	- Interface
	- Delegate
	- Event
5. Create a Generic class if you want to create a custom collection with custom operations
6. Create a Generic interface if you eant to implement common contracts across set of classes with same methods but 
	different implementation
		- Heavily used in MVC, ASP.NET Core

7. Object Queries aka Language Integrated Queries (LINQ)
	- Object
		- Schema
		- Schema contains data 
	- LINQ in .NET 3.5 
		- Development Approaches for LINQ
			- Lambda Expression
				- a simple way of passing parameters to a method if its is accessing delegate as input parameter
			- Extension Methods
				- an externally added functionalities in Sealed class
				- an extension framework
					- Used to enhance the capacilities of the .NET Frmework for project / product spcific 
						implementation
					- THis is used to exnetnd the sealed class w/o any derivation	
						- The class used as Extenion class MUST BE STATIC
						- The method which will be used as extension method in the class MUST BE STATIC
						- The first parameterb of this method must be 'this' refereef 'reference' of the class
							for which this method will	be used as extension method
			- Expression Trees
				- a mechanism to process the expression
					- Operators
					- Operands
					- Constants
				- c = a+b*10;
					- Operaors
						+, *
					- Operands
						- a,b
					- Constnts
						- 10
			- Predefined delegates
				- Action and Action<T>
					- Action, delegate for a method with no input and output parameters
					- Action<T>, a delegate for a method with input parameter as T but not output parameter
				- Predicate<T>
					- Expression to be evaluated based on Lambda
			- Declarative Queries
				- USe Extension methods for Writing Queries
			- Imperative Queries
				- Use the LINQ Operators
					- Processed by LINQ Query Processing Engine
8. If to perform the operations concurently then use  Thread
	- Thread
		- A unit of exercution/task where a seperate process is allocated to execute an operation in independent process
			and once the operation is completed the control will be moved back to the Main Thread (aka caller thread)
	- System.Threading
		- Thraed class
			- Contains parameterized ctor accepting ThreadStart as parameter
		- ThreadStart delegate
			- This delegate accept method that does not have input and output parameters
	- When multiple threads wants to use the resources at a time then there may be conflict occur while accesing resource
		concurrenly. To provide the concurrent access (aka SYnchronization) of the resource using 
			- lock
			- Monitor
			- Mutex
	- The Mutxt class is derived from 'WaitHandle' abstract base class. This class is used to manage signaling across
		multiple or concurrently running threads
			- The 'WaitOne()' method is resoponsible for managing the single for other thraeds that the current thread 
				has acquired resources so other threads will be pit on hold
9. Task Parallel Programming
	- Using Task Parallel Library (TPL)
		- Set of APIs  (aka classes) used to encapsulate Mukti-Threading and Processing of collections Parallely
		- Introduced in .NET 4.0+
			- Concurrent Collections
				- Thread Safe Collection classes for providing Concurrent Access of In-Memory data across thraeds 
					- ConcurrentBag
					- ConcurrentStack
					- ConcurrentDictionary
					- ConcurrentQueue
						- USes by IIS 8+ for creating Threads those will be shared by mutiple ASP.NET apps working on IIS
			- Task class
				- Encapsulation over the Thread that repesents 'A Unit of Asynchronous Operation'
				- Methods
					- StartNew()
					- Start()
					- Wait()
					- WaitAll()
			- Parallel Class
				- The class that provides a default concurrent access of resources
				- Methods
					- Invoke()
						- Perform operations parallely by accessing multiple resources at a time
					- For()
						- Method to process the collection parallely
					- ForEach()
						- Same as for ait auto IEnumerations across collections	
			- .NET 4.5 Improvements in TPL
				- async and await
					- Use 'async' modifier for a method that returns Task Object
					- The async modifier is used by a method that must have at least one 
						'awaitable' call (Asynchronously executing external call) using 'await'
				- System.IO chnages for Async Methods for
					- Stream Read/Write
					- File Operations Read/Write
				- Database Operations
					- Async Connections
					- Async Queriues
					- Async DML Operations
				- .NET 4.5 Asynchronous methods for UnManaged Resources
					- Files
						- ReadAsync() / WriteAsync() / FlushAsync()
				- The async, the instruction given to CLR that the Task and hence the Thread must be created
					for executing the operation
				- The await, the instruction given to CLR that the 'wait()' must be invoked to make sure that
					the operation is completed and result is back to caller

10. Using .NET Core
- Single File Publish,
	- Modify the .csproj file andn add following settings in it
- Using the Runtime Identifier
	- https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
	<PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
	<PublishSingleFile>true</PublishSingleFile>
		- The setings for publushing the signle file
	<RuntimeIdentifier>win10-x64</RuntimeIdentifier>
		- The OS Where we target the single file publish
  </PropertyGroup>
- RUn the Publish wizard to publish the project in folder

- To generate a signle file with required (mandaory) dependencies only, modify the .csproj file for
	trimmed deployment
		- <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
	<PublishSingleFile>true</PublishSingleFile>
	<RuntimeIdentifier>win10-x64</RuntimeIdentifier>
	  <PublishTrimmed>true</PublishTrimmed>
  </PropertyGroup>


11. Using EF Core for Application Development for Database First Approach
- Make sure that the dotnet ef is installed in global scope
	- dotnet tool install --global dotnet-ef	


- The Projetc must contains following NuGet Packages installed 
	- Microsoft.EntityFrameworkCore
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Design
	- Microsoft.EntityFrameworkCore.Tools
- Rightl-CLick on Project NAme and select Manage NuGet Package and serach package to install, make sure that
	you select correct version and click on install button
- installing package from command prompt
	- dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 3.1.15
- To 'Scaffold' aka generate Data Access Layer from Database First Approach run the following command
	- dotnet ef  dbcontext scaffold "<Connection-String>" Mictosoft.EntityFrameworkCore.SqlServer 
		-o <Destination-Foldel-to-generate-model class files>
	- Connection-String
		- if Sql Srever is on the Local machine with Sql Server Authentication
			- Data Source=.;Initial Catalog=<Database-name>;User Id=<Uname>;Password=<Pwd>;MultipleActiveResultSets=true

		- if Sql Srever is on the Local machine with Windows Authentication
			- Data Source=.;Initial Catalog=<Database-name>;Integrated Security=SSPI;MultipleActiveResultSets=true	
		- If Sql Server is on remote machine
			- Data Source=<NAME-of-Remote-Machine> OR <IP-Address>;initial Catalog=<Database-name>;Integrated Security=SSPI;MultipleActiveResultSets=true
		- If using SqlExpress
			- Data SOurce=.\\selexpress; initial Catalog=<Database-name>;Integrated Security=SSPI;MultipleActiveResultSets=true

dotnet ef dbcontext scaffold "Server=DbServer;
Initial Catalog=CitusTrg;Persist Security Info=False;User ID=USerName;Password=PWD;MultipleActiveResultSets=False;Encrypt=True;
	TrustServerCertificate=False;Connection Timeout=30;" 
	Microsoft.EntityFrameworkCore.SqlServer -o Models

- EF COre Object Models
	- DbContext class
		- Class used to Manage Db Connection
		- Manage Db Transactions
		- Map the CLR class aka entity classes to database tables using DbSet<T>
			- Where T is the CLR class name
		- Methods
			- OnConfiguring
				- Contain the DbConnection configuration
			- OnModelCreating
				- Contains Code to Map CLR object with Database and relationships across CLR objects using
					fluent APIs
- EF Core Programming Features
	- COnsider 'ctx' is an instance of DbContext
	- Entity class is 'Employee' and DbSet<Employee> is Emp

	- Redaing all records from Emp mapping
		- ctx.Emp.ToList(); || ctx.Emp.ToListAsync()
	- Reading a record based on Primary Key
		- ctx.Emp.Find(<Primary-Key-Value>); || ctx.Emp.FindAsync(<Primary-Key-Value>);
	- To CReate a new Record
		- Create an Instance of Employee class
			- var emp = new Employees()
		- set its property values
			- emp.EmpNo=""; emp.EmpName="";
		- pass this object to the Add() method of Emp
			- ctx.Emp.Add(emp); || ctx.Emp.AddAsync(emp);
		- Commit Transactions
			- ctx.SaveChanges(); || cxt.SaveChangesAsync();
		- Add multiple records at a time
			- ctx.Emp.AddRange(List of Employee); || ctx.Emp.AddRangeAsync(List of Employee); 
	- To Update Record
		- Search record based on primary key
			- var empToSearch =  ctx.Emp.Find(<Primary-Key-Value>); || ctx.Emp.FindAsync(<Primary-Key-Value>);
		- Approach 1: Updating properties from Searched object Individually
			- empToSearch.EmpNo = <New-Value-Received-from-End-User> ;
			- empToSearch.EmpName = <New-Value-Received-from-End-User> ;
		- Commit Transaction
			- ctx.SaveChanges(); || cxt.SaveChangesAsync();
		- Approach 2:
			- context.Entry<Department>(entity).State = EntityState.Modified;
			- Commit Transactions
				- ctx.SaveChanges(); || cxt.SaveChangesAsync();	
	- To Delete
		- Search record based on primary key
			- var empToDelete =  ctx.Emp.Find(<Primary-Key-Value>); || ctx.Emp.FindAsync(<Primary-Key-Value>)
		- Pass the searched record to Remove method
			- ctx.Eo.Remove(empoDelete);
		- Commit Transactions
				- ctx.SaveChanges(); || cxt.SaveChangesAsync();	

# Important Note while programming for EF Core
	- Make sure that all  Transactional methods must be enclosed inside 'Exception-Hadling'
		- instaed of catching the exception, throw it so that then layer accessing the EF COre logic class
			will catch the exception

# Hands -on -Lab

# Date: 02-Jun-2021
1. Create a List of Employees and perform following operations on it (Do not use LINQ)
	- Add Hard-Coded values in List : 20 Records
	- Use forEach() to list all EMployees based on Specific Department Name
	- Find-out max salary of employee and its name per department 
# Date: 03-June-2021
1. Complete the CS_Generic_App for performing Following Operations
	- List of All Employees for specific DeptName
	- List all employees having Max Salary Per Department
	- Implement the IService interface for Department and Employee Model classes for performing
		CRUD operations. 
	- While adding employee in department, if the capacity of the department is already full then generate an 
		error message
	- Update salary of all employees by 15%

# Dayte 04-Jun-2021

1. CReate an EMployee collection with 50 Records, the Employee Information will be stored as
	- EmpNo, EmpName, Designation, Salary, DeptName, Tax
	- Write Seperate methods to generate tax of Employee based on FOllowing Rules
		- Designation: Manager, Tax is 30% of the Salary
		- Designation: Engineer, Tax is 25% of the Salary
		- Designation: Lead, Tax is 28% of the Salary
		- Designation: Programming, Tax is 22% of the Salary
	- Make sure that all thes methods are invoked at a time Parallely
	- Write Down the Tax details of each employee in seperate file in the same methiod that is calculating the Tax
2. Please go through the Task and Parallels demos carefully

# Date 07-Jun-2021
- Generate the Entity Model using EF Database First
# Date 08-Jun-2021
- Implement the Application for the following
	- CReate DepartmentService and EmployeeService classes tnose will contains the CRUD operations
	- Make sure that the user defined execeptions must be present in each method of both service classes
	- Create a class that will contain following methods
		- AddDeptEmp(Dept, Emps)
			- Dept is a single Department object which will be a new department entry
			- Emps is a List of Employees to be created  for the new department
		- Create a method that will List Employees Group by Department Names
		- Create a method that will List Employees in group by designations
	- CReate a class that will contain rules for Validations like follows
		- DeptValidator(Dept) method
			- This method will accept Dept as input parameter and will return validation errors based on following rules
				- DeptNo is must
				- DeptName is must and must start from UpperCase character
				- Location is Must
			- This method will return String Array as ouput parameter containing List of Error Messages if any 
		- EmpValidator(Emp)
			- This method will accept Emp as input parameter and will return validation errors based on following rules
				- Empo is Must
				- EMpName is must and must start from Upper Case character
				- Salary is must and must be positive numeric
				- Designation can be either
					- Manager, Operator, Clerk, Engineer
				- DeptUniqueId is must
			- This method will return String Array as ouput parameter containing List of Error Messages if any 