using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace MathLogic.Test
{
    [TestFixture()]
    class PolynomialTest
    {
        [TestCase(new double[] { 2, 0, 1 },ExpectedResult = "X^2 + 2")]
        [TestCase(new double[] { 9, 2, 1, 1 },  ExpectedResult = "X^3 + X^2 + 2X + 9")]
        [TestCase(new double[] { 12, 1}, ExpectedResult = "X + 12")]
        [TestCase(new double[] {0 , 0, 1 }, ExpectedResult = "X^2")]
        [TestCase(new double[] { -7, 0, 1 , 0,-1 }, ExpectedResult = " - X^4 + X^2 - 7")]
        public string MathView_NormalKoefs_PositiveTest(double[] koefs)
        {
            var p = new Polynomial(koefs);
            return p.MathView;
        }
        [TestCase(new double[] {2,0,1},3.0,ExpectedResult = 11)]
        [TestCase(new double[] { 2, 0, 1 }, 0, ExpectedResult = 2)]
        [TestCase(new double[] { 0, 0, 1 }, 3.0, ExpectedResult = 9)]
        [TestCase(new double[] { 0, 0, 1 }, -3.0, ExpectedResult = 9)]
        [TestCase(new double[] { 12, 1 }, -20, ExpectedResult = -8)]
        public double CalculateValue_NormalKoefs_PositiveTest(double[] koefs, double value)
        {
            var p= new Polynomial(koefs);
            return p.CalculateValue(value);
        }
        [TestCase(new double[] { 2, 0, 1 }, 5 , ExpectedResult = "X^2 + 7")]
        [TestCase(new double[] { 9, 2, 1, 1 }, 190, ExpectedResult = "X^3 + X^2 + 2X + 199")]
        [TestCase(new double[] { 12, 1 }, -500, ExpectedResult = "X - 488")]
        public string Addition_PolynomialplusDouble_PositiveTest(double[] koefs, double number)
        {
            var p = new Polynomial(koefs);
            p = p + number;
            return p.MathView;
        }
        [TestCase(new double[] { 2, 0, 1 }, 5, ExpectedResult = "X^2 - 3")]
        [TestCase(new double[] { 9, 2, 1, 1 }, 190, ExpectedResult = "X^3 + X^2 + 2X - 181")]
        [TestCase(new double[] { 12, 1 }, -500, ExpectedResult = "X + 512")]
        public string Subtraction_PolynomialminusDouble_PositiveTest(double[] koefs, double number)
        {
            var p = new Polynomial(koefs);
            p = p - number;
            return p.MathView;
        }
        [TestCase(new double[] { 2, 0, 1 }, 3, ExpectedResult = "3X^2 + 6")]
        [TestCase(new double[] { 9, 2, 1, 1 }, 10, ExpectedResult = "10X^3 + 10X^2 + 20X + 90")]
        [TestCase(new double[] { -12, 1 }, -5, ExpectedResult = " - 5X + 60")]
        public string Multiplication_PolynomialmultiDouble_PositiveTest(double[] koefs, double number)
        {
            var p = new Polynomial(koefs);
            p = p * number;
            return p.MathView;
        }
        [TestCase(new double[] { 9, 0, 3 }, 3, ExpectedResult = "X^2 + 3")]
        [TestCase(new double[] { 8, 4, 2, 1 }, 2, ExpectedResult = "0,5X^3 + X^2 + 2X + 4")]
        [TestCase(new double[] { -12, 1 }, -5, ExpectedResult = " - 0,2X + 2,4")]
        public string Deviding_PolynomialdevideDouble_PositiveTest(double[] koefs, double number)
        {
            var p = new Polynomial(koefs);
            p = p / number;
            return p.MathView;
        }
        [TestCase(new double[] { 7, 1 }, new double[] { 0, 1 }, ExpectedResult = "X^2 + 7X")]
        [TestCase(new double[] { 5,4,2 }, new double[] { 3, 1 }, ExpectedResult = "2X^3 + 10X^2 + 17X + 15")]
        [TestCase(new double[] { -12, 1 }, new double[] { 3, 1 }, ExpectedResult = "X^2 - 9X - 36")]
        public string Multiplication_PolynomialmultiPolynomial_PositiveTest(double[] koefs, double[] koefs2)
        {
            var p = new Polynomial(koefs);
            var p2 = new Polynomial(koefs2);
            p = p * p2;
            return p.MathView;
        }

        [TestCase(new double[] {})]
        public void Ctor_EmptyArray_ThrowsArgumentException(double[] koefs)
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(koefs));
        }

        [TestCase(null)]
        public void Ctor_NullRefference_ThrowsArgumentNullException(double[] koefs)
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(koefs));
        }
    }
}
