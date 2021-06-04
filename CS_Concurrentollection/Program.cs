using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace CS_Concurrentollection
{
	class Program
	{
			// static List<string> lstString = new List<string>();
		  static ConcurrentBag<string> lstString = new ConcurrentBag<string>(); 
		static void Main(string[] args)
		{
			Thread t1 = new Thread(AddList);
			Thread t2 = new Thread(ReadList);
			t1.Start();
			

			t1.Join();
			t2.Start();
			t2.Join();

			//Task t1 = Task.Run(()=> AddList());
			//Task t2 = Task.Run(() => AddList());

			//Task.WaitAll(t1,t2);



			Console.WriteLine("Main Thread");
			//foreach (var item in lstString)
			//{
			//	Console.WriteLine(item);
			//}
			Console.ReadLine();
		}

		static void AddList()
		{
			for (int i = 1; i < 10; i++)
			{
				Thread.Sleep(300);
				lstString.Add($"Valute in List {i*i}");
			}
		}

		static void ReadList()
		{
			foreach (var item in lstString)
			{
				Thread.Sleep(300);
				Console.WriteLine(item);
			}
		}



	}
}
