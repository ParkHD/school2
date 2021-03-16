using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sbyte.MaxValue);
            Console.WriteLine(byte.MaxValue);
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(float.MaxValue);
            Console.WriteLine(decimal.MaxValue);

            object objectValue = true;
            bool x = false;

            if((bool)objectValue == x)
            {

            }

            sbyte s = 10;
            Console.WriteLine(s);

            char newChar = 'd';
            int newInt2 = (int)newChar;
            Console.WriteLine(newInt2);


            string width, height;
            width = Console.ReadLine();
            height = Console.ReadLine();
            int newX = int.Parse(width);
            int newY = int.Parse(height);
            int XY = newX * newY;
            Console.WriteLine(XY);

            int width1, height1;
            width1 = int.Parse(Console.ReadLine());
            height1 = int.Parse(Console.ReadLine());
            int XY1 = width1 * height1;
            Console.WriteLine(XY1);
        } 
    }
}
