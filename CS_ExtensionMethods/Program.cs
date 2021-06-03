using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ExtensionMethods
{
	class Program
	{
		static void Main(string[] args)
		{
			MyMath obj = new MyMath();
			Console.WriteLine($"Add = {obj.Add(30,40)}");
			Console.WriteLine($"Sub = {obj.Sub(30, 40)}");
			Console.WriteLine($"Seuare = {obj.Square(20,30)}");

			string str = "My length is calculated using Extension method";
			Console.WriteLine($"Length of {str} = {str.GetStringLength()}");

			Console.ReadLine();
		}
	}


	public sealed class MyMath
	{
		public int Add(int x, int y)
		{
			return x + y;
		}
		public int Sub(int x, int y)
		{
			return x - y;
		}
	}

	public static class Extension 
	{
		public static int Square(this MyMath m, int x, int y)
		{
			return (x * x) + 2 * x * y + (y * y);
		}

		public static int GetStringLength(this string str)
		{
			return str.Length;
		}
	}
}
