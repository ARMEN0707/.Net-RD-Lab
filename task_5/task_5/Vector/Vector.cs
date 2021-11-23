using System;
using System.Collections.Generic;
using System.Text;

namespace task_5
{
    public class Vector
    {
        public double AxisX;
        public double AxisY;
        public double AxisZ;

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

        public double Length
        {
            get { return (double)Math.Sqrt(AxisX * AxisX + AxisY * AxisY + AxisZ * AxisZ); }
        }

        public Vector(double axisX, double axisY, double axisZ)
        {
            AxisX = axisX;
            AxisY = axisY;
            AxisZ = axisZ;
        }

        public static bool operator ==(Vector leftVector, Vector rightVector)
        {
            double epsilon = 0.000001f;
            if ((object)rightVector == null)
                return (object)leftVector == null;

            if ((object)leftVector == null)
                return (object)rightVector == null;

            if (Math.Abs(leftVector.AxisX - rightVector.AxisX) <= epsilon)
                if (Math.Abs(leftVector.AxisY - rightVector.AxisY) <= epsilon)
                    if (Math.Abs(leftVector.AxisZ - rightVector.AxisZ) <= epsilon)
                        return true;


            return false;
        }

        public static bool operator !=(Vector leftVector, Vector rightVector)
        {
            return !(leftVector == rightVector);
        }

        public static Vector operator +(Vector leftVector, Vector rightVector)
        {
            if (leftVector == null || rightVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                leftVector.AxisX + rightVector.AxisX,
                leftVector.AxisY + rightVector.AxisY,
                leftVector.AxisZ + rightVector.AxisZ
                );
        }

        public static Vector operator -(Vector leftVector, Vector rightVector)
        {
            if (leftVector == null || rightVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                leftVector.AxisX - rightVector.AxisX,
                leftVector.AxisY - rightVector.AxisY,
                leftVector.AxisZ - rightVector.AxisZ
                );
        }

        public static Vector operator *(Vector leftVector, Vector rightVector)
        {
            if (leftVector == null || rightVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                leftVector.AxisY * rightVector.AxisZ - leftVector.AxisZ * rightVector.AxisY,
                leftVector.AxisZ * rightVector.AxisX - leftVector.AxisX * rightVector.AxisZ,
                leftVector.AxisX * rightVector.AxisY - leftVector.AxisY * rightVector.AxisX
                );
        }

        public static Vector operator *(Vector leftVector, double number)
        {
            if (leftVector == null)
                throw new ArgumentNullException("Vector cannot be null");

            return new Vector(
                leftVector.AxisX * number,
                leftVector.AxisY * number,
                leftVector.AxisZ * number
                );
        }

        public static Vector operator /(Vector leftVector, double number)
        {
            if (leftVector == null)
                throw new ArgumentNullException("Vector cannot be null");
            if (number == 0)
                throw new ArgumentException("Division by zero.");

            return new Vector(
                leftVector.AxisX / number,
                leftVector.AxisY / number,
                leftVector.AxisZ / number
                );
        }

        public static Vector Add(Vector leftVector, Vector rightVector)
        {
            return leftVector + rightVector;
        }

        public static Vector Subtract(Vector leftVector, Vector rightVector)
        {
            return leftVector - rightVector;
        }

        public static Vector Multiply(Vector leftVector, Vector rightVector)
        {
            return leftVector * rightVector;
        }

        public static Vector Multiply(Vector leftVector, double number)
        {
            return leftVector * number;
        }

        public static Vector Division(Vector leftVector, double number)
        {
            return leftVector / number;
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

        public override string ToString()
        {
            return $"X:{AxisX} Y:{AxisY} Z:{AxisZ}";
        }
    }
}
