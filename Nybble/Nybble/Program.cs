using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybble
{
    class Nybble
    {
        public int Value;

        public Nybble()
        {
            Value = 0;
        }

        public Nybble(int value)
        {
            // ограничение на хранение данных 0-15
            Value = (int) (value & (0x0000000F));
        }

        public static Nybble operator +(Nybble ob1, Nybble ob2)
        {
            return new Nybble { Value = ob1.Value + ob2.Value };
        }

        public static Nybble operator +(int ob1, Nybble ob2)
        {
            return new Nybble { Value = ob1 + ob2.Value };
        }

        public static Nybble operator +(Nybble ob1, int ob2)
        {
            return new Nybble { Value = ob1.Value + ob2 };
        }

    }
    class NybbleDemo
    {
        static void Main()
        {
            Nybble a = new Nybble(15);
            Nybble b = new Nybble(4);
            Nybble c = a + b;
            Console.WriteLine("a + b = {0} + {1} = {2}", a.Value, b.Value, c.Value);

            Console.ReadLine();                       
        }
    }
}
