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
			- ctx.Entry<Department>(entity).State = EntityState.Modified; OR ctx.Update<Department>(entity);
				- The se3arched record must be detached from the context before State Update / Modification takes
					place
						- 	ctx.Entry(result).State = EntityState.Detached;
			- Commit Transactions
				- ctx.SaveChanges(); || cxt.SaveChangesAsync();	
	- To Delete
		- Search record based on primary key
			- var empToDelete =  ctx.Emp.Find(<Primary-Key-Value>); || ctx.Emp.FindAsync(<Primary-Key-Value>)
		- Pass the searched record to Remove method
			- ctx.Eo.Remove(empoDelete);
		- Commit Transactions
				- ctx.SaveChanges(); || cxt.SaveChangesAsync();	
- Code-First Approach
	- Flexible Object Mapping
		- Map the Private properties of the class to Table COlumns using Public Wrapper methods
- Design Considerations of Code-First Approach
	- Class Must have Identity Key (Use as Primary Key)
	- Apply required Annotation Constraints on Properties
	- Correctly define relationships across classes 
	- The DataAnnotations for Constratints 
		- System.ComponentModel.DataAnnotations
			- RequiredAttribute, RegExAttribute, StringLengthAttribute, NumericLengthAtribute, CompareAttribute
			- KeyAttribute
			- ForeignKeyAttribute
			- ConcurrencyCheckAttrubite
			- TimeStampAttribue, can also be used for concurrency check
				- applied on the property of the type byte[] 
	- Using Fluent APIs, Allow developers to set behavior on Entity Classes while mapping with the Tables in database
		- Defining One-to-Many Relatopnships
		- ForeignKey
		- Index and Unique Constaints
		- Concurrency Tokens
		- TimeStamp, 
- Migrations
	- This is the Processes of generating the C#+SQL Methods for 
		- Table Creations
		- Constratints
		- Relations
		- Dropping Tables
		- Altering Columns
		- Adding Columns
	- Command for generating Migrations (Run from the command Prompt)
		- dotnet ef migrations add <MIGRATION-NAME> -c <NAMESPACE-NAME.DBCONTEXT-CLASS-NAME>
		- e.g.
			- dotnet ef migrations add firstMigration -c Core_Code_First.Models.TrainingDbContext
		- View List of Migrations
			- dotnet ef migrations list
		- Remove Wrong MIgrations
			- dotnet ef migrations remove
				- This will remove the latest generated migration
	- The Migrations will generate tow classes
		- Class garanarted which is derived from ''Migration' base class. THis class contains Up() method to create tables with constraints. The Down() method will contain commands for drop tables
		- Class generated which is derived from 'ModelSnapshot' base class. This class contains information of mapping between CLR class with ots properties with the table in database
	- Apply Migrations to generate database and tables
		- Command
			- dotnet ef database update -c <NAMESPACE-NAME.DBCONTEXT-CLASS-NAME>
			- E.g.	
				- dotnet ef database update -c Core_Code_First.Models.TrainingDbContext


# Important Note while programming for EF Core
	- Make sure that all  Transactional methods must be enclosed inside 'Exception-Hadling'
		- instaed of catching the exception, throw it so that then layer accessing the EF COre logic class
			will catch the exception


# Performing Unit Testing in .NET
1. NUnit
	- Unit Tetsing Frwk for all .NET Languages
	- Version 3
	- Re-Written for increasing features in .NET and .NET Core
	- Available using .NET Foundation
	- Download it from https://www.nuget.org
	- NUnit
		- Foundation Framework for creating test Suite and Test Cases
	- NUnit3TestAdapter
		- An Integration between Visual Studio 2012+ and NUnit Test Cases
		- USed to provide the Test Case Execution Statastics
	- Microsoft.Net.Test.Sdk
		- Visual Studio Test ENviorment for Unit Tests
			- Provides following Services
				- Test Explorer i.e. the Test Adapter
				- Test Case Details for Successful and Failed Execution
				- Generatin Unit Test Project
					- Helpful for creating tests along with the configuration of code
				- Live Unit Testing
					- Imediately test the code whrn it is changes
				- Code Coverage Feature	
					- Provide a statastics of code Quality Test
				- Test Debugging	
	- Creating a Unit Test
		- TestFixtureAttribute
			- Class level attribute
			- Applied on class that contains test cases
			- Setup the test dependencies
				- Manage the instances of depednencies required by test cases
			- Define parameters for the private members of the class, so that they can be used by the Tets cases using comstructors 
		- TestCaseAttribute
			- A Method Level Attribute
			- Represents the Method containing an implementation of Test Case
				- Test Case
					- The Approach that is followed to test the User Story (aka the implementation done by the developer)
					- Each Test case has following 3 steps for execution
						- Arrange
							- The process of collecting required test data to execte the test
							- CReate instance of class of which method to be tested
							- Initialize Parameters values using either hard-coding or using Data-Driven Unit Test
							- CReating a Mock of the depdencnies aka the 'Fake Object'
							- Expected Result
						- Act
							- Process of actually Invoking method to be testsed
								- PAss parameters
								- USe Fake Objects
								- Receive Actual Result
						- Assert
							- Assertion
								- Compare the Expected Result with Actual Result
									- Equal, Not-Equal, Greater Than, Less than, Greater-than-equal, Less-than-equal
									- Contains, Not-Contain, Typeof
									- Throws Exception
									- Raise Event
				- TestCase
					-  Used for Data-Driven Tests
						- Hard Coded values
						- File Source Based Testing
							- xlsx or csv files to read test data (Recommended)
						- Database Based Testing
							- Data is fetched from table to test the method	
				- IgnoreAttribute
					- Indicates that the test should't be run
				- Repeat Atribute
					- repeate the test execution for multiple time
				- SetUpFixture
					- COntains the cofiguration for one-time Tearup and teardown methdo for all test in the class
					- OneTimeSetUpAttribute
						- APplied on method to make sure that the method will be executed before each test case
					- OneTimeTearDownAttribute
						- Applied on method to make sure that this method will be eecuted after each test case

	- Assertion Types
		- CollectionAssert
			- Provide the Test Evaluation assertion on Collection Inputs


