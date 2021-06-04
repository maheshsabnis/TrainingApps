using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_TaskFactory
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine($"Main Thread Id {Thread.CurrentThread.ManagedThreadId} started");
			// the Task will be created and started automatically
			Task t1 = Task.Factory.StartNew(()=> Print(100));

			Console.WriteLine($"Main Thread Id {Thread.CurrentThread.ManagedThreadId} COmpleted");
			Console.ReadLine();
		}

		static void Print(int counter)
		{
			Console.WriteLine($"Child Thread Id {Thread.CurrentThread.ManagedThreadId} started");
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine($"Current Counter {i}");
			}
			Console.WriteLine($"Child Thread Id {Thread.CurrentThread.ManagedThreadId} completed");
		}
	}
}
