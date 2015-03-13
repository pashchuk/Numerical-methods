using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace lab1
{
	public class SquaresMethod
	{
		#region Fields

		private Matrix<double> _matrix;
		private double[] _vector;

		#endregion

		#region Properties



		#endregion

		#region Costructors

		public SquaresMethod(Matrix<double> matrix, double[] vector)
		{
			_matrix = matrix;
			_vector = vector;
		}

		#endregion

		#region private Methods

		private Matrix<double> factorise()
		{
			var temp = new Matrix<double>(_matrix.Rows);
			for (int i = 0; i < _matrix.Rows; i++)
			{
				double sum = 0;
				for (int k = 0; k < i; k++)
					sum += temp[k, i]*temp[k, i];
				temp[i, i] = Math.Sqrt(_matrix[i, i] - sum);
				for (int j = i + 1; j < _matrix.Columns; j++)
				{
					sum = 0;
					for (int k = 0; k < i; k++)
						sum += temp[k, i]*temp[k, j];
					temp[i, j] = temp[j,i] = (_matrix[i, j] - sum)/temp[i, i];
				}
			}
			return temp;
		}

		private double[] Check(Matrix<double> matrix, double[] vector)
		{
			var y = new double[vector.Length];
			var x = new double[vector.Length];
			for (int i = 0; i < vector.Length; i++)
			{
				double sum = 0;
				for (int k = 0; k < i; k++)
					sum += matrix[k, i]*y[k];
				y[i] = (vector[i] - sum)/matrix[i, i];
			}
			for (int i = vector.Length-1; i >= 0; i--)
			{
				double sum = 0;
				for (int k = i + 1; k < vector.Length; k++)
					sum += matrix[i, k]*x[k];
				x[i] = (y[i] - sum) / matrix[i, i];
			}
			return x;
		}

		#endregion

		#region public Methods

		public void Solve()
		{
			_matrix.Print(Console.Out);
			Console.WriteLine();
			var f2 = factorise();
			Console.WriteLine();
			f2.Print(Console.Out);
			Console.WriteLine();
			var res = Check(f2, _vector);
			foreach (var a in res)
				Console.WriteLine(a);
		}

		#endregion

		#region Events



		#endregion
	}
}