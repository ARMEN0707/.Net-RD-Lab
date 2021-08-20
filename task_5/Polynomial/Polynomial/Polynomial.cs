using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynomial
    {
        public static double s_Epsilon = 0.00001;
        private readonly double[] _coefficients;

        public int Degree
        {
            get { return _coefficients.Length; }
        }

        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                string message = "_coefficients cannot be null.";
                throw new ArgumentNullException(message);
            }

            if (coefficients.Length == 0)
            {
                string message = "_coefficients cannot be empty.";
                throw new ArgumentException(message);
            }

            _coefficients = (double[])coefficients.Clone();
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < _coefficients.Length)
                {
                    return _coefficients[index];
                }
                else
                {
                    string message = "index is not a valid";
                    throw new ArgumentOutOfRangeException(message);
                }
            }

            private set
            {
                if (index >= 0 && index < _coefficients.Length)
                {
                    _coefficients[index] = value;
                }
                else
                {
                    string message = "index is not a valid";
                    throw new ArgumentOutOfRangeException(message);
                }
            }
        }

        public static Polynomial operator +(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            if (lPolynimial == null || rPolynimial == null)
            {
                string message = "Polynomial cannot be null";
                throw new ArgumentNullException(message);
            }

            double[] result;
            int size = Math.Max(lPolynimial._coefficients.Length, rPolynimial._coefficients.Length);
            result = new double[size];

            for (int i = 0; i < size; i++)
            {
                double a = 0;
                double b = 0;

                if (i < lPolynimial._coefficients.Length)
                {
                    a = lPolynimial[i];
                }

                if (i < rPolynimial._coefficients.Length)
                {
                    b = rPolynimial[i];
                }

                result[i] = a + b;
            }

            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            if (lPolynimial == null || rPolynimial == null)
            {
                string message = "Polynomial cannot be null";
                throw new ArgumentNullException(message);
            }

            double[] result;
            int size = Math.Max(lPolynimial._coefficients.Length, rPolynimial._coefficients.Length);
            result = new double[size];

            for (int i = 0; i < size; i++)
            {
                double a = 0;
                double b = 0;

                if (i < lPolynimial._coefficients.Length)
                {
                    a = lPolynimial[i];
                }

                if (i < rPolynimial._coefficients.Length)
                {
                    b = rPolynimial[i];
                }

                result[i] = a - b;
            }

            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            if (lPolynimial == null || rPolynimial == null)
            {
                string message = "Polynomial cannot be null";
                throw new ArgumentNullException(message);
            }

            double[] result = new double[lPolynimial._coefficients.Length + rPolynimial._coefficients.Length - 1];
            for (int i = 0; i < lPolynimial._coefficients.Length; i++)
            {
                for (int j = 0; j < rPolynimial._coefficients.Length; j++)
                {
                    double number = lPolynimial[i] * rPolynimial[j];
                    int degree = i + j;
                    result[degree] += number;
                }
            }

            return new Polynomial(result);
        }

        public static bool operator ==(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            if ((object)rPolynimial == null)
            {
                return (object)lPolynimial == null;
            }

            if (lPolynimial._coefficients.Length == rPolynimial._coefficients.Length)
            {
                for (int i = 0; i < rPolynimial._coefficients.Length; i++)
                {
                    if (Math.Abs(lPolynimial[i] - rPolynimial[i]) >= s_Epsilon)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool operator !=(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            return !(lPolynimial == rPolynimial);
        }

        public static Polynomial Add(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            return lPolynimial + rPolynimial;
        }

        public static Polynomial Subtract(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            return lPolynimial - rPolynimial;
        }

        public static Polynomial Multiply(Polynomial lPolynimial, Polynomial rPolynimial)
        {
            return lPolynimial * rPolynimial;
        }

        public override bool Equals(object obj)
        {
            if (obj is Polynomial)
            {
                return this == obj as Polynomial;
            }

            return false;
        }

        public bool Equals(Polynomial other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (double number in _coefficients)
            {
                hash &= number.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            string text = null;
            for (int i = _coefficients.Length - 1; i > 0; i--)
            {
                double a = _coefficients[i];
                text += i == 1 ? a + "*x" : a + "*x^" + i;

                if (_coefficients[i - 1] > 0)
                {
                    text += "+";
                }
            }

            text += _coefficients[0];

            return text;
        }

        public double CalculateValue(double x)
        {
            double number = _coefficients[0];
            for (int i = _coefficients.Length - 1; i > 0; i--)
            {
                double a = _coefficients[i];
                number += i == 1 ? a * x : a * Math.Pow(x, i);
            }

            return number;
        }

        public object Clone()
        {
            return new Polynomial((double[])_coefficients.Clone());
        }
    }

    class Program
    {
        static void Main()
        {

        }
    }
}
