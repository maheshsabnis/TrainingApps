using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS_Task_Operations
{
	class Program
	{
		static void Main(string[] args)
		{
			Task t1 = Task.Run(()=> FileOperations.ReadFile1());
			t1.Wait(); // waiting for the to complete its execution

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"Some other operations on Main Thread {i}");
			}
			Console.WriteLine();
			Task t2 = Task.Run(() => FileOperations.ReadFile2());
			t2.Wait();
			// Make sure that all Tasks are completed
			//Task.WaitAll(t1,t2);

			// Task that is returning string
			Task t3 = Task<string>.Run(()=> {
				return FileOperations.ReadFile1Return();
			}).ContinueWith((t) =>
			{
				// read the data received after the completion of task
				Console.WriteLine($"Received data {t.Result.ToUpper()}");	
			}, TaskContinuationOptions.OnlyOnRanToCompletion);

			t3.Wait();


			Task t4 = Task.Run(()=> {
				FileOperations.ExceptionMethod();
			}).ContinueWith((t)=> {
				Console.WriteLine(t.Exception.Message);
			
			}, TaskContinuationOptions.OnlyOnFaulted);

			t4.Wait();
			Console.WriteLine("I am On Main Thread");
			Console.ReadLine();
		}
	}

	public static class FileOperations
	{
		public static void ReadFile1()
		{
			Thread.Sleep(2000);
			using (Stream fs = new FileStream(@"c:\Files\File1.txt", FileMode.Open, FileAccess.Read))
			{
				StreamReader Reader = new StreamReader(fs);
				 
				Console.WriteLine(Reader.ReadToEnd());
				Reader.Close();
			}
		}


		public static string ReadFile1Return()
		{
			string fileContents;
			Thread.Sleep(2000);
			using (Stream fs = new FileStream(@"c:\Files\File1.txt", FileMode.Open, FileAccess.Read))
			{
				StreamReader Reader = new StreamReader(fs);
				fileContents = Reader.ReadToEnd();
				Reader.Close();
			}

			return fileContents;
		}



		public static void ReadFile2()
		{
			Thread.Sleep(2000);
			using (Stream fs = new FileStream(@"c:\Files\File2.txt", FileMode.Open, FileAccess.Read))
			{
				StreamReader Reader = new StreamReader(fs);
				Console.WriteLine(Reader.ReadToEnd());
				Reader.Close();
			}
		}

		public static void ExceptionMethod()
		{
			throw new Exception("Method is crashed");
		}

	}
}
