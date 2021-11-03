using System;

namespace Polynomial
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter first polynomial: ");
                    string polynomial = Console.ReadLine();
                    var firstPolynomial = new Polynomial(polynomial);
                    Console.Write("Enter second polynomial: ");
                    polynomial = Console.ReadLine();
                    var secondPolynomial = new Polynomial(polynomial);
                    Console.WriteLine("Addition: " + (firstPolynomial + secondPolynomial));
                    Console.WriteLine("Subtraction: " + (firstPolynomial - secondPolynomial));
                    Console.WriteLine("Multiplication: " + (firstPolynomial * secondPolynomial));

                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
