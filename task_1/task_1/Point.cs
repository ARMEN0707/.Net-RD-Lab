using System;
using System.Globalization;

namespace task_1
{
    class Point
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }

        public Point(double x, double y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }



        public override string ToString()
        {
            return "X: " + CoordinateX + " Y: " + CoordinateY;
        }
    }
}
