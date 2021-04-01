using System;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static bool isFail = false;
 
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Buy();

            //Console.WriteLine("Hello World!");
            //Player[] players = new Player[4];
            //players[0] = new Player("A", 100);
            //players[1] = new Player("B", 80);
            //players[2] = new Player("C", 90);
            //players[3] = new Player("D", 110);

            //Party party = new Party(players);
            //party.onKillAll += () =>
            //{
            //    Console.WriteLine("전부 죽여라!");
            //    isFail = true;
            //};
            //while(!isFail)
            //{
            //    Random random = new Random();
            //    int ran = random.Next(0, players.Length);

            //    players[ran].TakeDamager(40);
            //    Thread.Sleep(500);
            //}
        }
    }
}
