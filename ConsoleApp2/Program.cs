using System;

namespace ConsoleApp2
{
    class Program
    {

        static bool isGameOver = false;
        static void Main(string[] args)
        {

            MainUi ui = new MainUi();
            Player player = new Player(100);
            player.RegestedHpEvent(ui.UpdateHp);

            while(!isGameOver)
            {
                Console.Clear();
                ui.ShowUI();

                Console.WriteLine("1을 누르면 대미지를 받는다");
                string input  = Console.ReadLine();

                if(input =="1")
                {
                    player.TakeDamage(25);
                }
                
            }
            Console.WriteLine("그런날도 있는 법이지...");
        }
        static void OnGameOver()
        {
            isGameOver = true;
        }
    }
}
