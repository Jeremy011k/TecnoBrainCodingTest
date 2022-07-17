using System;
using System.Numerics;
using Xunit;
using Excercise01;

namespace Excercise01Tests
{
    public class Excercise01Tests
    {
        private static readonly BigInteger V = BigInteger.Parse("18456002032011000007");

        [Fact]
        public void LargeAmountInWords()
        {//eighteen quintillion, four hundred and fifty six quadrillion, two trillion, thirty two billion, eleven million and seven
         //eighteen quintillion, four hundred and fifty-six quadrillion, two trillion, thirty-two billion, eleven million, and seven//
            Assert.Equal( "eighteen quintillion, four hundred and fifty-six quadrillion, two trillion, thirty-two billion, eleven million, and seven", V.InWords());
        }

        [Theory]
        [InlineData(456, "four hundred and fifty six")]
        [InlineData(367, "three hundred and sixty seven")]
        [InlineData(6, "six")]
        [InlineData(18000000, "eighteen million")]
        public void AmountInWords(BigInteger number, string expected)
        {
            Assert.Equal( expected, number.InWords());
        }




    }
}
