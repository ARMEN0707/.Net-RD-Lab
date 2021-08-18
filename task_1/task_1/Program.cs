using System;
using System.Globalization;
using System.IO;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-us");
            try
            {
                using (StreamReader sr = new StreamReader("InputData.txt"))
                {
                    string str;
                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        string[] numbers = str.Split(new char[] { ',' });

                        if (numbers.Length == 2)
                        {
                            bool isCorrect = true;
                            foreach (string number in numbers)
                            {
                                double num;
                                if (!double.TryParse(number, NumberStyles.AllowDecimalPoint, culture, out num))
                                {
                                    isCorrect = false;
                                    Console.WriteLine("Invalid data " + str);
                                    break;
                                }
                            }
                            if (isCorrect)
                                Console.WriteLine("X: " + numbers[0] + " Y: " + numbers[1]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid data " + str);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("File is not find.");
            }

            Console.ReadLine();
        }
    }
}
