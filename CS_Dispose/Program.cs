using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_Dispose
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Main");
			//MyClass m = new MyClass();
			//m.Display();
			//m.Dispose();
			using (MyClass m = new MyClass ())
			{
				m.Display();
			}
			Console.ReadLine();
		}
	}

	public class MyClass :  IDisposable
	{
		public MyClass()
		{
			Console.WriteLine("My CLass COnstructor Called");
		}

		public void Display()
		{
			Console.WriteLine("The DIsplay");		
		}

		public void Dispose()
		{
			// ask the CLR to immediately kill the object when the Dispose method is called
			GC.SuppressFinalize(this);
		}

		~MyClass() 
		{
			Console.WriteLine("My CLass Destructor  Called");
			Thread.Sleep(300);
			Console.ReadLine();
		}
	}
}
