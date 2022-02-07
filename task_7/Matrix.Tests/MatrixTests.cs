using NUnit.Framework;
using System;
using task_7;

namespace Tests
{
    public class MatrixTests
    {
        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForConstructor))]
        public void Constructor_MatrixValue_ThrowArgumentException(int row, int column, params double[] elements)
        {
            Assert.Throws<ArgumentException>(() => { Matrix matrix = new Matrix(row,column,elements); }, "Incorrect number elements.");
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexer))]
        public double Indexer_Index_ReturnElementByIndex(Matrix matrix, int row, int column) => matrix[row,column];

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexerException))]
        public void Indexer_Index_ThrowArgumentOutOfRangeException(Matrix matrix, int row, int column)
            => Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                double value = matrix[row, column];
            });

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForToString))]
        public string ToString_Matrix_ReturnMatrixStringRepresentation(Matrix matrix) => matrix.ToString();

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAddition))]
        public void Addition_Matrix(Matrix lMatrix, Matrix rMatrix, Matrix sum)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lMatrix + rMatrix, sum);
                Assert.AreEqual(Matrix.Add(lMatrix, rMatrix), sum);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void Addition_OneOfMatrixIsEqualsNull_ThrowArgumentNullException(Matrix lMatrix, Matrix rMatrix)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Matrix matrix = lMatrix + rMatrix;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForSubtraction))]
        public void Subtraction_Matrix(Matrix lMatrix, Matrix rMatrix, Matrix difference)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lMatrix - rMatrix, difference);
                Assert.AreEqual(Matrix.Subtract(lMatrix, rMatrix), difference);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void Subtraction_OneOfMatrixIsEqualsNull_ThrowArgumentNullException(Matrix lMatrix, Matrix rMatrix)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Matrix matrix = lMatrix - rMatrix;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForMultiplication))]
        public void Multiplication_Matrix(Matrix lMatrix, Matrix rMatrix, Matrix difference)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lMatrix * rMatrix, difference);
                Assert.AreEqual(Matrix.Multiply(lMatrix, rMatrix), difference);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void Multiplication_OneOfMatrixIsEqualsNull_ThrowArgumentNullException(Matrix lMatrix, Matrix rMatrix)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Matrix matrix = lMatrix * rMatrix;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool Equals_Matrix(Matrix lMatrix, Matrix rMatrix) => lMatrix.Equals(rMatrix);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorEqua_Matrixl(Matrix lMatrix, Matrix rMatrix) => lMatrix == rMatrix;

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorNotEqualTests_Matrix(Matrix lMatrix, Matrix rMatrix) => !(lMatrix != rMatrix);

    }
}