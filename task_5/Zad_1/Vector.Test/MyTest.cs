using NUnit.Framework;
using System;
using task_5;

namespace Vector.Test
{
    public class Tests
    {
        [TestCase(1, 2, 3, ExpectedResult = 3.7416573867739413f)]
        [TestCase(3, -5, 3, ExpectedResult = 6.557438524302f)]
        [TestCase(1, 0, 6, ExpectedResult = 6.082762530298219f)]
        public float LengthPropertyTest(int x, int y, int z)
        {
            task_5.Vector vector = new task_5.Vector(x, y, z);
            return vector.Length;
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool EqualsWithObjectParameter(task_5.Vector vector, object obj) => vector.Equals(obj);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool EqualsWithVectorParameter(task_5.Vector vector, task_5.Vector other) => vector.Equals(other);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorEqual(task_5.Vector lVector, task_5.Vector rVector) => lVector == rVector;

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorNotEqualTests(task_5.Vector lVector, task_5.Vector rVector) => !(lVector != rVector);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAddition))]
        public void AdditionOfVector(task_5.Vector lVector, task_5.Vector rVector, task_5.Vector sum)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lVector + rVector, sum);
                Assert.AreEqual(task_5.Vector.Add(lVector, rVector), sum);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void AdditionOneOfVectorIsEqualsNullThrowArgumentNullException(task_5.Vector lVector, task_5.Vector rVector)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                task_5.Vector vector = lVector + rVector;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForSubtraction))]
        public void SubtractionOfVector(task_5.Vector lVector, task_5.Vector rVector, task_5.Vector difference)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lVector - rVector, difference);
                Assert.AreEqual(task_5.Vector.Subtract(lVector, rVector), difference);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void SubtractionOneOfVectorIsEqualsNullThrowArgumentNullException(task_5.Vector lVector, task_5.Vector rVector)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                task_5.Vector vector = lVector - rVector;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForMultiplication))]
        public void MultiplicationOfVector(task_5.Vector lVector, task_5.Vector rVector, task_5.Vector product)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lVector * rVector, product);
                Assert.AreEqual(task_5.Vector.Multiply(lVector, rVector), product);
            });
        }
        
        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForMultiplicationNumber))]
        public void MultiplicationOfVector(task_5.Vector lVector, float number, task_5.Vector product)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lVector * number, product);
                Assert.AreEqual(task_5.Vector.Multiply(lVector, number), product);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void MultiplicationOneOfPolynomialsIsEqualsNullThrowArgumentNullException(task_5.Vector lVector, task_5.Vector rVector)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                task_5.Vector vector = lVector * rVector;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForDivisionNumber))]
        public void DivisionOfVector(task_5.Vector lVector, float number, task_5.Vector product)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lVector / number, product);
                Assert.AreEqual(task_5.Vector.Division(lVector, number), product);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationExceptionWithOneVector))]
        public void MultiplicationNullparametrThrowArgumentNullException(task_5.Vector lVector, float number)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                task_5.Vector vector = lVector * number;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationExceptionWithOneVector))]
        public void DivisionNullparametrThrowArgumentNullException(task_5.Vector lVector, float number)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                task_5.Vector vector = lVector / number;
            });
        }

        
        public void DivisionZeroThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                task_5.Vector vector = new task_5.Vector(1.2f, 3.2f, 0) / 0;
            });
        }
    }
}