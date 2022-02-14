using System;
using System.Collections.Generic;
using System.Text;

namespace task_7
{
    public class Matrix
    {
        private const double s_epsilon = 0.000001f;
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
            int indexElement = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    _elements[i, j] = elements[indexElement];
                    indexElement++;
                }
            }
        }

        public double this[int row, int column]
        {
            get
            {
                CheckIndex(row, column);

                return _elements[row, column];
            }
            set
            {
                CheckIndex(row, column);

                _elements[row, column] = value;
            }
        }

        private void CheckIndex(int row, int column)
        {
            if (row < 0 || column < 0 || row >= Row || column >= Column || Row == 0 || Column == 0)
                throw new ArgumentOutOfRangeException("Index is not a valid");
        }

        private static void CheckMatrix(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix == null || secondMatrix == null)
                throw new ArgumentNullException("Matrix is not null");
            if ((firstMatrix.Row != secondMatrix.Row) || (firstMatrix.Column != secondMatrix.Column))
                throw new ArgumentException("Matrix different rang.");
        }

        private static void CheckMatrix(Matrix matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("Matrix is not null");
        }

        private static Matrix CalculateMatrix(Matrix firstMatrix, Matrix secondMatrix, Action<double[], int, int, int> calculate, bool forOneMatrix = false)
        {
            if(forOneMatrix)
                CheckMatrix(firstMatrix);
            else
                CheckMatrix(firstMatrix, secondMatrix);

            double[] newMatrix = new double[firstMatrix.Row * firstMatrix.Column];

            int indexNewMatrix = 0;
            for (int i = 0; i < firstMatrix.Row; i++)
            {
                for (int j = 0; j < firstMatrix.Column; j++)
                {
                    calculate(newMatrix, indexNewMatrix, i, j);
                    indexNewMatrix++;
                }
            }

            return new Matrix(firstMatrix.Row, firstMatrix.Column, newMatrix);
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    text += (_elements[i, j] + " ");
                }
                text += "\n";
            }
            return text;
        }

        public static Matrix operator +(Matrix lMatrix, Matrix rMatrix)
        {
            return CalculateMatrix(
                lMatrix,
                rMatrix,
                (numbers, index, indexRow, indexColumn) 
                    => numbers[index] = lMatrix[indexRow, indexColumn] + rMatrix[indexRow, indexColumn]
                );
        }

        public static Matrix operator -(Matrix lMatrix, Matrix rMatrix)
        {
            return CalculateMatrix(
                lMatrix,
                rMatrix,
                (numbers, index, indexRow, indexColumn)
                    => numbers[index] = lMatrix[indexRow, indexColumn] - rMatrix[indexRow, indexColumn]
                );
        }

        public static Matrix operator *(Matrix lMatrix, Matrix rMatrix)
        {
            return CalculateMatrix(
                lMatrix,
                rMatrix,
                (numbers, index, indexRow, indexColumn) =>
                    {
                        for (int x = 0; x < lMatrix.Row; x++)
                        {
                            numbers[index] += lMatrix[indexRow, x] * rMatrix[x, indexColumn];
                        }
                    }
                );
        }

        public static Matrix operator *(Matrix lMatrix, double number)
        {
            return CalculateMatrix(
                lMatrix,
                null,
                (numbers, index, indexRow, indexColumn)
                    => numbers[index] = lMatrix[indexRow, indexColumn] * number,
                true
                );
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
}
