using System;
using Tool;
using AreaData;
using World;
using System.Collections.Generic;

namespace Project2
{
    
    public class Program
    {
        public static Player player;
        static void Main(string[] args)
        {
            player = new Player("유저1",100);
            Database database = new Database();

            WorldMap worldMap = new WorldMap();

            bool isOpen = true;
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
                    case ConsoleKey.M:
                        worldMap.ShowArea();
                        break;
                    case ConsoleKey.C:
                        //Item item = Database.Instance.GetItem("1001");
                        break;
                    case ConsoleKey.A:
                        //Item item = Database.Instance.GetItem("1001");
                        break;
                }
            }
        }

        static void ShowMain()
        {
            Console.Clear();
            Console.WriteLine("유저 이름 : {0}", player.Name);
            Console.WriteLine("체력 : {0}/{1}", player.Hp, player.MaxHp);
            Console.WriteLine("무기 : 없음 [0/0]");
            Console.WriteLine("I:인벤토리, R:재장전, B:사격모드, M:맵, ESC:종료");
        }
       
    }
}
