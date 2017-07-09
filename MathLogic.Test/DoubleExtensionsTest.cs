
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MathLogic.Test
{
    class DoubleExtensionsTest
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(0.5, ExpectedResult = "0011111111100000000000000000000000000000000000000000000000000000")]
        [TestCase(16.7, ExpectedResult = "0100000000110000101100110011001100110011001100110011001100110011")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]

        public string GetBits_normaldouble_PositiveTest(double d)
        {
            return d.GetBits();
        }

        [TestCase(-255.255, ExpectedResult = true)]
        [TestCase(255.255, ExpectedResult = false)]
        [TestCase(-1, ExpectedResult = true)]
        [TestCase(16, ExpectedResult = false)]
        public bool GetSignBit_normaldouble_PositiveTest(double d)
        {
            return d.GetSignBit();
        }

        [TestCase(-255.255, ExpectedResult = "10000000110")]
        [TestCase(255.255, ExpectedResult = "10000000110")]
        [TestCase(0.5, ExpectedResult = "01111111110")]
        [TestCase(16.7, ExpectedResult = "10000000011")]
        public string GetExponent_normaldouble_PositiveTest(double d)
        {
            return d.GetExponent();
        }

        [TestCase(-255.255, ExpectedResult = "1111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "1111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "1111111111111111111111111111111000000000000000000000")]
        [TestCase(0.5, ExpectedResult = "0000000000000000000000000000000000000000000000000000")]
        [TestCase(16.7, ExpectedResult = "0000101100110011001100110011001100110011001100110011")]
        public string GetMantissa_normaldouble_PositiveTest(double d)
        {
            return d.GetMantissa();
        }
    }
}
