using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
	public class Matrix<T> where T : struct 
	{
		#region Fields

		private T[,] _matrix;

		#endregion

		#region Properties

		public T this[int row, int column]
		{
			get { return _matrix[row, column]; }
			set { _matrix[row, column] = value; }
		}

		#endregion

		#region Costructors

		public Matrix(int rows, int columns)
		{
			_matrix = new T[rows, columns];
		}

		public Matrix(int size) : this(size, size) { }

		#endregion

		#region private Methods



		#endregion

		#region public Methods



		#endregion

		#region Events



		#endregion
	}
}
