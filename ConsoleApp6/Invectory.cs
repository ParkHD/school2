using System;
using System.Collections.Generic;
using System.Text;
using Tool;
namespace ConsoleApp6
{
    class Inventory
    {
        List<Item> itemList;
        int maxWeight;
        int curWeight;

        public int RemainingWeight
        {
            get
            {
                return maxWeight - curWeight;
            }
        }
        public Inventory(int size)
        {
            maxWeight = size;
            curWeight = 0;
            itemList = new List<Item>();
        }
        private void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("[인벤토리]");
            Console.WriteLine("[{0}/{1}]", curWeight, maxWeight);
            Console.WriteLine("---------------------------");
            if(itemList.Count <= 0)
            {
                Console.WriteLine("아이템이 없습니다...");
            }
            else
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    Console.WriteLine("{0}.{1}", i + 1, itemList[i].Name);
                }
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("1.아이템 사용 2.아이템 제거");
            Console.WriteLine("---------------------------");

        }
        public void Open()
        {
            bool isOpen = true;
            while(isOpen)
            {
                ShowInventory();
                Console.Write("행동할 번호 [0입력시 닫기] : ");
                int index = MyTool.OnGetNum(-1);
                switch(index)
                {
                    case -1:
                        isOpen = false;
                        break;
                    case 0:
                        UseItem();
                        break;
                    case 1:
                        DropItem();
                        break;
                }
            }
        }
        private void UseItem()
        {
            Console.Write("사용할 아이템 번호 입력 : ");
            int index = MyTool.OnGetNum(-1);
            itemList[index].UseItem();
        }
        private void DropItem()
        {
            ShowInventory();
            Console.Write("제거할 아이템의 번호 : ");
            int index = MyTool.OnGetNum(-1);
            if (index >= itemList.Count || index < 0)
                return;
            
            Item item = itemList[index];
            itemList.RemoveAt(index);
        }
    }
}
