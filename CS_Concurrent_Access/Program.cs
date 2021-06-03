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
		static void Main(string[] args)
		{
			ListOPerations op = new ListOPerations();

			ThreadStart ts1 = new ThreadStart(op.AddList1);
			Thread t1 = new Thread(ts1);
			t1.Start(); // start the thread


			ThreadStart ts2 = new ThreadStart(op.AddList2);
			Thread t2 = new Thread(ts2);
			t2.Start(); // start the thread
 

			op.PrintList();
			Console.ReadLine();
		}
	}

	public class ListOPerations
	{
		List<string> lstInt = new List<string>();
		public void AddList1()
		{
			for (int i = 0; i < 10; i++)
			{
				lstInt.Add($"Add Number Operation 1 = {i}");
				 
			}
		}

		public void AddList2()
		{
			for (int i = 0; i < 10; i++)
			{
				lstInt.Add($"Add Number Operation 2 = {i}");
				// var res = lstInt.Remove($"Add Number Operation 1 = {i}");
			}
		}

		public void PrintList()
		{
			foreach (string s in lstInt)
			{
				Console.WriteLine($"ENtry = {s}");
			}
		}
	}
}
