using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            long result = 0;

            if (stringValue == null)
                throw new ArgumentNullException();

            if (string.IsNullOrWhiteSpace(stringValue))
                throw new FormatException();

            stringValue = stringValue.Trim();

            bool isPositive = stringValue[0] == '+' || char.IsDigit(stringValue[0]); 

            for(int index = 0; index < stringValue.Length; index++)
            {
                if (index == 0 && (stringValue[index] == '-' || stringValue[index] == '+'))
                    continue;

                if (!char.IsDigit(stringValue[index]))
                    throw new FormatException();

                result = result * 10 + (stringValue[index] - '0');
            }

            if (!isPositive)
                result *= -1;

            if (result > int.MaxValue || result < int.MinValue)
                throw new OverflowException();

            return (int)result;
        }
    }
}