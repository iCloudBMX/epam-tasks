using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace Katas.Tests
{
    public class CalcStatsTests
    {
        private int MINIMUM_VALUE_INDEX = 0;
        private int MAXIMUM_VALUE_INDEX = 1;
        private int NUMBER_OF_ELEMENTS_INDEX = 2;
        private int AVAREGAE_VALUE_OF_ELEMENTS_INDEX = 3;

        [Fact]
        public void ShouldCalculateStatistics()
        {
            // Arrange            
            var inputNumbers =
                new int[] { 6, 9, 15, -2, 92, 11 };
            
            int expectedMinValue = -2;
            int expectedMaxValue = 92;
            double expectedAverageValue = 18.166666;
            int expectedNumberOfElements = 6;

            // Act
            var actualResults =
                CalcStats.CalculateStatistics(inputNumbers);

            // Assert
            Assert.Equal(expectedMinValue,
                actualResults[MINIMUM_VALUE_INDEX]);
            
            Assert.Equal(expectedMaxValue,
                actualResults[MAXIMUM_VALUE_INDEX]);
            
            Assert.Equal(expectedNumberOfElements,
                actualResults[NUMBER_OF_ELEMENTS_INDEX]);

            Assert.Equal(expectedAverageValue,
                actualResults[AVAREGAE_VALUE_OF_ELEMENTS_INDEX]);
        }
    }
}
