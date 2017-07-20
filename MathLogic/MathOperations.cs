using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogic
{
    public static class MathOperations
    {
        public delegate int Algorythm(int lhs, int rhs);

        private static readonly Algorythm Euclid = GcdEuclidLogic;
        private static readonly Algorythm Stein = GcdBinaryLogic;
        #region GCDEuclidPublic
        /// <summary>
        /// implements Euclid GCD algorythm for 2 integers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="time">time</param>
        /// <returns>GCD</returns>
        public static int Gcd(int a, int b, out double time)
        {
            return Gcdfor2intsPlusTime(a,b, Euclid,true,out time);
        }
        public static int Gcd(int a, int b)
        {
            return Gcdfor2ints(a, b, Euclid, true);
        }
        /// <summary>
        /// implements Euclid GCD algorythm for 3 integers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <param name="time">time</param>
        /// <returns>GCD</returns>
        public static int Gcd(int a, int b, int c, out double time)
        {
            return Gcdfor3intsPlusTime(a,b,c,Euclid,true,out time);
        }
        public static int Gcd(int a, int b, int c)
        {
            return Gcdfor3ints(a, b, c, Euclid, true);
        }
        /// <summary>
        /// implements Euclid GCD algorythm for integers array of any lenght
        /// </summary>
        /// <param name="time">time</param>
        /// <param name="a">integers array</param>
        /// <returns></returns>
        public static int Gcd(out double time, params int[] a)
        {
            return GcdforparamsPlusTime(out time,Euclid,true,a);
        }
        public static int Gcd(params int[] a)
        {
            return Gcdforparams(Euclid, true, a);
        }
        #endregion

        #region GCDSteinsPublic
        /// <summary>
        /// implements Steins binary GCD algorythm for 2 integers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="time">time</param>
        /// <returns>GCD</returns>
        public static int GcdBinary(int a, int b, out double time)
        {
            return Gcdfor2intsPlusTime(a, b, Stein, false, out time);
        }
        public static int GcdBinary(int a, int b)
        {
            return Gcdfor2ints(a, b, Stein, false);
        }
        /// <summary>
        /// implements Steins binary GCD algorythm for 3 integers
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <param name="time">time</param>
        /// <returns>GCD</returns>
        public static int GcdBinary(int a, int b, int c, out double time)
        {
            return Gcdfor3intsPlusTime(a,b,c,Stein,false,out time);
        }
        public static int GcdBinary(int a, int b, int c)
        {
            return Gcdfor3ints(a, b, c, Stein, false);
        }
        /// <summary>
        /// implements Steins binary GCD algorythm for integers array of any lenght
        /// </summary>
        /// <param name="time">time</param>
        /// <param name="a">integers array</param>
        /// <returns></returns>
        public static int GcdBinary(out double time, params int[] a)
        {
            return GcdforparamsPlusTime(out time, Stein, false, a);
        }
        public static int GcdBinary(params int[] a)
        {
            return Gcdforparams(Stein, false, a);
        }


        #endregion

        #region private_methods
        private static int Gcdfor2ints(int a, int b, Algorythm algorythm, bool allowNegative)
        {
            if (a == 0 && b == 0)
                throw new ArgumentOutOfRangeException("At least 1 number must be not 0");

            if (!allowNegative)
            {
                if (a < 0 || b < 0)
                    throw new ArgumentOutOfRangeException("Numbers must be nonnegative");
            }

            int k = algorythm(a, b);

            return k;
        }
        private static int Gcdfor2intsPlusTime(int a, int b, Algorythm algorythm, bool allowNegative, out double time)
        {
            if (a == 0 && b == 0)
                throw new ArgumentOutOfRangeException("At least 1 number must be not 0");

            var sw = new Stopwatch();
            sw.Start();

            if (!allowNegative)
            {
                if (a < 0 || b < 0)
                    throw new ArgumentOutOfRangeException("Numbers must be nonnegative");
            }

            int k = algorythm(a, b);

            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;

            return k;
        }
        private static int Gcdfor3ints(int a, int b, int c, Algorythm algorythm, bool allowNegative)
        {
            if (a == 0 && b == 0 && c == 0)
                throw new ArgumentOutOfRangeException("At least 1 number must be not 0");
            if (!allowNegative)
            {
                if (a < 0 || b < 0 || c < 0)
                    throw new ArgumentOutOfRangeException("Numbers must be nonnegative");
            }
            int k = algorythm(a, algorythm(b, c));

            return k;
        }
        private static int Gcdfor3intsPlusTime(int a, int b, int c, Algorythm algorythm, bool allowNegative, out double time)
        {
            if (a == 0 && b == 0 && c == 0)
                throw new ArgumentOutOfRangeException("At least 1 number must be not 0");

            var sw = new Stopwatch();
            sw.Start();

            if (!allowNegative)
            {
                if (a < 0 || b < 0 || c < 0)
                    throw new ArgumentOutOfRangeException("Numbers must be nonnegative");
            }
            int k = algorythm(a, algorythm(b, c));

            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;

            return k;
        }
        private static int Gcdforparams(Algorythm algorythm, bool allowNegative, params int[] a)
        {
            ValidateArray(a);

            if (Contains0Only(a))
                throw new ArgumentOutOfRangeException("At least 1 number must be not 0");

            if (!allowNegative)
            {
                if (!ContainsOnlyNonNegative(a)) throw new ArgumentOutOfRangeException("Numbers must be nonnegative");
            }

            int[] b = new int[a.Length];
            Array.Copy(a, b, a.Length);

            for (int i = b.Length - 2; i != -1; i--)
            {
                b[i] = algorythm(b[i], b[i + 1]);
            }

            return b[0];
        }
        private static int GcdforparamsPlusTime(out double time, Algorythm algorythm, bool allowNegative, params int[] a)
        {
            ValidateArray(a);

            if (Contains0Only(a))
                throw new ArgumentOutOfRangeException("At least 1 number must be not 0");

            var sw = new Stopwatch();
            sw.Start();

            if (!allowNegative)
            {
                if (!ContainsOnlyNonNegative(a)) throw new ArgumentOutOfRangeException("Numbers must be nonnegative");
            }

            int[] b = new int[a.Length];
            Array.Copy(a, b, a.Length);

            for (int i = b.Length - 2; i != -1; i--)
            {
                b[i] = algorythm(b[i], b[i + 1]);
            }

            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;

            return b[0];
        }
        private static int GcdEuclidLogic(int a, int b)
        {
            if (a == 0 || b == 0)
                return Math.Max(a, b);

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }
        private static bool Contains0Only(int[] a)
        {
            foreach (int el in a)
            {
                if (el != 0) return false;
            }
            return true;
        }
        private static bool ContainsOnlyNonNegative(int[] a)
        {
            foreach (int el in a)
            {
                if (el < 0) return false;
            }
            return true;
        }
        private static void ValidateArray(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Empty array");
        }
        private static int GcdBinaryLogic(int u, int v)
        {
            if (u == v)
                return u;

            if (u == 0 || v == 0)
                return Math.Max(u, v);

            if ((~u & 1) == 1)
            {
                if ((v & 1) == 1)
                    return GcdBinaryLogic(u >> 1, v);
                else
                    return GcdBinaryLogic(u >> 1, v >> 1) << 1;
            }

            if ((~v & 1) == 1)
                return GcdBinaryLogic(u, v >> 1);

            if (u > v)
                return GcdBinaryLogic((u - v) >> 1, v);

            return GcdBinaryLogic((v - u) >> 1, u);
        }
        #endregion
    }
   
}
