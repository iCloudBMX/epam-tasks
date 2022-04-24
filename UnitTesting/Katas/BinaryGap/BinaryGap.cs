using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    public class BinaryGap
    {
        public static int FindMaxBinaryGap(int number)
        {
            int currentLength = 0, maxLength = 0;

            while(number > 0)
            {
                if (number % 2 == 1)
                {
                    maxLength = Math.Max(maxLength, currentLength);
                    currentLength = 0;
                }
                else
                    currentLength++;

                number /= 2;
            }

            return maxLength;
        }
    }
}
