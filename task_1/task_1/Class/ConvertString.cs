using System;
using System.Globalization;

namespace task_1
{
    static class StringConverter
    {
        public static double GetNumericValueDouble(string str)
        {
            double number;
            if (!Double.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-us"), out number))
                throw new ArgumentException("Invalid data " + str);

            return number;
        }

        public static int GetNumericValueInt(string str)
        {
            int number;
            if (!Int32.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-us"), out number))
                throw new ArgumentException("Invalid data " + str);

            return number;
        }
    }
}
