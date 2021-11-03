using System;
namespace Polynomial
{
    public class Monomial
    {
        public static double s_Epsilon = 0.00001;
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
                if (Math.Abs(leftMonomial.Coefficient - rightMonomial.Coefficient) <= s_Epsilon)
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {            
            if(Coefficient != 0 && Coefficient != 1 && Coefficient != -1)
            {
                if (Degree == 0)
                    return Coefficient.ToString();
                if (Degree == 1)
                    return Coefficient + "*x";

                return Coefficient + "*x^" + Degree;
            }
            else
            {
                if (Coefficient == 0)
                    return "";
                if(Coefficient == 1)
                {
                    if (Degree == 0)
                        return "1";
                    if (Degree == 1)
                        return "x";
                }
                if(Coefficient == -1)
                {
                    if (Degree == 0)
                        return "-1";
                    if (Degree == 1)
                        return "-x";
                }
            }

            return "";
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
