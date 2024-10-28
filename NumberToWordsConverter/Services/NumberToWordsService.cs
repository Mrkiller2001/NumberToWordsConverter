// Services/NumberToWordsService.cs
using System;
using System.Numerics;

namespace NumberToWordsConverter.Services
{
    public class NumberToWordsService
    {
        public string ConvertNumberToWords(decimal number)
            {
                if (number < 0)
                    throw new ArgumentOutOfRangeException("Negative numbers are not supported.");

                // Check if the number has more than two decimal places
                if (Decimal.Round(number, 2) != number)
                    throw new ArgumentException("Only up to two decimal places are supported.");

                // Separate the dollar and cent parts
                BigInteger dollars = (BigInteger)Math.Floor(number);
                int cents = (int)((number - Math.Floor(number)) * 100);

                // Determine the correct singular or plural form for dollars
                string dollarWord = dollars == 1 ? "DOLLAR" : "DOLLARS";
                string dollarWords = ConvertToWords(dollars).ToUpper();

                // If there are no cents, return only the dollar amount in words
                if (cents == 0)
                    return $"{dollarWords} {dollarWord}";

                // Determine the correct singular or plural form for cents
                string centWord = cents == 1 ? "CENT" : "CENTS";
                string centWords = ConvertToWords(cents).ToUpper();

                return $"{dollarWords} {dollarWord} AND {centWords} {centWord}";
            }


        private string ConvertToWords(BigInteger number)
        {
            if (number == 0)
                return "zero";

            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] thousandsGroups = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };

            if (number < 20)
                return units[(int)number];
            if (number < 100)
                return tens[(int)(number / 10)] + (number % 10 > 0 ? "-" + units[(int)(number % 10)] : "");

            if (number < 1000)
                return units[(int)(number / 100)] + " hundred" + (number % 100 > 0 ? " and " + ConvertToWords(number % 100) : "");

            return ConvertLargeNumberToWords(number, thousandsGroups);
        }

        private string ConvertLargeNumberToWords(BigInteger number, string[] thousandsGroups)
        {
            string words = string.Empty;
            int group = 0;

            while (number > 0)
            {
                BigInteger currentGroupValue = number % 1000;
                if (currentGroupValue != 0)
                {
                    string groupWords = ConvertToWords(currentGroupValue) + " " + thousandsGroups[group];
                    words = groupWords.Trim() + (string.IsNullOrEmpty(words) ? "" : " " + words);
                }

                number /= 1000;
                group++;
            }

            return words.Trim();
        }
    }
}
