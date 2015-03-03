using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
	 class Program
	 {

		private static void Main(string[] args)
		{
			var data = new string[] {"1", "2", "3"};
			var result = GetComb(data.ToList(), new List<string>());
			foreach (var lst in result)
				output(lst);

			Console.ReadKey();

		}

		private static IEnumerable<List<string>> GetComb(List<string> arg, List<string> awithout)
		{
			if (arg.Count == 1)
			{
				var result = new List<List<string>> {new List<string>() {arg[0]}};
				result[0].Add(arg[0]);
				return result;
			}
			else
			{
				var result = new List<List<string>>();

				foreach (var first in arg)
				{
					var others0 = new List<string>(arg.Except(new string[1] {first}));
					awithout.Add(first);
					var others = new List<string>(others0.Except(awithout));

					var combinations = GetComb(others, awithout);
					awithout.Remove(first);

					foreach (var tail in combinations)
					{
						tail.Insert(0, first);
						result.Add(tail);
					}
				}
				return result;
			}
		}

		private static void output(IEnumerable<string> arg)
		{
			foreach (var str in arg)
				Console.Write(str);
			Console.WriteLine();
		}
	}

}
