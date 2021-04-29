using System;
using System.Threading;

namespace Project11
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipment[] equip = FileManager.GetEqeuipmentData("WeaponData");

            // 인벤토리 선언.
            Inventory inventory = new Inventory();
            Random random = new Random();

            while(true)
            {
                Console.Clear();
                inventory.ShowInventory();

                Console.WriteLine("1.추가, 2.제거, 3.정렬");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        int ranNum = random.Next(equip.Length);
                        inventory.AddItem(equip[ranNum]);
                        break;

                    case "2":
                        Console.Write("삭제 번호 선택 : ");
                        input = Console.ReadLine();
                        inventory.RemoveItem(int.Parse(input));
                        break;

                    case "3":
                        inventory.Sort();
                        break;
                }
                

                Thread.Sleep(100);
            }
        }
    }
}
