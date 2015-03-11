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

		public Matrix<double> factorise()
		{
			var temp = new Matrix<double>(_matrix.Rows);
			temp[0, 0] = Math.Sqrt(_matrix[0, 0]);
			for (int i = 1; i < _matrix.Columns; i++)
				temp[0, i] = temp[i,0] = _matrix[0, i]/temp[0, 0];
			for (int i = 1; i < _matrix.Rows; i++)
			{
				double sum = 0;
				for (int k = 0; k < i; k++)
					sum += _matrix[k, i] * _matrix[k, i];
				temp[i, i] = Math.Sqrt(_matrix[i, i] - sum);
			}
			for(int i = 1; i < _matrix.Rows; i++)
				for (int j = i + 1; j < _matrix.Columns; j++)
				{
					double sum = 0;
					for (int k = 0; k < i; k++)
						sum += temp[k, i]*temp[k, j];
					temp[i, j] = temp[j,i] = (_matrix[i, j] - sum)/temp[i, i];
				}
			return temp;
		}
		public Matrix<double> factorise2()
		{
			var temp = new Matrix<double>(_matrix.Rows);
			for (int i = 0; i < _matrix.Rows; i++)
				for (int j = 0; j <= i; j++)
				{
					double sum = 0;
					for (int k = 0; k < j; k++)
						sum += _matrix[i, k] * _matrix[j, k];
					temp[i, j] = temp[j, i] = j == i ? Math.Sqrt(_matrix[i, j] - sum) : (_matrix[i, j] - sum) / temp[j, j];
				}
			return temp;
		}

		public double[] Check(Matrix<double> matrix, double[] vector)
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
			for (int i = vector.Length-1; i > 0; i--)
			{
				double sum = 0;
				for (int k = i; k < vector.Length; k++)
					sum += matrix[i, k] * x[k];
				y[i] = (y[i] - sum) / matrix[i, i];
			}
			return y;
		}

		#endregion

		#region public Methods

		public void Solve()
		{
			_matrix.Print(Console.Out);
			Console.WriteLine();
			var f1 = factorise2();
			var f2 = factorise();
			f1.Print(Console.Out);
			Console.WriteLine();
			f2.Print(Console.Out);
			Console.WriteLine();
			foreach (var a in Check(f1, _vector))
				Console.WriteLine(a);
			Console.WriteLine();
			foreach (var a in Check(f2, _vector))
				Console.WriteLine(a);
		}

		#endregion

		#region Events



		#endregion
	}
}