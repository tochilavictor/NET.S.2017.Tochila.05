using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogic
{
    /// <summary>
    /// represets extension methods for double
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// imlements "bit view" for double
        /// </summary>
        /// <param name="d">number</param>
        /// <returns>bit representation</returns>
        public static string GetBits(this double d)
        {
            if (d == Double.Epsilon) return Convert.ToString(BitConverter.DoubleToInt64Bits(Double.Epsilon), 2).PadLeft(4, '0');

            const int doubleSize = 64;

            long l = BitConverter.DoubleToInt64Bits(d);
            string res = Convert.ToString(l, 2);
            res = res.PadLeft(doubleSize, '0');
            return res;
        }
        /// <summary>
        /// imlements only mantissa bit representation for double
        /// </summary>
        /// <param name="d">number</param>
        /// <returns>mantissa bit representation</returns>
        public static string GetMantissa(this double d)
        {
            const int mantissaSize = 52;

            long l = BitConverter.DoubleToInt64Bits(d);
            l = l & (long)(Math.Pow(2, mantissaSize) - 1);
            string res = Convert.ToString(l, 2);
            res = res.PadLeft(mantissaSize, '0');
            return res;
        }
        /// <summary>
        /// imlements only exponent bit representation for double
        /// </summary>
        /// <param name="d">number</param>
        /// <returns>exponent bit representation</returns>
        public static string GetExponent(this double d)
        {
            const int mantissaSize = 52;
            const int exponentSize = 11;

            long l = BitConverter.DoubleToInt64Bits(d);
            l = l >> mantissaSize;
            l = l & (long)(Math.Pow(2, exponentSize) - 1);
            string res = Convert.ToString(l, 2);
            res = res.PadLeft(exponentSize, '0');
            return res;
        }
        /// <summary>
        /// imlements only last sign bit representation for double
        /// </summary>
        /// <param name="d">number</param>
        /// <returns>true if 1, false if 0</returns>
        public static bool GetSignBit(this double d)
        {
            const int mantissaSize = 52;
            const int exponentSize = 11;

            long l = BitConverter.DoubleToInt64Bits(d);
            l = l >> mantissaSize + exponentSize;
            int res = (int)l & 1;
            return res == 1;
        }
    }
}
