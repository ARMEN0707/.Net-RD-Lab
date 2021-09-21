using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace task_1
{
    class Program
    {
        static void EnterPointFromConsole(List<Point> points)
        {
            Console.Write("Enter the X coordinate of the point: ");
            double x = StringConverter.GetNumericValueDouble(Console.ReadLine());
            Console.Write("Enter the Y coordinate of the point: ");
            double y = StringConverter.GetNumericValueDouble(Console.ReadLine());
            points.Add(new Point(x, y));
            Console.Clear();
            Console.WriteLine("Point add");
        }

        static void Main(string[] args)
        {
            int choose;
            var points = new List<Point>();

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
                        choose = StringConverter.GetNumericValueInt(Console.ReadLine());
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
                            var readerFile = new FileReader("InputData.txt");
                            readerFile.ReadPointsFromFile(points);
                            break;
                        case 2:
                            var readerJson = new JsonReader("InputDataJson.json");
                            readerJson.ReadPointsFromFile(points);
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
