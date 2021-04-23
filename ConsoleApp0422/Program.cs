using System;
using System.Threading;

namespace Project08
{
    /* 리스트 자료구조
    * [배열 = 리스트 > 스택 > 큐]
    * 1. Array : 배열 (o)
    * 2. Array List : 배열 형 리스트.
    * 3. Linked List : 연결 리스트. (o)
    * 4. Double Linked List : 이중 연결 리스트.
    * 5. Circle Linked List : 원형 연결 리스트.
    * 6. Double Circle Linked List : 원형 이중 연결 리스트.
    * 7. Stack : 스택 (o)            
    * 8. Queue : 큐   (o)
    * 9. Deque (Double Ended Queue) : 덱
    */

    // 길찾기...

    class Program
    {
        static void Recursion(int index)
        {
            if (index <= 0)
            {
                return;
            }

            Console.WriteLine("재귀호출!! ({0})", index);
            index--;

            Thread.Sleep(1000); // 밀리초 : 1000mi는 1sec.
            Recursion(index);
            return;
        }
        static void ShowMultiTable(int digit, int index = 1)
        {
            Console.WriteLine("{0}x{1}={2}", digit, index, digit * index);

            // index의 수가 1~9사이일 때.
            if (0 < index && index < 9)
                ShowMultiTable(digit, index + 1);

            Console.WriteLine("End : {0}", index);
        }



        static void Main(string[] args)
        {
            // 재귀호출 : 자신이 자신을 다시 호출하는 것.
            // 2단
            //ShowMultiTable(2);

            // string 배열 형태의 스테이지 생성.
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
                "# ###    E",
                "#   ######",
                "##########"
            };
            string[] stage2 = new string[]
            {
                "##S#####",
                "## #####",
                "## #####",
                "##     #",
                "## #####",
                "##E#####"
            };

            // 미로 관리자 객체 생성.
            MazeManager manager = new MazeManager();

            // 스테이지 데이터를 인자로 전달.
            manager.InitBackground(stage1);
            manager.ShowBackground();
            manager.SearchMaze();
            Console.ReadLine();

        }
    }
}
