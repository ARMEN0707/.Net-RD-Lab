using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_1
{   
    class MethodNewton
    {
        public double Epsilon
        {
            get;
            private set;
        }

        public MethodNewton(double epsilon)
        {
            Epsilon = epsilon;
        }

        public double Sqrt(double number, double degree)
        {
            double argument = number / degree;
            double functionValue = GetFunctionValue(number, degree, argument);


            while (Math.Abs(functionValue - argument) > Epsilon)
            {
                argument = functionValue;
                functionValue = GetFunctionValue(number, degree, argument);
            }

            double resultPow = Math.Pow(functionValue, degree);

            if (Math.Abs(number - resultPow) < Epsilon)
                return functionValue;
            else
                throw new ArgumentException("Result don't equals Math.Pow()");
        }

        private double GetFunctionValue(double number, double degree, double argument) 
            => (1 / degree) * ((degree - 1) * argument + number / Math.Pow(argument, degree - 1));
    }
}
