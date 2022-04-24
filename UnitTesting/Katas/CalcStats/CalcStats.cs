using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
    public class CalcStats
    {
        public static int MINIMUM_VALUE_INDEX = 0;
        public static int MAXIMUM_VALUE_INDEX = 1;
        public static int NUMBER_OF_ELEMENTS_INDEX = 2;
        public static int AVAREGAE_VALUE_OF_ELEMENTS_INDEX = 3;
        
        public static double[] CalculateStatistics(int[] arr)
        {
            double[] statistics = new double[4];

            statistics[MINIMUM_VALUE_INDEX] = arr.Min();
            statistics[MAXIMUM_VALUE_INDEX] = arr.Max();
            statistics[NUMBER_OF_ELEMENTS_INDEX] = arr.Length;
            statistics[AVAREGAE_VALUE_OF_ELEMENTS_INDEX] = arr.Average();

            return statistics;
        }
    }
}
