using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using CS_User_Story;
namespace CS_Test_Case
{
	[TestFixture]
	public class TestContainer
	{
		[Test]
		public void NameTest()
		{
			// Arrange
			string Name = "Mahesh"; // expected 
			// Act
			string testName = "Mahesh1"; // actual
			// Assertion
			// Assert.AreEqual(Name,testName);
			Assert.AreNotEqual(Name, testName);
		}

		[Test]
		public void AddMethodTest()
		{
			// Arrange
			int x = 100;
			int y = 200;
			int expected = 300;
			Calculator calc = new Calculator();
			// Act
			int actual = calc.Add(x,y);
			// Assert
			Assert.AreEqual(expected,actual);
		}

		[Test]
		public void DivideTestSuccess()
		{
			// Arrange
			int x = 200;
			int y = 100;
			int expected = 2;
			Calculator calc = new Calculator();
			// Act
			int actual = calc.Divide(x, y);
			// Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void DivideByZeroExceptionTest()
		{
			// Arrange
			int x = 200;
			int y = 0;
			 
			Calculator calc = new Calculator();
			// Act
			 
			// Assertion for Exception
			// Act and Assertion both are done ata a time
			Assert.Throws<DivideByZeroException>(()=> calc.Divide(x,y));
		}

		// Throw the exception and make sure that the expected
		// excpetion message is thrown

		[Test]
		public void DivideByZeroExceptionMessageTest()
		{
			// Arrange
			int x = 200;
			int y = 0;

			Calculator calc = new Calculator();
			// Act
		 
			// Assertion for Exception
			// Act and Assertion both are done ata a time
			var ex = Assert.Throws<DivideByZeroException>(() => calc.Divide(x, y));

			Assert.AreEqual("Denominator cannot be zero", ex.Message);
			// OR
			Assert.That(ex.Message, Is.EqualTo("Denominator cannot be zero"));
		}

		// test the Divide(x,y) method to make sure that result is 0
		// if x = 0

		[Test]
		public void DivideNumeratorZeroTest()
		{
			// Arrange
			int x = 0;
			int y = 10;
			 
			Calculator calc = new Calculator();
			// Act
			int actual = calc.Divide(x,y);
			Assert.That(actual,Is.EqualTo(0));

		}



		/// <summary>
		/// Postive Test
		/// </summary>
		[Test]
		public void TestLoginSuccessful()
		{
			string uname = "Mahesh";
			string pwd = "mahesh";
			AuthService auth = new AuthService();
			var result = auth.Login(uname,pwd);
			Assert.That(result, Is.EqualTo("Login Successful"));
		}

		/// <summary>
		/// Positive Test to make sure that the Login Method
		/// Does not collapse for invalid data
		/// </summary>
		[Test]
		public void TestLoginFailed()
		{
			string uname = "Mahesh1";
			string pwd = "mahesh";
			AuthService auth = new AuthService();
			var result = auth.Login(uname, pwd);
			Assert.That(result, Is.EqualTo("Incorrect User Name or Password"));
		}

		/// <summary>
		/// Positive Test to make sura that the Login () methd
		/// workd for Null; or Emopty Values
		/// </summary>
		[Test]
		public void TestUserNamePasswordNullOrEmpty()
		{
			//string uname = string.Empty;
			//string pwd = string.Empty;

			string uname = null;
			string pwd =null;

			AuthService auth = new AuthService();
			var result = auth.Login(uname, pwd);
			Assert.That(result, Is.EqualTo("User Name or Pasword can ot be null or empty"));
		}


		// The Test Case working on multiple input values at a time
		[Test]
		[TestCase("Mahesh", "mahesh", true)]
		[TestCase("Tejas", "tejas", true)]
		[TestCase("Vivek", "Vivek", false)]
		[TestCase("Ajay", "ajay", false)]
		[TestCase("Mukesh", "mukesh", true)]
		[TestCase("Sandeep", "sandeep", true)]
		public void TestAuthUser(string uname, string pwd, bool expected)
		{
			AuthService auth = new AuthService();
			bool actual = auth.AuthUser(uname,pwd);
			Assert.AreEqual(expected,actual);
		}
	}
}
