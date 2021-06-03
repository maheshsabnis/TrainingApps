using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lambda
{
	public delegate int OperationHandler(int x);

	class Program
	{
		static void Main(string[] args)
		{
			// traditional use of delegate
			OperationHandler oh = new OperationHandler(Increament);
			Console.WriteLine($"Traditional Use of Delegate {oh(10)}");

			// Delegate with implementation as Anonymous method
			OperationHandler oh1 =  delegate (int a) { return a + 10; };

			Console.WriteLine($"Using Anonymoud method C# 2.0 {oh1(100)}");

			// accessing the Bridge method
			Bridge(oh1);
			Console.WriteLine();
			Bridge(oh);

			// passing implementation to the Bridge method directly 
			Bridge(delegate(int x) { return x * 90; });
			// Using C# 3.0, for using Lambda Expression as input parameter
			// to the bridge method
			Bridge(x=>x*90);

			Console.ReadLine();
		}

		/// <summary>
		/// The bridge method accessing delegate as input parameter
		/// </summary>
		/// <param name="o"></param>
		static void Bridge(OperationHandler o)
		{
			Console.WriteLine($"Using Brigde Method {o(1000)}");
		}


		static int Increament(int x)
		{
			return x + 10;
		}
	}
}
