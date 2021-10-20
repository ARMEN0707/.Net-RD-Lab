using NUnit.Framework;
using System;
namespace Task_4.Test
{
    public class TriangleTests
    {
        [TestCase(1, 2, 3)]
        [TestCase(5, 13, 3)]
        [TestCase(5.5, 13, 3.2)]
        [TestCase(1, 0, 3)]
        [TestCase(0, 2, 3)]
        [TestCase(1, 2, 0)]
        [TestCase(-4, 2, 3)]
        public void Constructor_MultipleNumbers_ThrowArgumentException(double firstSide, double secondSide, double thirdSide) =>
            Assert.Throws<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide), message: "Triangle cannot exist.");

        [TestCase(5, 6, 3, ExpectedResult = 7.483314773547883)]
        [TestCase(7, 3, 5, ExpectedResult = 6.49519052838329)]
        [TestCase(12, 4, 9, ExpectedResult = 13.635890143294644)]
        public double Square_MultipleNumbers_ReturnsNumber(double firstSide, double secondSide, double thirdSide)
        {
            Triangle treangle = new Triangle(firstSide, secondSide, thirdSide);
            return treangle.GetSquare();
        }

        [TestCase(5, 6, 3, ExpectedResult = 14)]
        [TestCase(7, 3, 5, ExpectedResult = 15)]
        public double Perimeter_MultipleNumbers_ReturnsNumber(double firstSide, double secondSide, double thirdSide)
        {
            Triangle treangle = new Triangle(firstSide, secondSide, thirdSide);
            return treangle.GetPerimeter();
        }
    }
}