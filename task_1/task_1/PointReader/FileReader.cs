using System;
using System.Collections.Generic;
using System.IO;

namespace Task_1
{
    class FileReader : IPointReader
    {
        private string _nameFile;

        public FileReader(string nameFile)
        {
            _nameFile = nameFile;
        }
        public List<Point> ReadPointsFromFile()
        {
            var points = new List<Point>();
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
                        StringConverter.GetNumericValueDouble(numbers[0]),
                        StringConverter.GetNumericValueDouble(numbers[1])
                        ));
                }
            }
            Console.WriteLine("Points read");
            return points;
        }
    }
}
