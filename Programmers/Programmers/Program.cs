using System;
using System.Linq;
namespace Programmers
{
 
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = { "sun", "bed", "car" };
            Sort sort = new Sort();
            for(int i = 0;i<strings.Length;i++)
            {
                Console.WriteLine(sort.solution1(strings, 1)[i]);
            }

        }
    }
}
