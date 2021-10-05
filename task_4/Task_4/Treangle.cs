using System;

namespace Task_4
{
    public class Treangle
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get { return _sideA; }
            set { _sideA = CheckSide(value); }
        }
        public double SideB
        {
            get { return _sideB; }
            set { _sideB = CheckSide(value); }
        }
        public double SideC
        {
            get { return _sideC; }
            set { _sideC = CheckSide(value); }

        }

        public Treangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            if (!CheckTriangle())
            {
                throw new ArgumentException("Triangle cannot exist");
            }
        }

        public bool CheckTriangle()
        {
            if (_sideA == 0 || _sideB == 0 || _sideC == 0)
                return false;

            if (_sideA + _sideB <= _sideC)
                return false;
            if (_sideB + _sideC <= _sideA)
                return false;
            if (_sideC + _sideA <= _sideB)
                return false;

            return true;
        }

        public double CheckSide(double value)
        {
            if (value <= 0)
                throw new ArgumentException("A value less than zero is used, but the argument cannot be less than zero.");

            return value;
        }

        public double GetPerimeter() => _sideA + _sideB + _sideC;

        public double GetSquare()
        {
            double halfPerimetr = GetPerimeter() / 2.0f;
            double square = halfPerimetr * (halfPerimetr - _sideA) * (halfPerimetr - _sideB) * (halfPerimetr - _sideC);
            return Math.Sqrt(square);
        }
    }
}
