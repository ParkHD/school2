using System;

using Tool;
namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            Player player = new Player("Marine", 100);

            while(isOpen)
            {
                ShowMain();
                ConsoleKey key = MyTool.OnGetKey();
                switch(key)
                {
                    case ConsoleKey.Escape:
                        isOpen = false;
                        break;
                    case ConsoleKey.I:
                        player.ShowInventory();
                        break;
                }
                
            }    

        }
        static void ShowMain()
        {
            Console.Clear();
            Console.WriteLine("닉네임 : {0}", Player.Instance.Name);
            Console.WriteLine("체력   : {0}", Player.Instance.Hp);
            Console.WriteLine("무기   : 없음 [0/0]");
            Console.WriteLine("I:인벤토리 R:재장전 B:사격모드 M:맵");


        }
    }
}
