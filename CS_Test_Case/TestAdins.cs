using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace CS_Test_Case
{
	[TestFixture]
	public class TestAdins
	{
		[Test]
		public void TestCollections()
		{
			List<string> lst1 = new List<string>();
			lst1.Add("Mahesh");
			lst1.Add("Sabnis");
			List<string> lst2 = new List<string>();
			lst2.Add("Mahesh");
			lst2.Add("Sabnis");

			// Check for Simple Euqality of collection
			// Collection Has Same COunt and COntains Exact Same Elements in Same Order
			//CollectionAssert.AreEqual(lst1,lst2);

			// Check if the Collection contains record / value
			// CollectionAssert.Contains(lst1, "Mahesh");

			// Check if the collection contains specific type of data
			CollectionAssert.AllItemsAreInstancesOfType(lst1, typeof(string), "All Items are same of type string");
		}


		[Test]
		public void TestCollectionForAllUnique()
		{
			List<string> lst1 = new List<string>();
			lst1.Add("Mahesh");
			lst1.Add("Sabnis");
			// lst1.Add("Sabnis");
			CollectionAssert.AllItemsAreUnique(lst1);
		}


	
	}
}
