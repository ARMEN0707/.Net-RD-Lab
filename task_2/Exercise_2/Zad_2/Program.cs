using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = GetNumber();
            var convertor = new NumberConvertor();
            
            try
            {
                Console.WriteLine("Result: " + convertor.Convert(number));
            }catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);                
            }


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
