using CS_ParallelInvoke.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace CS_ParallelInvoke
{
	class Program
	{
		static void Main(string[] args)
		{
			Parallel.Invoke(
				  ()=> FileOperations.ReadFile1(),
				  ()=> FileOperations.ReadFile2()
				);
			
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

	}


	 
	 
}
