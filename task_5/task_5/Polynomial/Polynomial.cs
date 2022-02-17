using System;
using System.Collections.Generic;

namespace Polynomial
{
    public class Polynomial
    {
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
            CheckPolynomial(coefficients);
            _monomials = new List<Monomial>((Monomial[])coefficients.Clone());
        }

        public Polynomial(string value)
        {
            CheckPolynomial(value);

            _monomials = new List<Monomial>();
            string[] summands = value.Split('+');
            double coefficient;
            int monomialDegree;
            foreach (var summand in summands)
            {
                string[] multipliers = summand.Split('*');
                coefficient = multipliers.Length == 1 ? 1 : double.Parse(multipliers[0]);
                string[] degree = multipliers.Length == 1 ? multipliers[0].Split('^') : multipliers[1].Split('^');
                monomialDegree = degree.Length == 1 ? 1 : int.Parse(degree[1]);

                _monomials.Add(new Monomial(monomialDegree, coefficient));
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

        private static Polynomial CalculatePolynomial(Polynomial leftPolynimial, Polynomial rightPolynimial, Func<Monomial, Monomial, Monomial> calculate, Action<List<Monomial>, Monomial> addMonomial = null)
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
                        newCoefficients.Remove(leftMonomial);
                        newCoefficients.Add(calculate(leftMonomial, rightMonomial));
                        isFind = true;
                    }
                }

                if (!isFind)
                    addMonomial(newCoefficients, rightMonomial);
            }

            return new Polynomial(newCoefficients.ToArray());
        }

        public void CheckPolynomial(object polynomial)
        {
            if (polynomial == null)
                throw new ArgumentNullException("Polynomial cannot be null.");

            if ((polynomial is string stringMonomial) && stringMonomial.Length == 0)
                throw new ArgumentException("Polynomial cannot be empty.");

            if ((polynomial is Monomial[] arrayMonomial) && arrayMonomial.Length == 0)
                throw new ArgumentException("Polynomial cannot be empty.");
        }

        public static Polynomial operator +(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            return CalculatePolynomial(
                leftPolynimial, 
                rightPolynimial, 
                (leftMonomial, rightMonomial) => leftMonomial + rightMonomial, 
                (coefficients, monomial) => coefficients.Add(monomial));
        }

        public static Polynomial operator -(Polynomial leftPolynimial, Polynomial rightPolynimial)
        {
            return CalculatePolynomial(
                leftPolynimial, 
                rightPolynimial, 
                (leftMonomial, rightMonomial) => leftMonomial - rightMonomial, 
                (coefficients, monomial) => coefficients.Add(new Monomial(monomial.Degree, -monomial.Coefficient))
                );
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
            string text = "";

            for (int i = _monomials.Count - 1; i >= 0; i--)
            {
                text += _monomials[i].ToString();
            }

            return text == "" ? "0" : text;
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
