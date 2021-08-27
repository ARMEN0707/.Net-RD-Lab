using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

namespace task_1
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(string str)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-us");
            string[] numbers = str.Split(new char[] { ',' });
            double x = 0, y = 0;

            if (numbers.Length == 2)
            {
                if (!double.TryParse(numbers[0], NumberStyles.AllowDecimalPoint, culture, out x))
                    throw new ArgumentException("Invalid data " + str);

                if (!double.TryParse(numbers[1], NumberStyles.AllowDecimalPoint, culture, out y))
                    throw new ArgumentException("Invalid data " + str);
            }
            else
            {
                throw new ArgumentException("Invalid data " + str);
            }

            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();

            try
            {
                using (StreamReader sr = new StreamReader("InputData.txt"))
                {
                    string str;
                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        points.Add(new Point(str));
                    }
                }

                foreach (Point point in points)
                {
                    Console.WriteLine(point.ToString());
                }
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
