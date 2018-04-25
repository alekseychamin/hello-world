using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        class Stack
        {
            // звкрытые члены класса
            char[] stck; // массив для хранения символов
            int tos; // текущий индекс в массиве 

            public int Index
            {
                get
                {
                    return tos;
                }
            }

            public bool IsFull
            {
                get
                {
                    return (tos == stck.Length);         
                }
            }

            public bool IsEmpty
            {
                get
                {
                    return (tos == 0); 
                }
            }

            public int Capacity
            {
                get
                {
                    return stck.Length;
                }
            }

            // сконструировать пустой объект по заданному размеру стека
            public Stack(int size)
            {
                stck = new char[size];
                tos = 0;
            }
            
            // сконструировать объект класса Stack из существующего стека
            public Stack(Stack ob)
            {
                stck = new char[ob.stck.Length];
                // скопировать элементы в новый стек
                for (int i = 0; i < ob.tos; i++)                
                    stck[i] = ob.stck[i];
                
                // установть переменную tos для нового стека
                tos = ob.tos;                
            }

            // поместить символы в стек
            public void Push(char ch)
            {
                if (tos == stck.Length)
                {
                    Console.WriteLine("Стек заполнен!");
                    return;
                }
                stck[tos] = ch;
                tos++;
            }

            // достать символ из стека
            public char Pop()
            {
                if (tos == 0)
                {
                    Console.WriteLine("Стек пуст!");
                    return (char) 0;              
                }
                tos--;
                return stck[tos];
            }

        }

        static void Main(string[] args)
        {
            Stack stk1 = new Stack(1024);

            for (int i = 0; !stk1.IsFull; i++)
            {
                stk1.Push((char)('A' + i));
            }

            while (!stk1.IsEmpty)
            {
                char ch = stk1.Pop();
                Console.WriteLine("El. stack # {0} = {1}", stk1.Index, ch);
            }

            Console.ReadLine();

        }
    }
}
