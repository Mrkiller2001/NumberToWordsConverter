// Services/NumberToWordsService.cs
using System;
using System.Numerics;

namespace NumberToWordsConverter.Services
{
    public class NumberToWordsService
    {
        public string ConvertNumberToWords(decimal number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException("Negative numbers are not supported.");

            var dollars = BigInteger.Parse(((long)number).ToString()); // Parse the whole number part as BigInteger
            var cents = (int)((number - Math.Floor(number)) * 100);

            Console.WriteLine($"{dollars} {cents}");

            // If there are no cents, return only the dollar amount in words
            if (cents == 0)
            {
                return $"{ConvertToWords(dollars).ToUpper()} DOLLARS";
            }

            return $"{ConvertToWords(dollars).ToUpper()} DOLLARS AND {ConvertToWords(cents).ToUpper()} CENTS";
        }

        private string ConvertToWords(BigInteger number)
        {
            if (number == 0) return "zero";

            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] thousandsGroups = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" }; // Extendable as needed

            if (number < 20) return units[(int)number];
            if (number < 100) return tens[(int)(number / 10)] + (number % 10 > 0 ? "-" + units[(int)(number % 10)] : "");

            if (number < 1000) return units[(int)(number / 100)] + " hundred" + (number % 100 > 0 ? " and " + ConvertToWords(number % 100) : "");

            // Handle thousands and higher
            BigInteger thousandPower = 1000;
            int group = 0;

            while (number / thousandPower >= 1000)
            {
                thousandPower *= 1000;
                group++;
            }

            return ConvertToWords(number / thousandPower) + " " + thousandsGroups[group] +
                   (number % thousandPower > 0 ? " " + ConvertToWords(number % thousandPower) : "");
        }
    }
}
