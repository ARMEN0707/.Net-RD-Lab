using System;

namespace Zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double number;
            double degree;
            double epsilon;
            Console.Write("Enter number: ");            
            number = GetNumber();
            Console.Write("Enter degree: ");
            degree = GetNumber();
            Console.Write("Enter eps: ");
            epsilon = GetNumber();

            try
            {
                var methodNewton = new MethodNewton(epsilon);
                double result = methodNewton.Sqrt(number, degree);
                Console.WriteLine("Result: " + result);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        static double GetNumber()
        {
            double number;
            string str = Console.ReadLine();
            while (!double.TryParse(str, out number))
            {
                Console.WriteLine("Invalid data. For example: 1,56 or 2");
                str = Console.ReadLine();
            }
            return number;
        }
    }
}
