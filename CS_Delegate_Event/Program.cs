using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Delegate_Event
{
	public delegate string StringHandler(string s, char c);


	class Program
	{
		static void Main(string[] args)
		{

			//	Caller c = new Caller();
			////c.Operations();
			//	c.AsyncDelegateOperations();

			Banking bank = new Banking(20000);
			// subscribe to the event listener
			// and pass the object to it so that
			// once the bank object raises an event the notification
			// will be generated and displayed
			EventListener listener = new EventListener(bank);
			bank.Deposit(90000);
			Console.WriteLine($"Net Balance after Deposit = {bank.GetNetBalance()}");
			bank.Withdrawal(126000);
			Console.WriteLine($"Net Balance after WIthdrawal = {bank.GetNetBalance()}");

			Console.ReadLine();
		}
	}

	public class Caller
	{
		public void Operations()
		{
			string str = "The String Operations";
			StringOperatoins strOP = new StringOperatoins();
			// define a delegate Type Instance
			// pass the method signeture to it
			StringHandler strDelegate = new StringHandler(strOP.ChangeCase);
			// invoke the method using the delegat

			// CLR will jump on the address of the method using invoke and the method
			// will be remotely executed 
			Console.WriteLine($"Upper case of {str} is = {strDelegate.Invoke(str, 'U')}");
			Console.WriteLine();
			Console.WriteLine($"Lower case of {str} is = {strDelegate(str, 'L')}");
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine($"Some Other Operation {i}");
			}

		}

		public void AsyncDelegateOperations()
		{
			string str = "The String Operations";
			StringOperatoins strOP = new StringOperatoins();
			 
			StringHandler strDelegate = new StringHandler(strOP.ChangeCase);

			// the ar is a monitor from the caller method 
			// that will notify the result when the call 
			// is completed from the Worker Thread
			IAsyncResult ar1 =  strDelegate.BeginInvoke(str, 'U', null, null);

			// perform some other operations on caller thread
			int i = 0;
			while (!ar1.IsCompleted)
			{ 
				Console.WriteLine($"Some Other Operation {i}");
				i++;
			}
			// collect the result returned from the Worker thread
			string result = strDelegate.EndInvoke(ar1);
			Console.WriteLine($"Upper case of {str} is = {result}");


			IAsyncResult ar2 = strDelegate.BeginInvoke(str, 'L', null, null);

			// perform some other operations on caller thread
			int j = 0;
			while (!ar2.IsCompleted)
			{
				Console.WriteLine($"Some Other Operation {j}");
				j++;
			}
			// collect the result returned from the Worker thread
			string result1 = strDelegate.EndInvoke(ar2);
			Console.WriteLine($"Upper case of {str} is = {result1}");

		}
	}
}
