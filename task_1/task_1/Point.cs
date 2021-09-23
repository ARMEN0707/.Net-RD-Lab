using System;
using System.Globalization;

namespace Task_1
{
    class Point
    {
        public double AxisX { get; set; }
        public double AxisY { get; set; }

        public Point(double x, double y)
        {
            AxisX = x;
            AxisY = y;
        }

        public override string ToString()
        {
            return $"X: {AxisX} Y: {AxisY}";
        }
    }
}
