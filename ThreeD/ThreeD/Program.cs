using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeD
{
    class ThreeD
    {
        int x, y, z;

        public ThreeD() { x = y = z = 0; }
        public ThreeD(int x, int y, int z) { this.x = x;  this.y = y; this.z = z; }

        public static ThreeD operator +(ThreeD ob1, ThreeD ob2)
        {
            ThreeD result = new ThreeD();
            result.x = ob1.x + ob2.x;
            result.y = ob1.y + ob2.y;

            return result;
        }

        public static ThreeD operator |(ThreeD op1, ThreeD op2)
        {
            if ((op1.x != 0) || (op1.y != 0) || (op1.z != 0) |
                (op2.x != 0) || (op2.y != 0) || (op2.z != 0))
                return new ThreeD(1, 1, 1);
            else
                return new ThreeD();
        }

        public static bool operator true(ThreeD ob)
        {
            if ((ob.x != 0) || (ob.y != 0) || (ob.z != 0))
                return true;
            else
                return false;
        }

        public static bool operator false(ThreeD ob)
        {
            if ((ob.x == 0) && (ob.y == 0) && (ob.z == 0))
                return true;
            else
                return false;
        }

        public static bool operator !(ThreeD ob)
        {
            if (ob)
                return false;
            else
                return true;
           
        }
    }

    class ThreeDDemo
    {
        static void Main(string[] args)
        {
            ThreeD th1 = new ThreeD(1, 2, 3);
            ThreeD th2 = new ThreeD(4, 5, 6);
            ThreeD th3 = new ThreeD();

            ThreeD th4 = th1 + th2;

            if (th1 || th2)
                Console.WriteLine("th1 || th2");

            if (!th3)
                Console.WriteLine("th3 - false");

            Console.ReadLine();
        }
    }
}
