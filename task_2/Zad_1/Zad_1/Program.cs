using System;

namespace Zad_1
{
    struct RootNumber
    {
        private readonly double _eps;

        public double Eps
        {
            get { return _eps; }
        }

        public RootNumber(double eps)
        {
            _eps = eps;
        }

        public double Sqrt(double number, double degree)
        {
            double x0 = number / degree;            
            double x1 = GetValue(number, degree, x0);


            while (Math.Abs(x1 - x0) > Eps)
            {
                x0 = x1;
                x1 = GetValue(number, degree, x0);
            }

            double resultPow = Math.Pow(x1, degree);

            if (Math.Abs(number - resultPow) < Eps)
                return x1;               
            else
                throw new ArgumentException("Result don't equals Math.Pow()");
        }

        private double GetValue(double number, double degree, double x0) => (1 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
    }

    class Program
    {
        static void Main(string[] args)
        {
            double number;
            double degree;
            double eps;
            Console.Write("Enter number: ");            
            number = GetNumber();
            Console.Write("Enter degree: ");
            degree = GetNumber();
            Console.Write("Enter eps: ");
            eps = GetNumber();

            try
            {
                RootNumber rn = new RootNumber(eps);
                double result = rn.Sqrt(number, degree);
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
