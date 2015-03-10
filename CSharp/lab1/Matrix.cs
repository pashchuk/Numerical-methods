using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
		public int Rows { get { return _matrix.GetLength(0); } }
		public int Columns { get { return _matrix.GetLength(1); } }
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

		public void SwapRows(int row1, int row2)
		{
			T tempvariable;
			for (int i = 0; i < Columns; i++)
			{
				tempvariable = _matrix[row1, i];
				_matrix[row1, i] = _matrix[row2, i];
				_matrix[row2, i] = tempvariable;
			}
		}
		public void SwapColumns(int column1, int column2)
		{
			T tempvariable;
			for (int i = 0; i < Rows; i++)
			{
				tempvariable = _matrix[i, column1];
				_matrix[i, column1] = _matrix[i, column2];
				_matrix[i, column2] = tempvariable;
			}
		}

		public int MaxInRow(int row)
		{
			throw new NotImplementedException();
		}
		public int MaxInRow(int row, out T maxValue)
		{
			throw new NotImplementedException();
		}
		public int MinInRow(int row)
		{
			throw new NotImplementedException();
		}
		public int MinInRow(int row, out T minValue)
		{
			throw new NotImplementedException();
		}
		public int MaxInColumn(int column)
		{
			throw new NotImplementedException();
		}
		public int MaxInColumn(int column, out T maxValue)
		{
			throw new NotImplementedException();
		}
		public int MinInColumn(int column)
		{
			throw new NotImplementedException();
		}
		public int MinInColumn(int column, out T minValue)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Events



		#endregion
	}
}
