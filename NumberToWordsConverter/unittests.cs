using Xunit;
using NumberToWordsConverter.Services;
using System;

namespace NumberToWordsConverter.Tests
{
    public class NumberToWordsServiceTests
    {
        private readonly NumberToWordsService _service;

        public NumberToWordsServiceTests()
        {
            _service = new NumberToWordsService();
        }

        [Fact]
        public void ConvertNumberToWords_WholeNumberWithoutCents_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 250;
            string expected = "TWO HUNDRED AND FIFTY DOLLARS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_SingleDigit_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 7;
            string expected = "SEVEN DOLLARS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_TensPlaceOnly_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 40;
            string expected = "FORTY DOLLARS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_ExactWholeHundred_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 500;
            string expected = "FIVE HUNDRED DOLLARS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_ExactThousand_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 1000;
            string expected = "ONE THOUSAND DOLLARS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_SmallAmountWithCents_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 1.25M;
            string expected = "ONE DOLLAR AND TWENTY-FIVE CENTS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_VeryLargeNumber_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 9876543210M;
            string expected = "NINE BILLION EIGHT HUNDRED AND SEVENTY-SIX MILLION FIVE HUNDRED AND FORTY-THREE THOUSAND TWO HUNDRED AND TEN DOLLARS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_OneCent_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 0.01M;
            string expected = "ZERO DOLLARS AND ONE CENT";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_MaxTwoDecimalPlaces_ReturnsCorrectWords()
        {
            // Arrange
            decimal input = 123456789.99M;
            string expected = "ONE HUNDRED AND TWENTY-THREE MILLION FOUR HUNDRED AND FIFTY-SIX THOUSAND SEVEN HUNDRED AND EIGHTY-NINE DOLLARS AND NINETY-NINE CENTS";

            // Act
            var result = _service.ConvertNumberToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ConvertNumberToWords_MoreThanTwoDecimalPlaces_ThrowsArgumentException()
        {
            // Arrange
            decimal input = 123.456M;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.ConvertNumberToWords(input));
        }

        [Fact]
        public void ConvertNumberToWords_NegativeInput_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            decimal input = -100M;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.ConvertNumberToWords(input));
        }
    }
}
