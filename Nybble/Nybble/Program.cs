using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybble
{
    class Nybble
    {
        int Value;

        public Nybble()
        {
            Value = 0;
        }

        public Nybble(int value)
        {
            // ограничение на хранение данных 0-15
            SetValue(value);
        }
        
        public void SetValue(int value)
        {
            Value = (int)(value & (0x0000000F));
        }

        public int GetValue()
        {
            return Value;
        }

        public static Nybble operator +(Nybble ob1, Nybble ob2)
        {
            Nybble result = new Nybble();
            result.SetValue(ob1.Value + ob2.Value);
            return result;
        }

        public static Nybble operator +(int ob1, Nybble ob2)
        {
            Nybble result = new Nybble();
            result.SetValue(ob1 + ob2.Value);
            return result;
        }

        public static Nybble operator +(Nybble ob1, int ob2)
        {
            Nybble result = new Nybble();
            result.SetValue(ob1.Value + ob2);
            return result;
        }

        public static explicit operator Nybble(int value)
        {
            Nybble result = new Nybble();
            result.SetValue(value);
            return result;
        }

        public static explicit operator int(Nybble ob)
        {
            return ob.Value;
        }

        public static Nybble operator ++(Nybble ob)
        {
            Nybble result = new Nybble();
            result.SetValue(ob.Value + 1);
            return result;
        }

        public static bool operator >(Nybble ob1, Nybble ob2)
        {
            if (ob1.Value > ob2.Value)
                return true;
            else
                return false;
        }

        public static bool operator <(Nybble ob1, Nybble ob2)
        {
            if (ob1.Value < ob2.Value)
                return true;
            else
                return false;
        }

        public static bool operator ==(Nybble ob1, Nybble ob2)
        {
            if (ob1.Value == ob2.Value)
                return true;
            else
                return false;              
        }

        public static bool operator !=(Nybble ob1, Nybble ob2)
        {
            if (ob1.Value != ob2.Value)
                return true;
            else
                return false;
        }

    }
    class NybbleDemo
    {
        static void Main()
        {
            Nybble a = new Nybble(5);
            Nybble b = new Nybble(4);
            Nybble c = a + b;
            Console.WriteLine("a + b = {0} + {1} = {2}", a.GetValue(), b.GetValue(), c.GetValue());

            int d = 15;
            c = a + d;
            Console.WriteLine("a + d = {0} + {1} = {2}", a.GetValue(), d, c.GetValue());

            c = (Nybble)d;
            Console.WriteLine("(Nybble)d = (Nybble){0} => {1}", d, c.GetValue());

            d = (int)c;
            Console.WriteLine("(int)c = (int){0} => {1}", c.GetValue(), d);

            Console.WriteLine("a > b = {0}", a > b);

            Console.ReadLine();                       
        }
    }
}
