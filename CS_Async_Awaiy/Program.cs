using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Async_Await
{
	class Program
	{
		static async Task Main(string[] args)
		{

			FileOPerations op = new FileOPerations();
			await op.ManipulateFile(@"c:\datafile.txt");

			Console.ReadLine();
		}
	}


	public class FileOPerations
	{
		/// <summary>
		/// Using async the CLR knows that the method will be executed asynchronously
		/// and the 'await' represents that the caller to wait for the compltion signal
		/// from the Worker Thread when the asynchronous oepartion is completed
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public async Task ManipulateFile(string fileName)
		{
			try
			{
				using (Stream fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
				{
					var sw = new StreamWriter(fs);
					// Writing the file Asynchronously
					await sw.WriteLineAsync("The file will be written asynchronously");
					Console.WriteLine("Write is Successfull");
					sw.Close();
				}
				Console.WriteLine("Performing Read Operations");
				using (Stream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					var sr = new StreamReader(fs);
					// reading the file asynchronously
					var result =  await sr.ReadToEndAsync();
					sr.Close(); 
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error While Processing Request {ex.Message}");
				throw;
			}
		}
	}
}
