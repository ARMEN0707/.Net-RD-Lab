using System;

namespace Exercise_2
{
    class NumberConvertor
    {
        public string Convert(int number)
        {
            string binaryCode = "";

            if(number < 0)
            {
                return System.Convert.ToString(number, 2);
            }

            while (number > 1)
            {
                int remainder = number % 2;
                number /= 2;
                binaryCode += remainder;
            }

            binaryCode += number;
            char[] arr = binaryCode.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
