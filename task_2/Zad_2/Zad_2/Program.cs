using System;

namespace Zad_2
{
    struct NumberConvertToBinaryCode
    {
        public string Convert(int number)
        {
            string str = "";

            while (number > 1)
            {
                int remainder = number % 2;
                number /= 2;
                str += remainder;
            }

            str += number;
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = GetNumber();
            NumberConvertToBinaryCode convertor = new NumberConvertToBinaryCode();

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
