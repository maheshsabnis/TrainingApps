using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CS_Concurrent_Access
{
	class Program
	{
		static int globalCounter = 0;
		static void Main(string[] args)
		{
			//DisplayMessage();
			//DisplayMessage();
			//DisplayMessage();

			// Calling Resource using the threads
			//Thread t1 = new Thread(DisplayMessage);
			//Thread t2 = new Thread(DisplayMessage);
			//Thread t3 = new Thread(DisplayMessage);

			//t1.Start(); // Start t1 thread
			//t2.Start(); // Start t2 thread
			//t3.Start(); // Start t3 thread


			Thread t4 = new Thread(UpdateCounter);
			Thread t5 = new Thread(UpdateCounter);
			Thread t6 = new Thread(UpdateCounter);

			t4.Start();
			t5.Start();
			t6.Start();


			// Wait for all the threads to complete their execution

			t4.Join();
			t5.Join();
			t6.Join();

			Console.WriteLine($"Current Value of the Global Counter {globalCounter}");




			Console.ReadLine();
		}
		/// <summary>
		/// Resource that is performing Some Operation
		/// Since the method is blocking the resource holding thared for 1 second
		/// the other thread will grad the resource
		/// THis may result into logically incorrect execution
		/// </summary>
		//static void DisplayMessage()
		//{
		//	Console.WriteLine("Hello!!!, There We in in Thread ");
		//	Thread.Sleep(1000); // current calling thread will be sleeped for 1 second, and this will result into next thared to access the resources 
		//	Console.WriteLine("Using .NET Framework");
		//}


		// defining a lock object

		private static object _lock = new object();

		/// Using the locking tom protect the resource so that only one thread at a time can accespt it
		static void DisplayMessage()
		{
			// the lock will make sure that the resource is released by a thered then only other thread can access it
			lock(_lock)
			{
				Console.WriteLine("Hello!!!, There We in in Thread ");
				Thread.Sleep(1000); // current calling thread will be sleeped for 1 second, and this will result into next thared to access the resources 
				Console.WriteLine("Using .NET Framework");
			}
		}


		static void UpdateCounter()
		{
			for (int i = 0; i < 10; i++)
			{
				lock (_lock)
				{
					
					globalCounter++;
					
				//	Console.WriteLine($"Current Thread {Thread.CurrentThread.Name}");
				}
			}
		}



	}

	 
}
