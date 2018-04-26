using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Rec
    {
        public int Fact(int n)
        {
            if (n == 1) return 1;
            return Fact(n - 1) * n;
        }

        public void Display(string str)
        {
            
            Console.WriteLine(str);

            if (str.Length > 0)
                Display(str.Substring(1, str.Length - 1));
            else return;

            Console.Write(str[0]);


        }
    }
    class Program
    {        
        static void Main(string[] args)
        {
            int n = 2;
            string str = "test";

            Rec rec = new Rec();
            Console.WriteLine("Factorial {0} = {1}", 2, rec.Fact(2).ToString());
            Console.WriteLine("Line = {0}", str);
            rec.Display(str);
            Console.ReadLine();
        }
    }
}
