using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRef
{
    class Program
    {
        class RefSwap
        {
            int a, b;

            public RefSwap(int i, int j)
            {
                a = i;
                b = j;
            }
            public void Show()
            {
                Console.WriteLine("a = {0}, b = {1}", a, b);
            }
            public void Swap(ref RefSwap ob1, ref RefSwap ob2)
            {
                RefSwap t = ob1;
                ob1 = ob2;
                ob2 = t;
            }
        }

        static void Main(string[] args)
        {
            RefSwap x = new RefSwap(1, 2);
            RefSwap y = new RefSwap(3, 4);

            Console.WriteLine("До вызова");
            Console.Write("x ->"); x.Show();
            Console.Write("y ->"); y.Show();

            Console.WriteLine("После вызова Swap");
            x.Swap(ref x, ref y);

            Console.Write("x ->"); x.Show();
            Console.Write("y ->"); y.Show();

            Console.ReadLine();
        }
    }
}
