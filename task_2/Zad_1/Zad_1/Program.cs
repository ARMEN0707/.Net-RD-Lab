using System;

namespace Zad_1
{
    class RootNumber
    {
        private double _eps  = 0.0001;

        public double Eps
        {
            get { return _eps; }
            set { _eps = value < 0 ? _eps = 0 : _eps = value; }
        }

        public RootNumber(double eps)
        {
            Eps = eps;
        }

        public double Sqrt(double number, double degree)
        {
            double x0 = number / degree;            
            double x1 = GetNumber(number, degree, x0);

            while (Math.Abs(x1 - x0) > Eps)
            {
                x0 = x1;
                x1 = GetNumber(number, degree, x0);
            }

            return x1;
        }

        private double GetNumber(double number, double degree, double x0) => (1 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
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

            RootNumber rn = new RootNumber(eps);
            double result = rn.Sqrt(number, degree);
            double resultPow = Math.Pow(result, degree);
            if (Math.Abs(number - resultPow) < rn.Eps)
            {
                Console.WriteLine("Result: " + result);
            }
            else
            {
                Console.WriteLine("Result don't equals Math.Pow()");
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
