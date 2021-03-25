using System;
using System.Collections.Generic;
using System.Text;

namespace csProject_2_01
{
    class Class1
    {
        public static void retemp()
        {
            int number1 = 1;
            int number2 = 2;
            Swap(number1, number2);
            Console.WriteLine("{0},{1}", number1, number2);
            Swap2(ref number1,ref number2);
            Console.WriteLine("{0},{1}", number1, number2);
        }
        static void Swap(int a, int b)
        {
            Console.WriteLine("{0},{1}",
            a , b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("{0},{1}",
            a, b);
        }
        static void Swap2(ref int a,ref int b)
        {
            Console.WriteLine("{0},{1}",
            a, b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("{0},{1}",
            a, b);
        }
    }
}
