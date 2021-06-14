using CS_User_Story;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
namespace CS_MS_Test
{
	[TestClass]
	public class UnitTest1
	{
		[DataTestMethod]
		[DataRow(10,20)]
		public void AddTest(int x,int y)
		{
			var res = x + y;
			Assert.AreEqual(30,res);
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


		[TestMethod]
		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\citus\SpotDemos\TrainingApps\CS_MS_Test\bin\Debug\testdata.csv", "testdata#csv", DataAccessMethod.Sequential), DeploymentItem("testdata.csv")]
		public void TestAuthUserByCSV()
		{
			// Arrange data
			// access test data from the file

			//string uname = TestContext["UserName"].ToString();
			//string password = TestContext.DataRow["Pasword"].ToString();


			AuthService auth = new AuthService();
			bool actual = auth.AuthUser("Mahesh", "mahesh");
			Assert.AreEqual(true, actual);
		}
	}
}
