using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nums
{
	public class SeidelMethod
	{
		#region Fields

		private Matrix<double> _matrix;
		private double[] _vector;

		#endregion

		#region Properties



		#endregion

		#region Costructors

		public SeidelMethod(Matrix<double> inputMatrix, double[] vector)
		{
			_matrix = inputMatrix;
			_vector = vector;
		}

		#endregion

		#region private Methods

		private void calculate(Matrix<double> matrix, double[] vector)
		{
			const double epsilon = 0.0000001;
			var size = vector.Length;
			var currentSolution = new double[size];
			var previousSolution = new double[size];
			var iterationCount = 0;
			do
			{
				Array.Copy(currentSolution, previousSolution, size);
				for (int i = 0; i < size; i++)
				{
					var sum = default (double);
					for (int j = 0; j < i; j++)
						sum += currentSolution[j]*matrix[i, j];
					for (int j = i + 1; j < size; j++)
						sum += previousSolution[j]*matrix[i, j];
					currentSolution[i] = (vector[i] - sum)/matrix[i, i];
				}
				iterationCount++;
			} while (isEnd(eps: epsilon, curr: currentSolution, prev: previousSolution));
		}

		private bool isEnd(double[] curr, double[] prev, double eps)
		{
			var sum = curr.Select((cur, i) => (cur - prev[i])*(cur - prev[i])).Sum();
			return Math.Sqrt(sum) <= eps;
		}

		#endregion

		#region public Methods



		#endregion

		#region Events



		#endregion
	}
}
