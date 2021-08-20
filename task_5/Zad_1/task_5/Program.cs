using System;

namespace task_5
{
    public class Vector
    {
        public float X;
        public float Y;
        public float Z;

        public static Vector UnitX
        {
            get { return new Vector(1, 0, 0); }
        }

        public static Vector UnitY
        {
            get { return new Vector(0, 1, 0); }
        }

        public static Vector UnitZ
        {
            get { return new Vector(0, 0, 1); }
        }

        public static Vector Zero
        {
            get { return new Vector(0, 0, 0); }
        }

        public float Length
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static bool operator == (Vector lVector, Vector rVector)
        {
            float epsilon = 0.000001f;
            if ((object)rVector == null)
                return (object)lVector == null;

            if(Math.Abs(lVector.X - rVector.X) <= epsilon)
                if(Math.Abs(lVector.Y - rVector.Y) <= epsilon)
                    if (Math.Abs(lVector.Z - rVector.Z) <= epsilon)
                        return true;  
                        

            return false;
        }

        public static bool operator != (Vector lVector, Vector rVector)
        {
            return !(lVector == rVector);
        }

        public static Vector operator + (Vector lVector, Vector rVector)
        {
            if (lVector == null || rVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                lVector.X + rVector.X,
                lVector.Y + rVector.Y,
                lVector.Z + rVector.Z
                );
        }

        public static Vector operator - (Vector lVector, Vector rVector)
        {
            if (lVector == null || rVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                lVector.X - rVector.X,
                lVector.Y - rVector.Y,
                lVector.Z - rVector.Z
                );
        }

        public static Vector operator * (Vector lVector, Vector rVector)
        {
            if (lVector == null || rVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                lVector.Y * rVector.Z - lVector.Z * rVector.Y,
                lVector.Z * rVector.X - lVector.X * rVector.Z,
                lVector.X * rVector.Y - lVector.Y * rVector.X
                );
        }

        public static Vector operator * (Vector lVector, float number)
        {
            if (lVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                lVector.X * number,
                lVector.Y * number,
                lVector.Z * number
                );
        }

        public static Vector operator / (Vector lVector, float number)
        {
            if (lVector == null)
                throw new ArgumentNullException("Vector cannot be null");
            if (number == 0)
                throw new ArgumentException("Division by zero.");

            return new Vector(
                lVector.X / number,
                lVector.Y / number,
                lVector.Z / number
                );
        }

        public static Vector Add(Vector lVector, Vector rVector)
        {
            return lVector + rVector;
        }

        public static Vector Subtract(Vector lVector, Vector rVector)
        {
            return lVector - rVector;
        }

        public static Vector Multiply(Vector lVector, Vector rVector)
        {
            return lVector * rVector;
        }
        
        public static Vector Multiply(Vector lVector, float number)
        {
            return lVector * number;
        }

        public static Vector Division(Vector lVector, float number)
        {
            return lVector / number;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                return this == obj as Vector;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
