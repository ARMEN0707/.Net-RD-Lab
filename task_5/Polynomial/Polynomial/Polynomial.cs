using System;

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
                throw new ArgumentNullException("coefficients cannot be null.");

            if (coefficients.Length == 0)
                throw new ArgumentException("coefficients cannot be empty.");

            _coefficients = (double[])coefficients.Clone();
        }

        public Polynomial(string value)
        {
            if (value == null)
                throw new ArgumentNullException("String cannot be null.");

            if (value.Length == 0)
                throw new ArgumentException("String cannot be empty.");

            string[] summands = value.Split('+');
            _coefficients = new double[summands.Length];
            foreach (var summand in summands)
            {
                string[] multipliers = summand.Split('*');
                if(multipliers.Length == 1)
                {
                    _coefficients[0] = double.Parse(multipliers[0]);
                }
                else
                {
                    string[] degrees = multipliers[1].Split('^');
                    if (degrees.Length == 1)
                    {
                        _coefficients[1] = double.Parse(multipliers[0]);
                    }
                    else
                    {
                        _coefficients[int.Parse(degrees[1])] = double.Parse(multipliers[0]);
                    }
                }
            }
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < _coefficients.Length)
                    return _coefficients[index];
                else
                    throw new ArgumentOutOfRangeException("index is not a valid");
            }

            private set
            {
                if (index >= 0 && index < _coefficients.Length)
                    _coefficients[index] = value;
                else
                    throw new ArgumentOutOfRangeException("index is not a valid");
            }
        }

        public static Polynomial operator +(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if (leftPolynimial == null || rightPolynimial == null)
                throw new ArgumentNullException("Polynomial cannot be null");

            double[] newCoefficients;
            int size = Math.Max(leftPolynimial._coefficients.Length, rightPolynimial._coefficients.Length);
            newCoefficients = new double[size];

            for (int i = 0; i < size; i++)
            {
                double a = 0;
                double b = 0;

                if (i < leftPolynimial._coefficients.Length)
                    a = leftPolynimial[i];

                if (i < rightPolynimial._coefficients.Length)
                    b = rightPolynimial[i];

                newCoefficients[i] = a + b;
            }

            return new Polynomial(newCoefficients);
        }

        public static Polynomial operator -(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if (leftPolynimial == null || rightPolynimial == null)
                throw new ArgumentNullException("Polynomial cannot be null");

            double[] newCoefficients;
            int size = Math.Max(leftPolynimial._coefficients.Length, rightPolynimial._coefficients.Length);
            newCoefficients = new double[size];

            for (int i = 0; i < size; i++)
            {
                double a = 0;
                double b = 0;

                if (i < leftPolynimial._coefficients.Length)
                    a = leftPolynimial[i];

                if (i < rightPolynimial._coefficients.Length)
                    b = rightPolynimial[i];

                newCoefficients[i] = a - b;
            }

            return new Polynomial(newCoefficients);
        }

        public static Polynomial operator *(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if (leftPolynimial == null || rightPolynimial == null)
                throw new ArgumentNullException("Polynomial cannot be null");

            double[] newCoefficients = new double[leftPolynimial._coefficients.Length + rightPolynimial._coefficients.Length - 1];
            for (int i = 0; i < leftPolynimial._coefficients.Length; i++)
            {
                for (int j = 0; j < rightPolynimial._coefficients.Length; j++)
                {
                    double number = leftPolynimial[i] * rightPolynimial[j];
                    int degrees = i + j;
                    newCoefficients[degrees] += number;
                }
            }

            return new Polynomial(newCoefficients);
        }

        public static bool operator ==(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if ((object)rightPolynimial == null)
                return (object)leftPolynimial == null;

            if ((object)leftPolynimial == null)
                return (object)rightPolynimial == null;


            if (leftPolynimial._coefficients.Length == rightPolynimial._coefficients.Length)
            {
                for (int i = 0; i < rightPolynimial._coefficients.Length; i++)
                {
                    if (Math.Abs(leftPolynimial[i] - rightPolynimial[i]) >= s_Epsilon)
                        return false;
                }

                return true;
            }

            return false;
        }

        public static bool operator !=(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            return !(leftPolynimial == rightPolynimial);
        }

        public static Polynomial Add(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            return leftPolynimial + rightPolynimial;
        }

        public static Polynomial Subtract(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            return leftPolynimial - rightPolynimial;
        }

        public static Polynomial Multiply(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            return leftPolynimial * rightPolynimial;
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
}
