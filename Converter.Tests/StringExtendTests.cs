using NUnit.Framework;
using System;

namespace Converter.Tests
{
    public static class StringExtendTests
    {
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]
        [TestCase("100", 10, ExpectedResult = 100)]
        [TestCase("0", 6, ExpectedResult = 0)]
        [TestCase("1111111111111111111111111111111", 2, ExpectedResult = int.MaxValue)]
        [TestCase("13344223434042", 5, ExpectedResult = int.MaxValue)]
        [TestCase("17777777777", 8, ExpectedResult = int.MaxValue)]
        public static int StringToInt32_ValidCases(this string number, int radix)
    => StringExtend.StringToInt32(number, radix);

        [TestCase("1AeF101", 2)]
        [TestCase("764241", 20)]
        [TestCase("SA123", 2)]
        public static void StringToInt32_ArgumentExeption(this string number, int radix)
    => Assert.Throws<ArgumentException>(() => StringExtend.StringToInt32(number, radix));

        [TestCase("10000000000000000000000000000000", 2)]
        [TestCase("12112122212110202102", 3)]
        [TestCase("2000000000000000", 4)]
        [TestCase("111111111111111111111111111111111111111111111", 2)]
        [TestCase("80000000", 16)]
        public static void StringToInt32_OverFlowExeption(this string number, int radix)
    => Assert.Throws<OverflowException>(() => StringExtend.StringToInt32(number, radix));
    }  
}