using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

namespace task_1
{
    class Program
    {
        static double GetNumericValueDouble(string str)
        {
            double number;
            if (!Double.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-us"), out number))
                throw new ArgumentException("Invalid data " + str);

            return number;
        }

        static int GetNumericValueInt(string str)
        {
            int number;
            if (!Int32.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-us"), out number))
                throw new ArgumentException("Invalid data " + str);

            return number;
        }

        static void Main(string[] args)
        {
            int choose;
            List<Point> points = new List<Point>();

            try
            {
                while (true)
                {
                    while (true)
                    {
                        Console.WriteLine("1-Read points from a file");
                        Console.WriteLine("2-Write a points in the file");
                        Console.WriteLine("3-Enter point");
                        Console.WriteLine("4-Print points");
                        Console.WriteLine("5-Exit");
                        choose = GetNumericValueInt(Console.ReadLine());
                        if (choose < 1 || choose > 5)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid data");
                            Console.ReadKey();
                        }
                        else
                            break;
                    }

                    Console.Clear();

                    switch(choose)
                    {
                        case 1:
                            using (StreamReader reader = new StreamReader("InputData.txt"))
                            {
                                string coordinatesPoint;
                                while (!reader.EndOfStream)
                                {
                                    coordinatesPoint = reader.ReadLine();
                                    string[] numbers = coordinatesPoint.Split(new char[] { ',' });
                                    if (numbers.Length != 2)
                                        throw new ArgumentException("Invalid data " + coordinatesPoint);

                                    points.Add(new Point(GetNumericValueDouble(numbers[0]), GetNumericValueDouble(numbers[1])));
                                }
                            }
                            Console.WriteLine("Points read");
                            break;
                        case 2:
                            using (StreamWriter writer = new StreamWriter("InputData.txt"))
                            {
                                foreach(Point point in points)
                                    writer.WriteLine($"{point.CoordinateX};{point.CoordinateY}");
                            }
                            Console.WriteLine("Points write");
                            break;
                        case 3:
                            Console.Write("Enter the X coordinate of the point: ");
                            double x = GetNumericValueDouble(Console.ReadLine());
                            Console.Write("Enter the Y coordinate of the point: ");
                            double y = GetNumericValueDouble(Console.ReadLine());
                            points.Add(new Point(x, y));
                            Console.Clear();
                            Console.WriteLine("Point add");
                            break;
                        case 4:
                            foreach (Point point in points)
                            {
                                Console.WriteLine(point.ToString());
                            }
                            break;
                        case 5:
                            return;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        
            Console.ReadLine();
        }
    }
}
