using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using MathLogic;
using NUnit.Framework;

namespace MathLogic.Test
{
    [TestFixture]
    public class MathOperationsTest
    {
        [TestCase(508, 1397, 1.0, ExpectedResult = 127)]
        [TestCase(0, 1397, 1.0, ExpectedResult = 1397)]
        [TestCase(508, 0, 1.0, ExpectedResult = 508)]
        [TestCase(45, 60, 1.0, ExpectedResult = 15)]
        [TestCase(9, -6, 1.0, ExpectedResult = 3)]
        [TestCase(-5, -25, 1.0, ExpectedResult = 5)]
        [TestCase(-20, 18, 1.0, ExpectedResult = 2)]
        [TestCase(11, 17, 1.0, ExpectedResult = 1)]
        public int Gcd_NormalTwoNumbers_PositiveTest(int a, int b, out double t)
        {
            return MathOperations.Gcd(a, b, out t);
        }

        [TestCase(508, 1397, 254, 1.0, ExpectedResult = 127)]
        [TestCase(0, 1397, 0, 1.0, ExpectedResult = 1397)]
        [TestCase(0, 1397, 654, 1.0, ExpectedResult = 1)]
        [TestCase(45, -60, 90 ,1.0, ExpectedResult = 15)]
        [TestCase(9, 6, 12 , 1.0, ExpectedResult = 3)]
        [TestCase(15, 25, -75 , 1.0, ExpectedResult = 5)]
        public int Gcd_NormalThreeNumbers_PositiveTest(int a, int b,int c, out double t)
        {
            return MathOperations.Gcd(a, b, c, out t);
        }

        [TestCase(1.0, 508, 1397, 254, 14, 162, ExpectedResult = 1)]
        [TestCase( 1.0, 0, -60, 0, 15, 30, ExpectedResult = 15)]
        [TestCase(1.0, 8, 64, 32, 12, ExpectedResult = 4)]
        [TestCase(1.0, -8, 64, 32, 12,43,23,545,657,32,213,45,234, ExpectedResult = 1)]
        public int Gcd_NormalParamsNumbers_PositiveTest(out double t, params int[] a)
        {
            return MathOperations.Gcd(out t, a);
        }

        [TestCase(508, 1397, 1.0, ExpectedResult = 127)]
        [TestCase(0, 1397, 1.0, ExpectedResult = 1397)]
        [TestCase(508, 0, 1.0, ExpectedResult = 508)]
        [TestCase(45, 60, 1.0, ExpectedResult = 15)]
        [TestCase(9, 6, 1.0, ExpectedResult = 3)]
        [TestCase(11, 17, 1.0, ExpectedResult = 1)]
        public int GcdBinary_NormalTwoNumbers_PositiveTest(int a, int b, out double t)
        {
            return MathOperations.GcdBinary(a, b, out t);
        }

        [TestCase(508, 1397, 254, 1.0, ExpectedResult = 127)]
        [TestCase(0, 1397, 0, 1.0, ExpectedResult = 1397)]
        [TestCase(0, 1397, 654, 1.0, ExpectedResult = 1)]
        [TestCase(45, 60, 90, 1.0, ExpectedResult = 15)]
        [TestCase(9, 6, 12, 1.0, ExpectedResult = 3)]
        [TestCase(15, 25, 75, 1.0, ExpectedResult = 5)]
        public int GcdBinary_NormalThreeNumbers_PositiveTest(int a, int b, int c, out double t)
        {
            return MathOperations.GcdBinary(a, b, c, out t);
        }

        [TestCase(1.0, 508, 1397, 254, 14, 162, ExpectedResult = 1)]
        [TestCase(1.0, 0, 60, 0, 15, 30, ExpectedResult = 15)]
        [TestCase(1.0, 8, 64, 32, 12, ExpectedResult = 4)]
        [TestCase(1.0, 8, 64, 32, 12, 43, 23, 545, 657, 32, 213, 45, 234, ExpectedResult = 1)]
        public int GcdBinary_NormalParamsNumbers_PositiveTest(out double t, params int[] a)
        {
            return MathOperations.GcdBinary(out t, a);
        }
        /*
         * [ExpectedException] не работает, а в лямбда выражениях нельзя использовать out-параметры
        [TestCase(0, 0, 1.0)]
        public void Gcd_only0s_ThrowsArgumentOutOfRangeException(int a, int b, out double t)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathOperations.Gcd(a, b, out t));
        }
        */
    }
}
