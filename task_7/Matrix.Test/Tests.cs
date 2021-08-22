using NUnit.Framework;
using System;
using task_7;

namespace Test
{
    public class Tests
    {
        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForConstructor))]
        public void Constructor_ThrowArgumentException(int row, int column, params double[] elements)
        {
            Assert.Throws<ArgumentException>(() => { Matrix matrix = new Matrix(row,column,elements); }, "Incorrect number elements.");
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexer))]
        public double Indexer_ReturnElementByIndex(Matrix matrix, int row, int column) => matrix[row,column];

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexerException))]
        public void Indexer_ThrowArgumentOutOfRangeException(Matrix matrix, int row, int column)
            => Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                double value = matrix[row, column];
            });

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForToString))]
        public string ToString_ReturnMatrixStringRepresentation(Matrix matrix, int row, int column) => matrix.ToString();

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAddition))]
        public void AdditionOfMatrixs(Matrix lMatrix, Matrix rMatrix, Matrix sum)
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
        public void SubtractionOfMatrix(Matrix lMatrix, Matrix rMatrix, Matrix difference)
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
        public void MultiplicationOfMatrix(Matrix lMatrix, Matrix rMatrix, Matrix difference)
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
        public bool Equals_WithMatrixParameter(Matrix lMatrix, Matrix rMatrix) => lMatrix.Equals(rMatrix);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorEqual(Matrix lMatrix, Matrix rMatrix) => lMatrix == rMatrix;

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorNotEqualTests(Matrix lMatrix, Matrix rMatrix) => !(lMatrix != rMatrix);

    }
}