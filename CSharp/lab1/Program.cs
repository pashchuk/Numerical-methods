using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
	 class Program
	 {

		public static void Main(string[] args)
		{
			var gaus = new SquaresMethod("input.txt");
		}

		 public class SquaresMethod
		 {
			 public double[,] Matrix { get; private set; }
			 public string Path { get; private set; }

			 public SquaresMethod(int size, double fillValue = 1.0)
			 {
				 Matrix = new double[size, size];
				 for (var i = 0; i < size; i++)
					 for (var j = 0; j < size; j++)
						 Matrix[i, j] = fillValue;
			 }

			 public SquaresMethod(string path)
			 {
				 try
				 {
					 var lines = File.ReadAllLines(path)
						 .Select(x => x.Split(' '))
						 .Select(x => x.Select(double.Parse).ToArray())
						 .ToArray();
					 var size = lines.Length;
					 Matrix = new double[size, size];
					 for(var i = 0; i < size; i++)
						 for (var j = 0; j < size; j++)
							 Matrix[i, j] = lines[i][j];
					 Path = Environment.CurrentDirectory + "\\" + path;

				 }
				 catch (FileNotFoundException ex)
				 {
					 MessageBox.Show(ex.Message, "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
				 }
			 }
		 }
	}

}
