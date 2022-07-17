using System;
using System.Collections.Generic;
using System.Numerics;

namespace Excercise01
{
    public static class IntegerExtension
    {
        public static Dictionary<int, string> NumberNames = new Dictionary<int, string>
        {
            {0, null },{1, "one" },{2, "two" },{3, "three" },{4, "four" },{5, "five" },{6, "six" },{7, "seven" },{8, "eight" },{9, "nine" }, {10, "ten" },
            {11, "eleven" },{12, "twelve" },{13, "thirteen" },{14, "fourteen" },{15, "fifteen" },{16, "sixteen" },{17, "seventeen" },{18, "eighteen" },{19, "nineteen" }

        };
        public static Dictionary<int, string> TensMultiples = new Dictionary<int, string>
        {
            { 2, "twenty"}, { 3, "thirty"}, { 4, "forty"},{ 5, "fifty"},{ 6, "sixty"},{ 7, "seventy"},{ 8, "eighty"},{ 9, "ninety"},
        };
        public static Dictionary<int, string> TriMultiples = new Dictionary<int, string>
        {
            { 1, "thousand"},{ 2, "million"},{ 3, "billion"},{ 4, "trillion"},{ 5, "quadrillion"},{ 6, "quintillion"},
        };

        public static string GetHundredsString(int num)
        {
            if (num < 100)
            {
                return GetTensString(num);
            }
            else
            {
                int hundredth = num / 100;
                int balance = num % 100;
                return $"{NumberNames.GetValueOrDefault(hundredth)} hundred{(balance == 0 ? null : $" and {GetTensString(balance)}")}";
            }
        }

        public static int GetTriMultipleString(BigInteger num, int multiples)
        {
            int divider = 1000;
            if (num == 0)
            {
                return 0;
            }
            else if (num / divider == 0)
            {
                return multiples;
            }
            else
            {
                return GetTriMultipleString(num / divider, multiples + 1);
            }

        }
        public static string InWords(this BigInteger num)
        {
            return InWords(num, null);
        }
        public static string InWords(this int num)
        {
            return InWords(num, null);
        }
        public static string InWords(this long num)
        {
            return InWords(num, null);
        }
        public static string InWords(BigInteger num, string value)
        {
            double triMultiples = (double)GetTriMultipleString(num, 0);
            double divider = Math.Pow(1000, triMultiples);
            BigInteger nth = num / (BigInteger)divider;
            BigInteger balance = num % (BigInteger)divider;
            if (triMultiples == 0)
            {
                string hundredsString = GetHundredsString((int)num);
                return string.IsNullOrEmpty(value) ? hundredsString : string.IsNullOrEmpty(hundredsString) ? "" : num < 100 ? $"{value} and {hundredsString}" : $"{value} {hundredsString}";
            }
            else
            {
                var inWords = $"{GetHundredsString((int)nth)} {TriMultiples.GetValueOrDefault((int)triMultiples)}";
                value = (string.IsNullOrEmpty(value) ? "" : $"{value}, ") + inWords;
                return InWords(balance, value);
            }
        }

        public static string GetTensString(this int num)
        {

            if (num == 0)
            {
                return null;
            }
            else if (num % 100 < 20)
            {
                return NumberNames.GetValueOrDefault(num);
            }
            else
            {
                int ones = num % 10;
                int tens = num / 10;

                return ones == 0 ? TensMultiples.GetValueOrDefault(tens) : $"{TensMultiples.GetValueOrDefault(tens)} {NumberNames.GetValueOrDefault(ones)}";

            }
        }
    }
}
