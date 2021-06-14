using CS_Frwk_UserStory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Delegate_Event;
namespace CS_MS_Test_DataSource
{
	[TestClass]
	public class UnitTest1
	{
		[DataTestMethod]
		[DataRow(10, 20)]
		public void AddTest(int x, int y)
		{
			var res = x + y;
			Assert.AreEqual(30, res);
		}


		private TestContext context;

		public TestContext TestContext
		{
			get { return context; }
			set { context = value; }

		}
		/// <summary>
		/// DataSource("TestNamespace with Provioder Driver e.g. CSV", "PATH-of-CSV-File", "Table-Name OR wroksheet name", Data Access Method to read data from file)
		/// </summary>
		/// <param name="uname"></param>
		/// <param name="pwd"></param>
		/// <param name="expected"></param>


		//[TestMethod]
		//[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\citus\SpotDemos\TrainingApps\CS_MS_Test_DataSource\bin\Debug\testdata.csv", "testdata#csv", DataAccessMethod.Sequential), DeploymentItem("testdata.csv"), TestMethod]


		[DataSource("System.Data.SqlClient", "Data Source=.;Integrated Security=SSPI;Initial Catalog=CitusTraining", "Users",DataAccessMethod.Sequential),TestMethod]

		public void TestAuthUserByCSV()
		{
			// Arrange data
			// access test data from the file

			string uname = TestContext.DataRow[0].ToString().Trim();
			string password = TestContext.DataRow[1].ToString().Trim();

			bool result = Convert.ToBoolean(TestContext.DataRow[2].ToString().Trim());
			AuthService auth = new AuthService();
			bool actual = auth.AuthUser(uname, password);
			Assert.AreEqual(result, actual);
		}


		[TestMethod]
		public void EventTesting()
		{
			Banking bank = new Banking(80000);
			// Defining the List to add events in it when they are raised
			List<string> events = new List<string>();
			// Subscribe to the event with the callback and add it in the 'events' list
			  bank.OverBalance += delegate (decimal amount)
			  {
				  // if the event is raised then it will be added in to the List of event
				  events.Add("OverBalance");	
			  };

			// call a method that may raise the event 
			bank.Deposit(300);
			Assert.AreEqual("OverBalance",events[0]);
		}

	}
}
