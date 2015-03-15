using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Nums;

namespace lab2
{
	class Program
	{
		static void Main(string[] args)
		{
			Matrix<double> matrix = null;
			double[] vector = null;
			try{
				matrix = ReadMatrixFromFile("input.txt", out vector);
			}catch (Exception ex){
				MessageBox.Show(ex.Message);
				return;
			}
			var solver = new SeidelMethod(matrix, vector);
			solver.Solve();
			Console.ReadKey();
		}
		public static Matrix<double> ReadMatrixFromFile(string path, out double[] vector)
		{
			Matrix<double> matrix;
			var data = File.ReadAllLines(path)
				.Select(x => x.Split(' '))
				.Select(x => x.Select(Convert.ToDouble).ToArray())
				.ToArray();
			matrix = new Matrix<double>(data[0].Length);
			vector = new double[data[0].Length];
			for (int i = 0; i < data[0].Length; i++)
				for (int j = 0; j < data[0].Length; j++)
					matrix[i, j] = data[i][j];
			for (int i = 0; i < data[0].Length; i++)
				vector[i] = data[data.Length - 1][i];
			return matrix;
		}
	}
}
