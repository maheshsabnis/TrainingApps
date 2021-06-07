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


