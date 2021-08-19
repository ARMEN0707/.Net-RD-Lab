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

        public Treangle(double a, double b, double c)
        {
            _sideA = a;
            _sideB = b;
            _sideC = c;
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
                return 0;

            return value;
        }

        public double Perimeter() => _sideA + _sideB + _sideC;

        public double Square()
        {
            double halfPerimetr = Perimeter() / 2.0f;
            double rez = halfPerimetr * (halfPerimetr - _sideA) * (halfPerimetr - _sideB) * (halfPerimetr - _sideC);
            return Math.Sqrt(rez);
        }

        class Program
        {
            static void Main()
            {

            }
        }

    }
}
