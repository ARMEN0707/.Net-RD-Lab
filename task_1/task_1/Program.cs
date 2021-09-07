using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace task_1
{
    class Program
    {       
        static void ReadPointsFromFile(List<Point> points)
        {
            using (StreamReader reader = new StreamReader("InputData.txt"))
            {
                string coordinatesPoint;
                while (!reader.EndOfStream)
                {
                    coordinatesPoint = reader.ReadLine();
                    string[] numbers = coordinatesPoint.Split(new char[] { ',' });
                    if (numbers.Length != 2)
                        throw new ArgumentException("Invalid data " + coordinatesPoint);

                    points.Add(new Point(
                        ConvertString.GetNumericValueDouble(numbers[0]),
                        ConvertString.GetNumericValueDouble(numbers[1])
                        ));
                }
            }
            Console.WriteLine("Points read");
        }

        static void ReadPointsFromJsonFile(ref List<Point> points)
        {
            using (StreamReader reader = new StreamReader("InputDataJson.json"))
            {
                string coordinatesPoint;
                while (!reader.EndOfStream)
                {
                    coordinatesPoint = reader.ReadLine();
                    points = JsonConvert.DeserializeObject<List<Point>>(coordinatesPoint);
                }
            }
            Console.WriteLine("Points read");
        }

        static void EnterPointFromConsole(List<Point> points)
        {
            Console.Write("Enter the X coordinate of the point: ");
            double x = ConvertString.GetNumericValueDouble(Console.ReadLine());
            Console.Write("Enter the Y coordinate of the point: ");
            double y = ConvertString.GetNumericValueDouble(Console.ReadLine());
            points.Add(new Point(x, y));
            Console.Clear();
            Console.WriteLine("Point add");
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
                        Console.WriteLine("2-Read points from a Json file");
                        Console.WriteLine("3-Enter point");
                        Console.WriteLine("4-Print points");
                        Console.WriteLine("5-Exit");
                        choose = ConvertString.GetNumericValueInt(Console.ReadLine());
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
                            ReadPointsFromFile(points);
                            break;
                        case 2:
                            ReadPointsFromJsonFile(ref points);
                            break;
                        case 3:
                            EnterPointFromConsole(points);
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        
            Console.ReadKey();
        }
    }
}
