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
        public int TestFindNodForTwoNumbers(int a, int b)
        {
            EuclideanAlgorithm algorithm = new EuclideanAlgorithm();
            return algorithm.FindNod(a, b);
        }

        [TestCase(324, 111, 432, ExpectedResult = 3)]
        [TestCase(0, 4, 45, ExpectedResult = 0)]
        [TestCase(10, -5, 34, ExpectedResult = 0)]
        [TestCase(243, 134, 121, ExpectedResult = 1)]
        public int TestFindNodForThreeNumbers(int a, int b, int c)
        {
            EuclideanAlgorithm algorithm = new EuclideanAlgorithm();
            return algorithm.FindNod(a, b, c);
        }

        [TestCase(324, 111, 432, 234, ExpectedResult = 3)]
        [TestCase(43, 4, 0, 54, ExpectedResult = 0)]
        [TestCase(10, 43, 214, -5, ExpectedResult = 0)]
        [TestCase(243, 134, 121, 321, ExpectedResult = 1)]
        public int TestFindNodForFourNumbers(int a, int b, int c, int d)
        {
            EuclideanAlgorithm algorithm = new EuclideanAlgorithm();
            return algorithm.FindNod(a, b, c, d);
        }

        [TestCase(20, 16, 24, 32, 48, ExpectedResult = 4)]
        [TestCase(0, 4, 45, 345, 0, ExpectedResult = 0)]
        [TestCase(10, -5, 34, 532, -10, ExpectedResult = 0)]
        [TestCase(243, 134, 121, 423, 23, ExpectedResult = 1)]
        public int TestFindNodForFiveNumbers(int a, int b, int c, int d, int e)
        {
            EuclideanAlgorithm algorithm = new EuclideanAlgorithm();
            return algorithm.FindNod(a, b, c, d, e);
        }

        [TestCase(20, 16, ExpectedResult = 4)]
        [TestCase(0, 4, ExpectedResult = 4)]
        [TestCase(10, -5, ExpectedResult = 0)]
        [TestCase(11, 33, ExpectedResult = 11)]
        public int TestFindNodBinaryAlgorithm(int a, int b)
        {
            EuclideanAlgorithm algorithm = new EuclideanAlgorithm();
            long time;
            return algorithm.FindNodBinaryAlgorithm(a, b, out time);
        }
    }
}