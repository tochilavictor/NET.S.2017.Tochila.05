using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MathLogic
{
    /// <summary>
    /// implements Polynomial instance and some operations Polynomials
    /// </summary>
    public class Polynomial
    {
        private double[] koefs;
        private string mathView;

        public Polynomial(params double[] koeficients)
        {
            ValidateArray(koeficients);
            this.koefs = new double[koeficients.Length];
            Array.Copy(koeficients, koefs, koeficients.Length);
            this.GetMathView();
        }
        /// <summary>
        /// returns polynomial value from argument
        /// </summary>
        /// <param name="x">argument</param>
        /// <returns>value (fun(x))</returns>
        public double CalculateValue(double x)
        {
            double result = 0;
            for (int i = 0; i < koefs.Length; i++)
            {
                result += koefs[i] * Math.Pow(x, i);
            }
            return result;
        }
        /// <summary>
        /// represents Usual Math View for Polynomial 
        /// <example>X^2 + 18</example>
        /// </summary>
        public string MathView => mathView;

        #region Operators

        public static Polynomial operator +(Polynomial p, double number)
        {
            double[] newkoefs = new double[p.koefs.Length];
            Array.Copy(p.koefs, newkoefs, p.koefs.Length);
            newkoefs[0] += number;
            return new Polynomial(newkoefs);
        }
        public static Polynomial operator -(Polynomial p, double number)
        {
            return p + -1 * number;
        }
        public static Polynomial operator *(Polynomial p, double number)
        {
            double[] newkoefs = new double[p.koefs.Length];
            for (int i = 0; i < newkoefs.Length; i++)
            {
                newkoefs[i] = p.koefs[i] * number;
            }
            return new Polynomial(newkoefs);
        }
        public static Polynomial operator /(Polynomial p, double number)
        {
            return p * (1.0 / number);
        }
        
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            int biggersize = Math.Max(a.koefs.Length, b.koefs.Length);
            int smallersize = Math.Min(a.koefs.Length, b.koefs.Length);
            double[] newkoefs = new double[biggersize];
            int i;
            for (i = 0; i < smallersize; i++)
            {
                newkoefs[i] = a.koefs[i] + b.koefs[i];
            }
            while (i < a.koefs.Length)
            {
                newkoefs[i] = a.koefs[i];
                i++;
            }
            while (i < b.koefs.Length)
            {
                newkoefs[i] = b.koefs[i];
                i++;
            }
            return new Polynomial(newkoefs);
        }
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            double[] reverskoefs = new double[b.koefs.Length];
            for (int i = 0; i < reverskoefs.Length; i++)
            {
                reverskoefs[i] = -1 * b.koefs[i];
            }
            return a + new Polynomial(reverskoefs);
        }
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            double[] newkoefs = new double[a.koefs.Length + b.koefs.Length - 1];

            for (int i = 0; i < a.koefs.Length; i++)
            {
                for (int j = 0; j < b.koefs.Length; j++)
                {
                    newkoefs[i + j] += a.koefs[i] * b.koefs[j];
                }
            }
            return new Polynomial(newkoefs);
        }
        #endregion
        private void GetMathView()
        {
            StringBuilder result = new StringBuilder();
            for (int i = koefs.Length - 1; i != -1; i--)
            {
                if (koefs[i] == 0) continue;
                if (koefs[i] > 0 && i != koefs.Length - 1) result.Append(" + ");
                if (koefs[i] < 0) result.Append(" - ");
                if (Math.Abs(koefs[i]) != 1 || i == 0) result.Append(Math.Abs(koefs[i]));
                if (i != 0) result.Append("X");
                if (i > 1) result.Append("^" + i);
            }
            mathView = result.ToString();
        }
        static void ValidateArray(double[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Empty array");
        }
    }
}
