using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCoverReportUpdater
{
	public class Program
	{
		static int Main(string[] args)
		{
			if (args.Length != 2)
				return Usage();

			string file = args[0];
			string newUrl = args[1];

			if (!File.Exists(file))
			{
				Console.WriteLine("File does not exist : " + file);
				return -1;
			}

			if (!newUrl.StartsWith("http://"))
			{
				Console.WriteLine("substitute url must start with 'http://' : " + newUrl);
				return -1;
			}

			string origFile = File.ReadAllText(file);
			string newFile = origFile.Replace("http://127.0.0.1:11235", newUrl);
			File.WriteAllText(file,newFile);
			return 0;
		}

		private static int Usage()
		{
			Console.WriteLine("Usage:");
			Console.WriteLine("NCoverReportUpdater.exe <NCoverOutputfile> <substitute url>");
			Console.WriteLine("Example:");
			Console.WriteLine("NCoverReportUpdater.exe fullcoveragereport.html http://wbsimms.com:81");
			return 1;
		}
	}
}
