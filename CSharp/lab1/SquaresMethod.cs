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
				for (int j = i; j < _matrix.Columns; j++)
				{
					double sum = 0;
					for (int k = 0; k < i; k++)
						sum += temp[k, i]*temp[k, j];
					temp[i, j] = temp[j, i] = (i == j) ? Math.Sqrt(_matrix[i, i] - sum) : (_matrix[i, j] - sum)/temp[i, i];
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

		private unsafe double[] verify(Matrix<double> sourceMatrix, double[] resultVector)
		{
			var size = resultVector.Length;
			var verifyVector = new double[size];
			fixed (double* pMatrix = sourceMatrix.GetMatrixPointer(),
				pVector = resultVector, pVerifyVector = verifyVector)
			{
				for (int i = 0; i < size; i++)
					for (int j = 0; j < size; j++)
						*(pVerifyVector + i) += pMatrix[i*size + j]*pVector[j];
			}
			return verifyVector;
		}

		#endregion

		#region public Methods

		public void Solve()
		{
			Console.WriteLine("------ Input matrix ------");
			_matrix.Print(Console.Out);
			Console.WriteLine();
			Console.WriteLine("------ Input vector ------");
			foreach (var d in _vector)
				Console.Write("{0:0.000}  ", d);
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("---- Factorise matrix ----");
			var f2 = factorise();
			f2.Print(Console.Out);
			Console.WriteLine();
			Console.WriteLine("------ Result vector -----");
			var res = Check(f2, _vector);
			foreach (var a in res)
				Console.WriteLine(a);
			Console.WriteLine();
			Console.WriteLine("---- difference vector ---");
			var ver = verify(_matrix, res);
			for (int i = 0; i < ver.Length; i++)
				Console.WriteLine(_vector[i] - ver[i]);
		}

		#endregion

		#region Events



		#endregion
	}
}