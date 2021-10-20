using System;

namespace Task_4
{
    public class Triangle
    {
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;

        public double FirstSide
        {
            get { return _firstSide; }
            set { _firstSide = CheckSide(value); }
        }
        public double SecondSide
        {
            get { return _secondSide; }
            set { _secondSide = CheckSide(value); }
        }
        public double ThirdSide
        {
            get { return _thirdSide; }
            set { _thirdSide = CheckSide(value); }

        }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            if (!CheckTriangle())
            {
                throw new ArgumentException("Triangle cannot exist");
            }
        }

        public bool CheckTriangle()
        {
            if (_firstSide == 0 || _secondSide == 0 || _thirdSide == 0)
                return false;

            if (_firstSide + _secondSide <= _thirdSide)
                return false;
            if (_secondSide + _thirdSide <= _firstSide)
                return false;
            if (_thirdSide + _firstSide <= _secondSide)
                return false;

            return true;
        }

        public double CheckSide(double value)
        {
            if (value <= 0)
                throw new ArgumentException("A value less than zero is used, but the argument cannot be less than zero.");

            return value;
        }

        public double GetPerimeter() => _firstSide + _secondSide + _thirdSide;

        public double GetSquare()
        {
            double halfPerimetr = GetPerimeter() / 2.0f;
            double square = halfPerimetr * (halfPerimetr - _firstSide) * (halfPerimetr - _secondSide) * (halfPerimetr - _thirdSide);
            return Math.Sqrt(square);
        }
    }
}
