using System;

namespace task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstVector = new Vector(1, 2, 3);
            var secondVector = new Vector(4, 5, 6);

            Console.WriteLine("Addition: " + (firstVector + secondVector));
            Console.WriteLine("Subtraction: " + (firstVector - secondVector));
            Console.WriteLine("Multiplication: " + (firstVector * secondVector));
            Console.WriteLine("Multiplication by number: " + (firstVector * 2));
            Console.WriteLine("Division by number: " + (secondVector / 2));
            Console.WriteLine("Length: " + firstVector.Length);

        }
    }
}
