using NUnit.Framework;
using System;

namespace task_3.Test
{
    public class EuclideanAlgorithmTests
    {
        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(24, 16, ExpectedResult = 8)]
        public int FindGreatestCommonDivisor_TwoNumbers_ReturnsNumber(int firstNumber, int secondNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber);
        }

        [TestCase(10, -5)]
        [TestCase(24, 0)]
        public void FindGreatestCommonDivisor_TwoNumbers_ThrowArgumentException(int firstNumber, int secondNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            Assert.Throws<ArgumentException>(() => { euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber); }, "Number can not be less than or equal 0");
        }

        [TestCase(324, 111, 432, ExpectedResult = 3)]
        [TestCase(243, 134, 121, ExpectedResult = 1)]
        public int FindGreatestCommonDivisor_ThreeNumbers_ReturnsNumber(int firstNumber, int secondNumber, int thridNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber);
        }

        [TestCase(324, 111, 432, 234, ExpectedResult = 3)]
        [TestCase(243, 134, 121, 321, ExpectedResult = 1)]
        public int FindGreatestCommonDivisor_FourNumbers_ReturnsNumber(int firstNumber, int secondNumber, int thridNumber, int fourthNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber, fourthNumber);
        }

        [TestCase(20, 16, 24, 32, 48, ExpectedResult = 4)]
        [TestCase(243, 134, 121, 423, 23, ExpectedResult = 1)]
        public int FindGreatestCommonDivisor_FiveNumbers_ReturnsNumber(int firstNumber, int secondNumber, int thridNumber, int fourthNumber, int fifthNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber, fourthNumber, fifthNumber);
        }

        [TestCase(20, 16, ExpectedResult = 4)]
        [TestCase(0, 4, ExpectedResult = 4)]
        [TestCase(11, 33, ExpectedResult = 11)]
        public int FindGreatestCommonDivisorBinaryAlgorithm_TwoNumbers_ReturnsNumber(int firstNumber, int secondNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            long time;
            return euclideanAlgorithm.FindGreatestCommonDivisorBinaryAlgorithm(firstNumber, secondNumber, out time);
        }
    }
}