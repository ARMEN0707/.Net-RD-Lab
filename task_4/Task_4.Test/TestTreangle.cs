using NUnit.Framework;
using System;
namespace Task_4.Test
{
    public class TestsTreangle
    {
        [TestCase(1, 2, 3)]
        [TestCase(5, 13, 3)]
        [TestCase(5.5, 13, 3.2)]
        [TestCase(1, 0, 3)]
        [TestCase(0, 2, 3)]
        [TestCase(1, 2, 0)]
        [TestCase(-4, 2, 3)]
        public void CheckTreangle_ThrowArgumentException(double a, double b, double c) =>
            Assert.Throws<ArgumentException>(() => new Treangle(a, b, c), message: "Triangle cannot exist.");

        [TestCase(5, 6, 3, ExpectedResult = 7.483314773547883)]
        [TestCase(7, 3, 5, ExpectedResult = 6.49519052838329)]
        [TestCase(12, 4, 9, ExpectedResult = 13.635890143294644)]
        public double SquareTest(double a, double b, double c)
        {
            Treangle treangle = new Treangle(a, b, c);
            return treangle.Square();
        }

        [TestCase(5, 6, 3, ExpectedResult = 14)]
        [TestCase(7, 3, 5, ExpectedResult = 15)]
        public double PerimeterTest(double a, double b, double c)
        {
            Treangle treangle = new Treangle(a, b, c);
            return treangle.Perimeter();
        }
    }
}