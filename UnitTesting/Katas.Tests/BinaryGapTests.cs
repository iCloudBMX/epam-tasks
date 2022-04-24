﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Katas.Tests
{
    public class BinaryGapTests
    {
        [Theory]
        [InlineData(9, 2)]
        [InlineData(529, 4)]
        [InlineData(1041, 5)]
        public void ShouldFindMaxBinaryGap(int number, int expectedResult)
        {
            // Act
            int actualResult =
                BinaryGap.FindMaxBinaryGap(number);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(20, 1)]
        [InlineData(16, 0)]
        public void ShouldFindMaxBinaryGapWhenThereIsNoOneAtTheEnd(int number, int expedtedResult)
        {
            // Act
            int actualResult =
                BinaryGap.FindMaxBinaryGap(number);

            // Assert
            Assert.Equal(expedtedResult, actualResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ShouldThrowArgumentOutOfRangeExceptionOnFindMaxBinaryGapWhenInputNumberIsNegativeOrZero(int number) =>
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                BinaryGap.FindMaxBinaryGap(number));
    }
}
