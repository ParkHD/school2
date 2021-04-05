using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory invectory = new Inventory(5);
            
            while(true)
            {
                invectory.ShowAction();
            }
        }
    }
}
