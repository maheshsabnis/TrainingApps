using NUnit.Framework;
using CS_DB_Access;
using CS_DB_Access.Models;
using Moq;
namespace CS_Moq_Test
{
	public class Tests
	{

		Dal dal;
		CitusTrainingContext context;
		BizLogic biz;

		[SetUp]
		public void Setup()
		{
			context = new CitusTrainingContext();
			dal = new Dal(context);
			biz = new BizLogic(dal);
		}

		[Test]
		public void GetCategoryByIdTest()
		{
			var result = dal.GetCategory(1);

			Assert.That(result, Is.EqualTo(true));
		}


		[Test]
		public void CheckCategpryExistsBizLogicTest()
		{
			int catRowId = 1;
			// Dsefine a Fake Object using Mock
			// The fake object will be created based on Schema of IService interface 
			// The Fake object with the method from IService Schame I 
			Mock<IService> mock = new Mock<IService>();
			// Setup the mock object with the method implementation
			mock.Setup(c=>c.GetCategory(It.IsAny<int>())).Returns(true);

			// CReate an instance of the Actual object and pass
			// the mock object as depednency to it
			// passing fake object will make sure that 
			// while testing the method from BizLogic class
			// the method from the fake object will be invoked 
			BizLogic biz = new BizLogic(mock.Object);
			// invoke the actual method
			var res = biz.IsCategoryExist(catRowId);
			// assertion
			Assert.That(res , Is.EqualTo(true));

		}


	}
}