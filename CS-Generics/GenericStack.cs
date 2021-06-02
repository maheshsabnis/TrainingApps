using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Generics
{
	/// <summary>
	/// Generic class
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GenericStack<T>
	{
		// define a generic member
		T[] arr ;
		int top = 0;
		public GenericStack()
		{
			arr = new T[5];
		}
		
		// generic method
		public void Push(T item)
		{
			arr[top++] = item;
		}

		public T Pop()
		{
			 
			var x = arr[top-1];
			Console.WriteLine(top);
			return x;
		}

		public void List()
		{
			foreach (var item in arr)
			{
				Console.WriteLine(item);
			}
		}
	}
}
