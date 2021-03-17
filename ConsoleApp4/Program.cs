using System;
using System.Text;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = "Hello World!";
            //char[] textArray = { 'h', 'e', 'l', 'l', 'o' };
            //Console.WriteLine(text);
            //text = null;

            //text = "Bye World!";
            //Console.WriteLine(text);

            //StringBuilder builder = new StringBuilder();
            //builder.Append("Hello");
            //builder.Append(" World!");
            //Console.WriteLine(builder);

            //Console.WriteLine(Element.Fire);


            //Item item = 0;
            //item |= Item.A;

            //item |= Item.C;
            //Console.WriteLine(item);

         
            string x = Console.ReadLine();
            Vector vector;

            switch(x)
            {
                case "l":
                    vector = Vector.Left;
                    break;
                case "r":
                    vector = Vector.Right;
                    break;
                case "u":
                    vector = Vector.Up;
                    break;
                case "d":
                    vector = Vector.Right;
                    break;
                default:
                    vector = Vector.None;
                    break;

            }

            if (vector != Vector.None)
                Console.WriteLine("방향 : " + vector);
            else
                Console.WriteLine("방향 x");

            string input = "Up";
            vector = (Vector)Enum.Parse(typeof(Vector), input);             // enum.Parse는 object형을 반환 따라서 Vector로 형변환해야함
            Console.WriteLine(vector);



        }
        enum Vector
        {
            None,
            Up,
            Down,
            Left,
            Right,
        }
        enum Element
        {
            Fire,
            Water,
            Wind,
            Earth,
        }
        
        [Flags]
        enum Item
        {
            None = 0,
            A    = 1,
            B    = 4,
            C    = 8,
            D    = 16,
        }

      
    }
}
