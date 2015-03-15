using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
		private double[] _solution;
		private List<IterationData> _iterationsData; 

		#endregion

		#region Properties



		#endregion

		#region Costructors

		public SeidelMethod(Matrix<double> inputMatrix, double[] vector)
		{
			_matrix = inputMatrix;
			_vector = vector;
			_iterationsData = new List<IterationData>();
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
			//start calculations
			do
			{
				//copy finded solution to previous solution array
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
				//save data about the first three iterations
				if (++iterationCount <= 3)
				{
					var copyCurrSol = new double[size];
					Array.Copy(currentSolution, copyCurrSol, size);
					IterationData iterationData;
					iterationData.solution = copyCurrSol;
					iterationData.difference = getDifferenceVector(currentSolution);
					iterationData.iterId = iterationCount;
					_iterationsData.Add(iterationData);
				}
			} while (!isEnd(eps: epsilon, curr: currentSolution, prev: previousSolution) || iterationCount == int.MaxValue);
			//save data about pre-last iteration
			IterationData data;
			data.solution = previousSolution;
			data.difference = getDifferenceVector(previousSolution);
			data.iterId = iterationCount - 1;
			_iterationsData.Add(data);
			//save last losultion
			_solution = currentSolution;
		}

		private bool isEnd(double[] curr, double[] prev, double eps)
		{
			var sum = curr.Select((cur, i) => (cur - prev[i])*(cur - prev[i])).Sum();
			return Math.Sqrt(sum) <= eps;
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
						*(pVerifyVector + i) += pMatrix[i * size + j] * pVector[j];
			}
			return verifyVector;
		}

		private double[] getDifferenceVector(double[] resultVector)
		{
			var res = verify(_matrix, resultVector);
			var difference = new double[resultVector.Length];
			for (int i = 0; i < res.Length; i++)
				difference[i] = _vector[i] - res[i];
			return difference;
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
			Console.WriteLine("------ Result vector -----");
			calculate(_matrix, _vector);
			foreach (var a in _solution)
				Console.WriteLine("{0,10:0.0000000}", a);
			Console.WriteLine();
			Console.WriteLine("---- difference vector ---");
			var ver = verify(_matrix, _solution);
			for (int i = 0; i < ver.Length; i++)
				Console.WriteLine(_vector[i] - ver[i]);
			Console.WriteLine();
			Console.WriteLine("---- Iterations data -----");
			foreach (var iterationData in _iterationsData)
			{
				Console.WriteLine("Iteration # {0,3} --\n", iterationData.iterId);
				Console.Write("   -- vector --\n   ");
				foreach (var sol in iterationData.solution)
					Console.Write("{0,10:0.0000000}  ", sol);
				Console.WriteLine("\n");
				Console.Write("   - difference -\n   ");
				foreach (var d in iterationData.difference)
					Console.Write("{0,10:0.0000000}  ", d);
				Console.WriteLine();
				Console.WriteLine();
			}
		}

		#endregion

		#region Events



		#endregion

		struct IterationData
		{
			public int iterId;
			public double[] solution;
			public double[] difference;
		}
	}
}