# Practically Working with NUnit
1. Create a MS-Test Project or Class Library project (.NET Core)
	- If using Class Librray project then add following NuGet Packages
		- Microsoft.Net.Test.Sdk (Mandatory to access Test Explorer)
		- NUnit
		- NUnit3TestAdapeter
	- In the test project also add the Project Reference thatb represents the code to be tested


2. Data Driven Tests
	- These are tests those accepts Data Source Information to execute the test. The Data Source provides the test data so that Test Method can use this data for making sure that the method to be tested is executed on all possible combinations of the input values and generate expected results
	- Microsoft.VisualStidio.TestTools.UnitTesting namespace
		- The 'DataSource' class
			- CSV
				- Reds data from CSV files
			- SqlServer
			- Excel
- Microsoft.VisualStudio.TestTools.UnitTesting.TestContext
	- The TestContext class is used to read the data dource provider for the curfrent testing environment  
	
- Using the Mocks for Unit Testing of methods those who are having external depednencies e.g. database, files, networks, etc.
	- The 'Moq'Framework is provided by community to perform the Unit Testing of the C# code whih is having third-party or external depednencies.
		- Steps of using Moq
			- Install it in Testing Project
			- Create a Mock<T> object, where T is the Types that is used to create Fake object (aka in-memory)
			- Setup the Mock and point the method to be tested and verify the retur type from it
			- Call the actual method to be tested from the class by passing te Fake objetc as a dependency
			

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

# Date 09-Jun-2021

1. Create a Model for 
	 - Customer
		- CustomerRowId int identity primary key
		- CustomerId string unique
		- CustomerName string
		- Address string
		- City string
		- Age int
	- Vendor
		- VendorRowId int identity primary key
		- VedorId string unique
		- VendorName string
	- Product	
		- ProductRowId int identity primary key
		- ProductId string unique
		- VendorId Foreign Key
		- ProductName string
		- CategoryName string
		- UnitPrice int
	 - Order
		- OrderRowId int identity primary key
		- OrderId strig unique
		- ProductRowId Foreign key
		- CustomerRowId Foreign key
		- Quentity int
		- TotalPrice int

- Using FLuent API establish One-to-Many relatioships across Vendor-Products and Customer-Orders
- ProductName, CustomerName, VendorName must have concurrency token
- All String Fields are mandatory
- Define length for strings using StringLength attribute
- After creating vendor table add Address, City, Email columns as not null
- Make sure that tables will have default data using code


CReate a C# appliation that will allow end-user to perform following operations
	- List Products based on VendorName
	- Customer can place orders for Product, so display orders places by customer 

# Date: 10-Jun-2021

1. Create two Tables in database of name 
	- Roles
		- RoleId, RoleName
	- Users
		- UserId, UserName, Email, Password, RoleId
	- Generate Entities from these tables
		- Roles
		- Users
2. Create a Data Access Layer to perform following operations
	- Create Role
	- Create User
	- Assign Role to the User
3. Create a class that contains following methods
	- CrateRole(Roles class)
		- Perform following oerations in the mehod
			- Check RoleName as Not-Null, Empty and Role will be only Alphabetic
			- Check if Role Does Not Exist
			- If Role exist return false
			- If Not exists Create Role
	- RegisterUser(Users class)
		- Check UserName not null
			- USerNAme May contains special Characters like
				- .,-,_
				- digits 9-0
			- No other Special characters
			- Must not starts from Digits ot special characters
			- Should not contain blankspace
			- Must be min 8 characters in length
			- Can be max 20 characters in length
		- Check for Email as valid EMail, (Note use .NET RegEx for Email)
		- Password
			- Must be Stong password
		- COnfirmPassword
			- Pasword and Confirm Password Must match
		- To save the password ENcrypt it. (Note. Use .NET ENcryption)
	- AssignRoleToUser(UserName, RoleName)
		- Check UserName and RoleName are not EMpty
		- UserName must be exist
		- RoleName must be exist
		- If UserName, RoleName doesnot exist, you may throw exceptions

# Date: 11-Jun-2021
- Write Unit Tests on the Problem Statement of Date 10-June-2021

# Date: 14-Jun-2021

1. CReate a Unit Test on CreateAsync() method for creating cataegory. And Make Sure that, the Test data is read from the 
	- TestCaseAttriute() class
		- Create a dotnetcore unit test project
	- From the CSV file
		- Create .NET Framework MS-Test Project
2. Makes sure that when the query is executed against the GetRoles() method (Refer Lab on Date 10-Jun-201), Roles returned from database Role Table must be Manager, Clerk, Operator, Engineer, Developer
	- Tyhe data must be received from database
3. Create a Moq Test that will fetch UserNames from Users Table 
	- Actual call to the database must not takes place