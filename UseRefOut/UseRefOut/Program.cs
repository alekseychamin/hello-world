using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseRefOut
{
    class Program
    {
        static class Decompose
        {
            /* разделить числовое значение с плавающей точкой на целую и дробную часть */
            public static int GetParts(double n, out double frac)
            {
                int whole = (int) n;
                frac = n - whole;
                return whole;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число : ");
            string input = Console.ReadLine();
            double n = Convert.ToDouble(input);            
            int whole;
            double frac;
            whole = Decompose.GetParts(n, out frac);

            Console.WriteLine("Целая часть = {0}; дробная часть числа = {1}", whole, frac);
        }
    }
}
