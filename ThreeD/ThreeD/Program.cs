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
            result.x = ob1.x + o
        }
    }

    class ThreeDDemo
    {
        static void Main(string[] args)
        {
        }
    }
}
