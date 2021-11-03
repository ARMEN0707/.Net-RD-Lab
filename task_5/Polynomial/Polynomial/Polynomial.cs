using System;
using System.Collections.Generic;

namespace Polynomial
{
    public class Polynomial
    {
        public static double s_Epsilon = 0.00001;
        private readonly List<Monomial> _monomials;

        public int Degree
        {
            get 
            {
                int max = _monomials[0].Degree;
                foreach(Monomial monomial in _monomials)
                {
                    if (monomial.Degree > max)
                        max = monomial.Degree;
                }
                return max;
            }
        }

        public Polynomial(params Monomial[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("coefficients cannot be null.");

            if (coefficients.Length == 0)
                throw new ArgumentException("coefficients cannot be empty.");

            _monomials = new List<Monomial>((Monomial[])coefficients.Clone());
        }

        public Polynomial(string value)
        {
            if (value == null)
                throw new ArgumentNullException("String cannot be null.");

            if (value.Length == 0)
                throw new ArgumentException("String cannot be empty.");

            _monomials = new List<Monomial>();
            string[] summands = value.Split('+');
            foreach (var summand in summands)
            {
                string[] multipliers = summand.Split('*');
                if (multipliers.Length == 1)
                {
                    _monomials.Add(new Monomial(0, double.Parse(multipliers[0])));
                    continue;
                }
                string[] degree = multipliers[1].Split('^');
                if (degree.Length == 1)
                {
                    _monomials.Add(new Monomial(1, double.Parse(multipliers[0])));
                    continue;
                }

                _monomials.Add(new Monomial(int.Parse(degree[1]), double.Parse(multipliers[0])));
            }
        }

        public Monomial this[int index]
        {
            get
            {
                if (index >= 0 && index < _monomials.Count)
                    return _monomials[index];
                else
                    throw new ArgumentOutOfRangeException("index is not a valid");
            }

            private set
            {
                if (index >= 0 && index < _monomials.Count)
                    _monomials[index] = value;
                else
                    throw new ArgumentOutOfRangeException("index is not a valid");
            }
        }
        //5*x^2+6*x^4
        //4+5*x+3*x^2

        public static Polynomial operator +(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if (leftPolynimial == null || rightPolynimial == null)
                throw new ArgumentNullException("Polynomial cannot be null");

            var newCoefficients = new List<Monomial>(rightPolynimial._monomials);

            foreach(var leftMonomial in leftPolynimial._monomials)
            {
                bool isFind = false;
                foreach (var rightMonomial in rightPolynimial._monomials)
                {
                    if(leftMonomial.Degree == rightMonomial.Degree)
                    {
                        newCoefficients.Remove(rightMonomial);
                        newCoefficients.Add(leftMonomial + rightMonomial);
                        isFind = true;
                    }
                }

                if(!isFind)
                    newCoefficients.Add(leftMonomial);
            }

            return new Polynomial(newCoefficients.ToArray());
        }

        public static Polynomial operator -(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if (leftPolynimial == null || rightPolynimial == null)
                throw new ArgumentNullException("Polynomial cannot be null");

            var newCoefficients = new List<Monomial>(leftPolynimial._monomials);

            foreach (var rightMonomial in rightPolynimial._monomials)
            {
                bool isFind = false;
                foreach (var leftMonomial in leftPolynimial._monomials)
                {
                    if (leftMonomial.Degree == rightMonomial.Degree)
                    {
                        newCoefficients.Add(leftMonomial - rightMonomial);
                        newCoefficients.Remove(leftMonomial);
                        isFind = true;
                    }
                }

                if (!isFind)
                    newCoefficients.Add(new Monomial(rightMonomial.Degree, -rightMonomial.Coefficient));
            }

            return new Polynomial(newCoefficients.ToArray());
        }

        public static Polynomial operator *(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if (leftPolynimial == null || rightPolynimial == null)
                throw new ArgumentNullException("Polynomial cannot be null");

            var newCoefficients = new List<Monomial>();

            foreach (var leftMonomial in leftPolynimial._monomials)
            {
                foreach (var rightMonomial in rightPolynimial._monomials)
                {               
                    if(leftMonomial.Coefficient != 0 && rightMonomial.Coefficient != 0)
                    {
                        Monomial newMonomial = leftMonomial * rightMonomial;
                        int index = newCoefficients.FindIndex(monomial => monomial.Degree == newMonomial.Degree);
                        if (index != -1)
                            newCoefficients[index].Coefficient += newMonomial.Coefficient;
                        else
                            newCoefficients.Add(newMonomial);
                    }

                }
            }

            return new Polynomial(newCoefficients.ToArray());
        }

        public static bool operator ==(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            if ((object)rightPolynimial == null)
                return (object)leftPolynimial == null;

            if ((object)leftPolynimial == null)
                return (object)rightPolynimial == null;


            if (leftPolynimial._monomials.Count == rightPolynimial._monomials.Count)
            {
                foreach (var leftMonomial in leftPolynimial._monomials)
                {
                    bool isFind = false;
                    foreach (var rightMonomial in rightPolynimial._monomials)
                    {
                        if (leftMonomial == rightMonomial)
                        {
                            isFind = true;
                            break;
                        }
                    }
                    if (!isFind)
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
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string text = null;

            for (int i = _monomials.Count - 1; i > 0; i--)
            {
                text += _monomials[i].ToString();

                if (_monomials[i - 1].Coefficient > 0 && _monomials[i].ToString().Length != 0)
                {
                    text += "+";
                }
            }

            text += _monomials[0];

            return text;
        }

        public double CalculateValue(double x)
        {
            double number = 0;
            foreach(var monomial in _monomials)
            {
                number += monomial.CalculateValue(x);
            }

            return number;
        }

        public object Clone()
        {
            Monomial[] cloneMonomials = new Monomial[_monomials.Count];
            _monomials.CopyTo(cloneMonomials);
            return new Polynomial(cloneMonomials);
        }
    }
}
