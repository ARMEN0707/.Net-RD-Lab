using NUnit.Framework;
using System;
using System.Reflection;

namespace Polynomial.Test
{
    public class Tests
    {

        [Test]
        public void ConstructorArrayIsNullThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { var polynomial = new Polynomial(null); }, "Coefficients cannot be null.");
        }

        [Test]
        public void ConstructorArrayIsEmptyThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => { var polynomial = new Polynomial(Array.Empty<double>()); }, "Coefficients cannot be empty.");

        [Test]
        public void ConstructorArrayIsNullThrowArgumentException() => Assert.Throws<ArgumentNullException>(() => new Polynomial(null));

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool EqualsWithObjectParameter(Polynomial polynomial, object obj) => polynomial.Equals(obj);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForToString))]
        public string ToStringReturnPolynomialStringRepresentation(Polynomial polynomial) => polynomial.ToString();

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForGetHashCode))]
        public void GetHashCodePolynomialAreEqualsThusGetHashCodeAreEquals(Polynomial polynomial, Polynomial other)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(polynomial, other);
                Assert.AreEqual(polynomial.GetHashCode(), other.GetHashCode());
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool EqualsWithPolynomialParameter(Polynomial polynomial, Polynomial other) => polynomial.Equals(other);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorEqual(Polynomial lhs, Polynomial rhs) => lhs == rhs;

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForEquals))]
        public bool OperatorNotEqualTests(Polynomial lhs, Polynomial rhs) => !(lhs != rhs);

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForAddition))]
        public void AdditionOfPolynomials(Polynomial lhs, Polynomial rhs, Polynomial sum)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lhs + rhs, sum);
                Assert.AreEqual(Polynomial.Add(lhs, rhs), sum);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void AdditionOneOfPolynomialsIsEqualsNullThrowArgumentNullException(Polynomial lhs, Polynomial rhs)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var polynomial = lhs + rhs;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForSubtraction))]
        public void SubtractionOfPolynomials(Polynomial lhs, Polynomial rhs, Polynomial difference)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lhs - rhs, difference);
                Assert.AreEqual(Polynomial.Subtract(lhs, rhs), difference);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void SubtractionOneOfPolynomialsIsEqualsNullThrowArgumentNullException(Polynomial lhs, Polynomial rhs)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var polynomial = lhs - rhs;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForMultiplication))]
        public void MultiplicationOfPolynomials(Polynomial lhs, Polynomial rhs, Polynomial product)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(lhs * rhs, product);
                Assert.AreEqual(Polynomial.Multiply(lhs, rhs), product);
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForOperationException))]
        public void MultiplicationOneOfPolynomialsIsEqualsNullThrowArgumentNullException(Polynomial lhs, Polynomial rhs)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var polynomial = lhs * rhs;
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForClone))]
        public void CloneReturnShallowCopyOfPolynomial(Polynomial polynomial)
        {
            Polynomial clone = (Polynomial)polynomial.Clone();

            FieldInfo? fieldInfo = polynomial.GetType().GetField("coefficients", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(polynomial, clone);
                Assert.AreSame(fieldInfo?.GetValue(polynomial), fieldInfo?.GetValue(clone));
            });
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexer))]
        public double IndexerReturnCoefficientByIndex(Polynomial polynomial, int index) => polynomial[index];

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForIndexerException))]
        public void IndexerIndexOutOfDegreeThrowArgumentOutOfRangeException(Polynomial polynomial, int index)
            => Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var value = polynomial[index];
            });

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForCalculateValue))]
        public void CalculateValueReturnValueInPoint(Polynomial polynomial, double x, double value)
        {
            Assert.AreEqual(value, polynomial.CalculateValue(x), Polynomial.s_Epsilon);
        }
    }
}