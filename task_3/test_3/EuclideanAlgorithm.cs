using System;
using System.Collections.Generic;
using System.Text;

namespace task_3
{
    public struct EuclideanAlgorithm
    {
        public int FindGreatestCommonDivisorBinaryAlgorithm(int firstNumber, int secondNumber, out long time)
        {
            if ((firstNumber == 0) || (secondNumber == 0) || (firstNumber == secondNumber))
            {
                time = DateTime.Now.Ticks;
                return Math.Max(firstNumber, secondNumber);
            }

            if ((firstNumber % 2 == 0) && (secondNumber % 2 == 0))
                return 2 * FindGreatestCommonDivisorBinaryAlgorithm(firstNumber / 2, secondNumber / 2, out time);

            if ((firstNumber % 2 == 0) && (secondNumber % 2 == 1))
                return FindGreatestCommonDivisorBinaryAlgorithm(firstNumber / 2, secondNumber, out time);

            if ((firstNumber % 2 == 1) && (secondNumber % 2 == 0))
                return FindGreatestCommonDivisorBinaryAlgorithm(firstNumber, secondNumber / 2, out time);

            if ((firstNumber % 2 == 1) && (secondNumber % 2 == 1) && secondNumber > firstNumber)
                return FindGreatestCommonDivisorBinaryAlgorithm((secondNumber - firstNumber) / 2, firstNumber, out time);

            if ((firstNumber % 2 == 1) && (secondNumber % 2 == 1) && secondNumber < firstNumber)
                return FindGreatestCommonDivisorBinaryAlgorithm((firstNumber - secondNumber) / 2, secondNumber, out time);

            time = DateTime.Now.Ticks;
            return 0;
        }
        public int FindGreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            if ((firstNumber <= 0) || (secondNumber <= 0))
                return 0;

            int max = Math.Max(firstNumber, secondNumber);
            int min = Math.Min(firstNumber, secondNumber);
            int remains;

            while (max % min != 0)
            {
                remains = max % min;
                max = min;
                min = remains;
            }

            return min;
        }

        public int FindGreatestCommonDivisor(int firstNumber, int secondNumber, out long time)
        {
            long startTime = DateTime.Now.Ticks;
            int greatestCommonDivisor = FindGreatestCommonDivisor(firstNumber, secondNumber);
            time = DateTime.Now.Ticks - startTime;
            return greatestCommonDivisor;
        }
        public int FindGreatestCommonDivisor(int firstNumber, int secondNumber, int thridNumber)
        {
            int greatestCommonDivisor = FindGreatestCommonDivisor(firstNumber, secondNumber);
            return FindGreatestCommonDivisor(greatestCommonDivisor, thridNumber);
        }

        public int FindGreatestCommonDivisor(int firstNumber, int secondNumber, int thridNumber, int fourthNumber)
        {
            int greatestCommonDivisor = FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber);
            return FindGreatestCommonDivisor(greatestCommonDivisor, fourthNumber);
        }

        public int FindGreatestCommonDivisor(int firstNumber, int secondNumber, int thridNumber, int fourthNumber, int fifthNumber)
        {
            int greatestCommonDivisor = FindGreatestCommonDivisor(firstNumber, secondNumber, thridNumber, fourthNumber);
            return FindGreatestCommonDivisor(greatestCommonDivisor, fifthNumber);
        }
    }
}
