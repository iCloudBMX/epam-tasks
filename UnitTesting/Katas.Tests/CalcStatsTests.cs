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
        [Fact]
        public void ShouldCalculateStatistics()
        {
            // Arrange            
            var inputNumbers =
                new int[] { 6, 9, 15, -2, 92, 11 };
            
            int expectedMinValue = -2;
            int expectedMaxValue = 92;
            double expectedAverageValue = 21.833333333333332;
            int expectedNumberOfElements = 6;

            // Act
            var actualResults =
                CalcStats.CalculateStatistics(inputNumbers);

            // Assert
            Assert.Equal(expectedMinValue,
                actualResults[CalcStats.MINIMUM_VALUE_INDEX]);
            
            Assert.Equal(expectedMaxValue,
                actualResults[CalcStats.MAXIMUM_VALUE_INDEX]);
            
            Assert.Equal(expectedNumberOfElements,
                actualResults[CalcStats.NUMBER_OF_ELEMENTS_INDEX]);

            Assert.Equal(expectedAverageValue,
                actualResults[CalcStats.AVAREGAE_VALUE_OF_ELEMENTS_INDEX]);
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionOnCalculateStatisticsWhenArrayIsNull() =>
            Assert.Throws<ArgumentNullException>(() => 
                CalcStats.CalculateStatistics(null));
    }
}
