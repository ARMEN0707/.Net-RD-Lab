using NUnit.Framework;
using System;
using System.Reflection;

namespace Polynomial.Test
{
    public class PolynomialTests
    {

        [Test]
        public void Constructor_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { var polynomial = new Polynomial((Monomial[])null); }, "Coefficients cannot be null.");
        }

        [Test]
        public void Constructor_ArrayIsEmpty_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => { var polynomial = new Polynomial(Array.Empty<Monomial>()); }, "Coefficients cannot be empty.");

        public void Constructor_StringIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { var polynomial = new Polynomial((string)null); }, "String cannot be null.");
        }

        [Test]
        public void Constructor_StringIsEmpty_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => { var polynomial = new Polynomial(""); }, "String cannot be empty.");

        [Test]
        public void Constructor_ArrayIsNull_ThrowArgumentException() => Assert.Throws<ArgumentNullException>(() => new Polynomial((Monomial[])null));

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool Equals_Object_ReturnsBollean(Polynomial polynomial, object obj) => polynomial.Equals(obj);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool Equals_Polynomial_ReturnsPolynomial(Polynomial polynomial, Polynomial other) => polynomial.Equals(other);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorEqual_Polynomial_ReturnsPolynomial(Polynomial leftPolynimial, Polynomial rightPolynimial) => leftPolynimial == rightPolynimial;

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorNotEqual_Polynomial_ReturnsPolynomial(Polynomial leftPolynimial, Polynomial rightPolynimial) => !(leftPolynimial != rightPolynimial);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAddition))]
        public void Addition_Polynomial_ReturnsPolynomial(Polynomial leftPolynimial, Polynomial rightPolynimial, Polynomial sum)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(leftPolynimial + rightPolynimial, sum);
                Assert.AreEqual(Polynomial.Add(leftPolynimial, rightPolynimial), sum);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void Addition_OnePolynomialEqualsNull_ThrowArgumentNullException(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var polynomial = leftPolynimial + rightPolynimial;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForSubtraction))]
        public void Subtraction_Polynomial_ReturnsPolynomial(Polynomial leftPolynimial, Polynomial rightPolynimial, Polynomial difference)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(leftPolynimial - rightPolynimial, difference);
                Assert.AreEqual(Polynomial.Subtract(leftPolynimial, rightPolynimial), difference);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void Subtraction_OnePolynomialsEqualsNull_ThrowArgumentNullException(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var polynomial = leftPolynimial - rightPolynimial;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForMultiplication))]
        public void Multiplication_Polynomial_ReturnsPolynomial(Polynomial leftPolynimial, Polynomial rightPolynimial, Polynomial product)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(leftPolynimial * rightPolynimial, product);
                Assert.AreEqual(Polynomial.Multiply(leftPolynimial, rightPolynimial), product);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void Multiplication_OnePolynomialsEqualsNull_ThrowArgumentNullException(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var polynomial = leftPolynimial * rightPolynimial;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexer))]
        public double Indexer_IndexCoefficient_ReturnCoefficient(Polynomial polynomial, int index) => polynomial[index].Coefficient;

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexerException))]
        public void Indexer_IndexCoefficient_ThrowArgumentOutOfRangeException(Polynomial polynomial, int index)
            => Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var value = polynomial[index];
            });

    }
}