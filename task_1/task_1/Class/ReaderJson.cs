using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace task_1
{
    class ReaderJson : IReaderPoint
    {
        private string _nameFile;

        public ReaderJson(string nameFile)
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
                    points.AddRange(JsonConvert.DeserializeObject<List<Point>>(coordinatePoint));
                }
            }
            Console.WriteLine("Points read");
        }
    }
}
