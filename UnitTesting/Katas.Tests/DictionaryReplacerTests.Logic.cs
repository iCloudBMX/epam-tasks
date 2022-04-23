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
    }
}
