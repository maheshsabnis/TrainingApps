using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CS_Delegate_Event
{
	public class StringOperatoins
	{
		public string ChangeCase(string str, char c)
		{
			// Execution is blocked for 3 seconds
			Thread.Sleep(3000); // wait for 3 seconds

			if (c == 'U' || c == 'u') return str.ToUpper();
			if (c == 'L' || c == 'l') return str.ToLower();
			return str;
		}
	}
}
