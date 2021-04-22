using System;
using System.Threading;
namespace ConsoleApp0422
{
    class Program
    {
        static void recursion(int index)
        {
            if (index < 0)
                return;
            Console.WriteLine("재귀호출!! ({0})", index--);

            Thread.Sleep(1000);
            recursion(index);
        }
        static void ShowMultiTable(int digit, int index =1)
        {
            Console.WriteLine("{0}x{1} = {2}", digit, index, digit * index);
            if(index <9)
                ShowMultiTable(digit, ++index);

        }
        static void Main(string[] args)
        {
            string[] stage1 = new string[]
             {
                    "######S###",
                    "###### ###",
                    "###### ###",
                    "###    ###",
                    "### ######",
                    "### ######",
                    "#        #",
                    "# ### ####",
                    "#   #    E",
                    "##########"
             };
            string[] stage2 = new string[]
             {
                    "######S###",
                    "###### ###",
                    "###### ###",
                    "###    ###",
                    "###E######",
             };
            MazeManager mazeManger = new MazeManager();
            mazeManger.InitBackGround(stage1);
            mazeManger.ShowBackGround();
            Console.WriteLine(mazeManger.startPos.x);
            Console.WriteLine(mazeManger.startPos.y);
        }

    }
}
