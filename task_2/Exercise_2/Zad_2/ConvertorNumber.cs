using System;

namespace Zad_2
{
    class ConvertorNumber
    {
        public string Convert(int number)
        {
            string str = "";

            while (number > 1)
            {
                int remainder = number % 2;
                number /= 2;
                str += remainder;
            }

            str += number;
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
