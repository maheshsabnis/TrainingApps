using System;

namespace CS_Factory
{
	class Program
	{
		static void Main(string[] args)
		{
			IDb instance = DbFactory.GetDbInstanceFactory("SQL");
			instance.GetData();
			instance = DbFactory.GetDbInstanceFactory("MySQL");
			instance.GetData();
			Console.ReadLine();
		}
	}

	/// <summary>
	/// FActory class taht will reolve instance depednency using FActory Method
	/// to provide instance based on the dbProvider name
	/// </summary>
	public static class DbFactory
	{
		private static IDb instance;

		public static IDb GetDbInstanceFactory(string dbProvider)
		{
			MyDep dep = new MyDep();
			if (dbProvider == "SQL")
			{
				instance = new Sql(dep);
			}
			if (dbProvider == "MySQL")
			{
				instance = new MySql();			
			}
			return instance;
		}

	}



	public interface IDb
	{
		void GetData();
	}

	public class MyDep
	{
		public void Display()
		{
			Console.WriteLine("I am Dependency");
		}
	}

	public class Sql:IDb
	{
		MyDep dep;
		public Sql(MyDep d)
		{
			dep = d;
		}
		public void GetData()
		{
			dep.Display();
			Console.WriteLine("Data from SQL");
		}
	}

	public class MySql : IDb
	{
		public void GetData()
		{
			Console.WriteLine("Data from MySql");
		}
	}
}
