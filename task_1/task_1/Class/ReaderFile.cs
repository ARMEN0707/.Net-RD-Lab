using System;
using System.Collections.Generic;
using System.IO;

namespace task_1
{
    class ReaderFile : IReaderPoint
    {
        private string _nameFile;

        public ReaderFile(string nameFile)
        {
            _nameFile = nameFile;
        }
        public void ReadPointsFromFile(List<Point> points)
        {
            using (var reader = new StreamReader(_nameFile))
            {
                string coordinatePoint;
                while (!reader.EndOfStream)
                {
                    coordinatePoint = reader.ReadLine();
                    string[] numbers = coordinatePoint.Split(new char[] { ',' });
                    if (numbers.Length != 2)
                        throw new ArgumentException("Invalid data " + coordinatePoint);

                    points.Add(new Point(
                        ConvertString.GetNumericValueDouble(numbers[0]),
                        ConvertString.GetNumericValueDouble(numbers[1])
                        ));
                }
            }
            Console.WriteLine("Points read");
        }
    }
}
