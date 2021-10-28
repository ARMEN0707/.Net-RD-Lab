using System;
using System.Diagnostics;
using task_3;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();

            long time;

            Console.WriteLine(euclideanAlgorithm.FindGreatestCommonDivisorBinaryAlgorithm(24, 28, out time));
            Console.WriteLine("Time Euclidean algorithm: " + time);

            Console.WriteLine(euclideanAlgorithm.FindGreatestCommonDivisor(24, 28, out time));
            Console.WriteLine("Time binary Euclidean algorithm: " + time);

            Console.ReadLine();
        }
    }
}
