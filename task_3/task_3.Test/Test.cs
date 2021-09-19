using NUnit.Framework;

namespace task_3.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, 4, ExpectedResult = 2)]
        [TestCase(0, 4, ExpectedResult = 0)]
        [TestCase(10, -5, ExpectedResult = 0)]
        [TestCase(24, 16, ExpectedResult = 8)]
        public int TestFindGreatestCommonDivisorForTwoNumbers(int firstNumber, int secondNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber);
        }

        [TestCase(324, 111, 432, ExpectedResult = 3)]
        [TestCase(0, 4, 45, ExpectedResult = 0)]
        [TestCase(10, -5, 34, ExpectedResult = 0)]
        [TestCase(243, 134, 121, ExpectedResult = 1)]
        public int TestFindGreatestCommonDivisorForThreeNumbers(int firstNumber, int secondNumber, int thridNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber);
        }

        [TestCase(324, 111, 432, 234, ExpectedResult = 3)]
        [TestCase(43, 4, 0, 54, ExpectedResult = 0)]
        [TestCase(10, 43, 214, -5, ExpectedResult = 0)]
        [TestCase(243, 134, 121, 321, ExpectedResult = 1)]
        public int TestFindGreatestCommonDivisorForFourNumbers(int firstNumber, int secondNumber, int thridNumber, int fourthNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber, fourthNumber);
        }

        [TestCase(20, 16, 24, 32, 48, ExpectedResult = 4)]
        [TestCase(0, 4, 45, 345, 0, ExpectedResult = 0)]
        [TestCase(10, -5, 34, 532, -10, ExpectedResult = 0)]
        [TestCase(243, 134, 121, 423, 23, ExpectedResult = 1)]
        public int TestFindGreatestCommonDivisorForFiveNumbers(int firstNumber, int secondNumber, int thridNumber, int fourthNumber, int fifthNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            return euclideanAlgorithm.FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber, fourthNumber, fifthNumber);
        }

        [TestCase(20, 16, ExpectedResult = 4)]
        [TestCase(0, 4, ExpectedResult = 4)]
        [TestCase(10, -5, ExpectedResult = 0)]
        [TestCase(11, 33, ExpectedResult = 11)]
        public int TestFindGreatestCommonDivisorBinaryAlgorithm(int firstNumber, int secondNumber)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            long time;
            return euclideanAlgorithm.FindGreatestCommonDivisorBinaryAlgorithm(firstNumber, secondNumber, out time);
        }
    }
}