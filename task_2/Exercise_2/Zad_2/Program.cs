using System;

namespace Zad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = GetNumber();
            var convertor = new ConvertorNumber();

            Console.WriteLine("Result: " + convertor.Convert(number));

            Console.ReadLine();
        }

        static int GetNumber()
        {
            int  number;
            string str = Console.ReadLine();
            while (!int.TryParse(str, out number))
            {
                Console.WriteLine("Invalid data. For example: 2");
                str = Console.ReadLine();
            }
            return number;
        }        
    }
}
