using System.Collections.Generic;
using Xunit;

namespace Katas.Tests
{
    public partial class DictionaryReplacerTests
    {
        [Fact]
        public void ShouldReplaceSuffixWithKeys()
        {
            // Arrange
            string inputString = "$temp$";
            var inputDictionary = new Dictionary<string, string>
            {
                { "temp", "temporary" }
            };

            string expectedResult = "temporary";

            // Act
            var actualResult =
                DictionaryReplacer.ReplaceSuffixWithKeys(
                    inputString: inputString,
                    dictionary: inputDictionary);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldReplaceSuffixWithKeys_WithMultipleSuffixes()
        {
            // Arrange
            string inputString = "$temp$ here comes the name $name$";
            var inputDictionary = new Dictionary<string, string>
            {
                { "temp", "temporary" },
                { "name", "John Doe" }
            };

            string expectedResult = "temporary here comes the name John Doe";

            // Act
            var actualResult =
                DictionaryReplacer.ReplaceSuffixWithKeys(
                    inputString: inputString,
                    dictionary: inputDictionary);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
