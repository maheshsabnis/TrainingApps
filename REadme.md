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

# Hands -on -Lab

# Date: 02-Jun-2021
1. Create a List of Employees and perform following operations on it (Do not use LINQ)
	- Add Hard-Coded values in List : 20 Records
	- Use forEach() to list all EMployees based on Specific Department Name
	- Find-out max salary of employee and its name per department 

