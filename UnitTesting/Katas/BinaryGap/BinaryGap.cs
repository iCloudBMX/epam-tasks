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
            if (number < 1)
                throw new ArgumentOutOfRangeException();

            int currentLength = 0, maxLength = 0;
            bool isOne = false;
            
            while(number > 0)
            {
                if (number % 2 == 1)
                {
                    if(isOne)
                    {
                        maxLength = Math.Max(maxLength, currentLength);
                        currentLength = 0;
                    }
                    isOne = true;
                }
                else
                {
                    if(isOne)
                        currentLength++;
                }                    

                number /= 2;
            }

            return maxLength;
        }
    }
}
