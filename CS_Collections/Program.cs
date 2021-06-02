using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CS_Collections
{
	class Program
	{
		static void Main(string[] args)
		{

			ArrayList arrayList = new ArrayList();
			arrayList.Add(10); // data will be stored as object 
			arrayList.Add(20);
			arrayList.Add(30);
			arrayList.Add(40);
			arrayList.Add(10.8);
			arrayList.Add(10.6);
			arrayList.Add("Mahesh");
			arrayList.Add("Vikram");
			arrayList.Add("Suprotim");
			arrayList.Add('A');
			arrayList.Add('B');
			arrayList.Add('C');

			// read data from the collection
			foreach (var enrty in arrayList)
			{
				/// checking the type for each entry
				if (enrty.GetType() == typeof(string))
				{
					Console.WriteLine(enrty);
				}
			}


			Console.ReadLine();
		}
	}
}
