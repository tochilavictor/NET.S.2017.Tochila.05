using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MathLogic
{
    static class DoubleExtensionsBits
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct LongDouble
        {
            [FieldOffset(0)]
            public long l;
            [FieldOffset(0)]
            public double d;

            public LongDouble(double dv) : this()
            {
                d = dv;
            }
        }
        // works only for positive doubles
        public static string DoubleToBits(double d)
        {
            const int doublesize = 64;
            bool isNegative = d < 0;

            LongDouble ld = new LongDouble(Math.Abs(d));

            StringBuilder sb = new StringBuilder("");
            long tmp = ld.l;

            for (int i = 0; i < doublesize - 1; i++)
            {
                if (tmp % 2 == 0) sb.Append('0');
                else sb.Append('1');
                tmp = tmp / 2;
            }
            if (isNegative) sb.Append('1');
            else sb.Append('0');
            string res = sb.ToString();
            res = Reverse(res);
            return res;
        }
        private static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

    }
}
