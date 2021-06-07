using System;
using Core_MathLib;
namespace Core_SingleFilePublish
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			MathClass m = new MathClass();
			Console.WriteLine($"Add = {m.Add(200,300)}");
			Console.ReadLine();
		}
	}
}
