using System;
using System.Diagnostics;

namespace task_3
{
    public struct EuclideanAlgorithm
    {
        public int FindNodBinaryAlgorithm(int a, int b, out long time)
        {
            if ((a == 0) || (b == 0) || (a == b))
            {
                time = DateTime.Now.Ticks;
                return Math.Max(a, b);
            }    

            if((a % 2 == 0) && (b % 2 == 0))
                return 2 * FindNodBinaryAlgorithm(a / 2, b / 2, out time);

            if((a % 2 == 0) && (b % 2 == 1))
                return FindNodBinaryAlgorithm(a / 2, b, out time);

            if ((a % 2 == 1) && (b % 2 == 0))
                return FindNodBinaryAlgorithm(a, b / 2, out time);

            if ((a % 2 == 1) && (b % 2 == 1) && b > a)
                return FindNodBinaryAlgorithm((b - a) / 2, a, out time);

            if ((a % 2 == 1) && (b % 2 == 1) && b < a)
                return FindNodBinaryAlgorithm((a - b) / 2, b, out time);

            time = DateTime.Now.Ticks;
            return 0;
        }
        public int FindNod(int a, int b)
        {
            if ((a <= 0) || (b <= 0))
                return 0;

            int x = Math.Max(a, b);
            int y = Math.Min(a, b);
            int temp;

            while (x % y != 0)
            {
                temp = x % y;
                x = y;
                y = temp;
            }

            return y;
        }

        public int FindNod(int a, int b, out long time)
        {
            long tempTime = DateTime.Now.Ticks;
            int nod = FindNod(a, b);
            time = DateTime.Now.Ticks - tempTime;
            return nod;
        }
        public int FindNod(int a, int b, int c)
        {
            int d = FindNod(a, b);
            return FindNod(d, c);
        }

        public int FindNod(int a, int b, int c, int d)
        {
            int nod = FindNod(a, b, c);
            return FindNod(nod, d);
        }

        public int FindNod(int a, int b, int c, int d, int e)
        {
            int nod = FindNod(a, b, c, d);
            return FindNod(nod, e);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EuclideanAlgorithm alg = new EuclideanAlgorithm();

            long tempTime;

            long time = DateTime.Now.Ticks;
            Console.WriteLine(alg.FindNodBinaryAlgorithm(24, 28, out tempTime));
            Console.WriteLine("Time: " + (tempTime - time));

            Console.WriteLine(alg.FindNod(24, 28, out tempTime));
            Console.WriteLine("Time: " + tempTime);

            Console.ReadLine();
        }
    }
}
