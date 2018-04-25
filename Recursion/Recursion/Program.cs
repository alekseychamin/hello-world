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
    }
    class Program
    {        
        static void Main(string[] args)
        {
            int n = 2;
            Rec rec = new Rec();
            Console.WriteLine("Factorial {0} = {1}", 2, rec.Fact(2).ToString());
            Console.ReadLine();
        }
    }
}
