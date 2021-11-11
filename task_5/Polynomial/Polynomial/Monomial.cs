using System;
namespace Polynomial
{
    public class Monomial
    {
        public double Epsilon
        {
            get { return 0.00001; }
        }
        public int Degree;
        public double Coefficient;

        public Monomial(int degree, double coefficient)
        {
            Degree = degree;
            Coefficient = coefficient;
        }

        public static Monomial operator +(Monomial leftMonomial, Monomial rightMonomial)
        {
            if (leftMonomial == null || rightMonomial == null)
                throw new ArgumentNullException("Monomial cannot be null");

            if (leftMonomial.Degree == rightMonomial.Degree)
                return new Monomial(leftMonomial.Degree, leftMonomial.Coefficient + rightMonomial.Coefficient);
            else
                throw new ArgumentException("Different degree");
        }

        public static Monomial operator -(Monomial leftMonomial, Monomial rightMonomial)
        {
            if (leftMonomial == null || rightMonomial == null)
                throw new ArgumentNullException("Monomial cannot be null");

            if (leftMonomial.Degree == rightMonomial.Degree)
                return new Monomial(leftMonomial.Degree, leftMonomial.Coefficient - rightMonomial.Coefficient);
            else
                throw new ArgumentException("Different degree");
        }

        public static Monomial operator *(Monomial leftMonomial, Monomial rightMonomial)
        {
            if (leftMonomial == null || rightMonomial == null)
                throw new ArgumentNullException("Monomial cannot be null");

            return new Monomial(
                leftMonomial.Degree + rightMonomial.Degree,
                leftMonomial.Coefficient * rightMonomial.Coefficient
                );
        }

        public static bool operator ==(Monomial leftMonomial, Monomial rightMonomial)
        {
            if ((object)rightMonomial == null)
                return (object)leftMonomial == null;

            if ((object)leftMonomial == null)
                return (object)rightMonomial == null;

            if (leftMonomial.Degree == rightMonomial.Degree)
                if (Math.Abs(leftMonomial.Coefficient - rightMonomial.Coefficient) <= leftMonomial.Epsilon)
                    return true;

            return false;
        }

        public static bool operator !=(Monomial leftMonomial, Monomial rightMonomial)
        {
            return !(leftMonomial == rightMonomial);
        }

        public override bool Equals(object obj)
        {
            if (obj is Monomial)
            {
                return this == obj as Monomial;
            }

            return false;
        }

        public override string ToString()
        {
            string text = "";
            if(Coefficient != 0 && Coefficient != 1 && Coefficient != -1)
            {
                text += Coefficient.ToString();
                if (Degree != 0)
                    text += Degree == 1 ? "*x" : "*x^" + Degree;
            }
            else
            {
                if (Coefficient != 0)
                {
                    if (Degree == 0)
                        text += "1";
                    else
                        text += Degree == 1 ? "x" : "x^" + Degree;

                    if (Coefficient < 0)
                        text = "-" + text;
                }
            }

            return text;
        }

        public double CalculateValue(double x)
        {
            if (Degree == 0)
                return Coefficient;
            else
                return Coefficient * Math.Pow(x, Degree);
        }
    }
}
