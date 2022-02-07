using System;

namespace task_7
{
    class Program
    {
        static void Main(string[] args)
        {            
            var firstMatrix = new Matrix(3, 3, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            var secondMatrix = new Matrix(3, 3, 9, 8, 7, 6, 5, 4, 3, 2, 1);
            Console.WriteLine("Addition: \n" + (firstMatrix + secondMatrix));
            Console.WriteLine("Subtraction: \n" + (firstMatrix - secondMatrix));
            Console.WriteLine("Multiplication: \n" + (firstMatrix * secondMatrix));
            Console.WriteLine("Multiplication for number: \n" + (firstMatrix * 2));
        }
    }
}
