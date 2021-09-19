using System;
using System.Diagnostics;
using task_3;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var alg = new EuclideanAlgorithm();

            long time;

            long startTime = DateTime.Now.Ticks;
            Console.WriteLine(alg.FindGreatestCommonDivisorBinaryAlgorithm(24, 28, out time));
            Console.WriteLine("Time: " + (startTime - time));

            Console.WriteLine(alg.FindGreatestCommonDivisor(24, 28, out time));
            Console.WriteLine("Time: " + time);

            Console.ReadLine();
        }
    }
}
