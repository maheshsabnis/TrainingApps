using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Delegate_Event
{
	// declaring the delegate
	public delegate void TransactionHandler(decimal amt);

	public class Banking
	{
		// declare event
		public event TransactionHandler OverBalance;
		public event TransactionHandler UnderBalance;

		decimal netBalance = 0;
		decimal openingBalance = 0;
		public Banking(decimal opbal)
		{
			openingBalance = opbal;
			netBalance = opbal;
		}

		public void Deposit(decimal tramt)
		{
			netBalance += tramt;
			// raise the event
			if (netBalance > 100000)
			{
				OverBalance(tramt);
			}
		}

		public void Withdrawal(decimal tramt)
		{
			netBalance -= tramt;
			// raise the event
			if (netBalance < 5000)
			{
				UnderBalance(tramt);
			}
		}

		public decimal GetNetBalance()
		{
			return netBalance;
		}
	}


	/// <summary>
	/// The Event Listener class. THis class is responsible for
	/// listening to the events and providing notification
	/// </summary>
	public class EventListener
	{
		Banking bank;
		/// <summary>
		/// Linking between the Listener class and the Claa that raises event
		/// THis will make sure that when an event is raised on Bank class the event listener
		/// will listen to it and process it
		/// </summary>
		/// <param name="b"></param>
		public EventListener(Banking b)
		{
			bank = b;
			// subscribe to the events
			bank.OverBalance += Bank_OverBalance;
			bank.UnderBalance += Bank_UnderBalance;
		}

		private void Bank_UnderBalance(decimal amt)
		{
			Console.WriteLine($"Your current balamce is Rs. {bank.GetNetBalance()}" +
				$" please maintain Rs. 5000 as minnimum balance fr each quarter end");
		}

		private void Bank_OverBalance(decimal amt)
		{
			var taxableAmount = bank.GetNetBalance() - 100000;
			var tax = taxableAmount * Convert.ToDecimal(0.02);
			Console.WriteLine($"Dear Account Holder your current banlance is {bank.GetNetBalance()}" +
				$"which is Rs. ${taxableAmount} more than Rs. 100000" +
				$" So pleae pay tax of Rs. {tax} else I-T will properly take care of you...");
		}
	}

	 
}
