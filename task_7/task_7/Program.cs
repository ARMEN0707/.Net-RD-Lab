using System;

namespace task_7
{
    public class Matrix
    {
        public static double s_epsilon = 0.000001f;
        private double[,] _elements;
        public int Row { get; }
        public int Column { get; }

        public Matrix(int row, int column, params double[] elements)
        {
            if (elements.Length != row * column)
                throw new ArgumentException("Incorrect number elements");

            Row = row;
            Column = column;
            _elements = new double[row, column];
            int k = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    _elements[i, j] = elements[k];
                    k++;
                }
            }
        }

        public double this[int row, int column]
        {

            get
            {
                if (row < 0 || column < 0 || row >= Row || column >= Column || Row == 0 || Column == 0)
                    throw new ArgumentOutOfRangeException("Index is not a valid");

                return _elements[row, column];
            }
            private set
            {
                if (row < 0 || column < 0 || row >= Row || column >= Column || Row == 0 || Column == 0)
                    throw new ArgumentOutOfRangeException("Index is not a valid");

                _elements[row, column] = value;
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    str += (_elements[i, j] + " ");
                }
                str += "\n";
            }
            return str;
        }

        public static Matrix operator +(Matrix lMatrix, Matrix rMatrix)
        {
            if (lMatrix == null || rMatrix == null)
                throw new ArgumentNullException("Matrix is not null");
            if ((lMatrix.Row != rMatrix.Row) || (lMatrix.Column != rMatrix.Column))
                throw new ArgumentException("Matrix different rang.");

            double[] newMatrix = new double[lMatrix.Row * lMatrix.Column];

            int k = 0;
            for (int i = 0; i < lMatrix.Row; i++)
            {
                for (int j = 0; j < lMatrix.Column; j++)
                {
                    newMatrix[k] = lMatrix[i, j] + rMatrix[i, j];
                    k++;
                }
            }

            return new Matrix(lMatrix.Row, lMatrix.Column, newMatrix);
        }

        public static Matrix operator -(Matrix lMatrix, Matrix rMatrix)
        {
            if (lMatrix == null || rMatrix == null)
                throw new ArgumentNullException("Matrix is not null");
            if ((lMatrix.Row != rMatrix.Row) || (lMatrix.Column != rMatrix.Column))
                throw new ArgumentException("Matrix different rang.");

            double[] newMatrix = new double[lMatrix.Row * lMatrix.Column];

            int k = 0;
            for (int i = 0; i < lMatrix.Row; i++)
            {
                for (int j = 0; j < lMatrix.Column; j++)
                {
                    newMatrix[k] = lMatrix[i, j] - rMatrix[i, j];
                    k++;
                }
            }

            return new Matrix(lMatrix.Row, lMatrix.Column, newMatrix);
        }

        public static Matrix operator *(Matrix lMatrix, Matrix rMatrix)
        {
            if (lMatrix == null || rMatrix == null)
                throw new ArgumentNullException("Matrix is not null");
            if ((lMatrix.Row != rMatrix.Row) || (lMatrix.Column != rMatrix.Column))
                throw new ArgumentException("Matrix different rang.");

            double[] newMatrix = new double[lMatrix.Row * lMatrix.Column];

            int k = 0;
            for (int i = 0; i < lMatrix.Row; i++)
            {
                for (int j = 0; j < lMatrix.Column; j++)
                {
                    for (int x = 0; x < lMatrix.Row; x++)
                    {
                        newMatrix[k] += lMatrix[i, x] * rMatrix[x, j];
                    }
                    k++;
                }
            }

            return new Matrix(lMatrix.Row, lMatrix.Column, newMatrix);
        }

        public static Matrix operator *(Matrix lMatrix, double number)
        {
            if (lMatrix == null)
                throw new ArgumentNullException("Matrix is not null");

            double[] newMatrix = new double[lMatrix.Row * lMatrix.Column];
            int k = 0;
            for (int i = 0; i < lMatrix.Row; i++)
            {
                for (int j = 0; j < lMatrix.Column; j++)
                {
                    newMatrix[k] += lMatrix[i, j] * number;
                    k++;
                }
            }

            return new Matrix(lMatrix.Row, lMatrix.Column, newMatrix);
        }

        public static bool operator ==(Matrix lMatrix, Matrix rMatrix)
        {
            if ((object)rMatrix == null)
                return (object)lMatrix == null;

            if ((lMatrix.Row != rMatrix.Row) || (lMatrix.Column != rMatrix.Column))
                return false;


            for (int i = 0; i < lMatrix.Row; i++)
            {
                for (int j = 0; j < lMatrix.Column; j++)
                {
                    if (Math.Abs(lMatrix[i, j] - rMatrix[i, j]) >= s_epsilon)
                        return false;
                }
            }

            return true;
        }

        public static bool operator !=(Matrix lMatrix, Matrix rMatrix)
        {
            return !(lMatrix == rMatrix);
        }

        public static Matrix Add(Matrix lMatrix, Matrix rMatrix)
        {
            return lMatrix + rMatrix;
        }

        public static Matrix Subtract(Matrix lMatrix, Matrix rMatrix)
        {
            return lMatrix - rMatrix;
        }

        public static Matrix Multiply(Matrix lMatrix, Matrix rMatrix)
        {
            return lMatrix * rMatrix;
        }

        public static Matrix Multiply(Matrix lMatrix, double number)
        {
            return lMatrix * number;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix)
            {
                return this == obj as Matrix;
            }

            return false;
        }

        public bool Equals(Matrix other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Matrix(Row, Column, (double[])_elements.Clone());
        }
    }
    class Program
    {

        static void Main(string[] args)
        { 
            
        }
    }
}
