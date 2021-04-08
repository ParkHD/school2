using System;
using System.Collections.Generic;
using System.Text;
using Tool;

namespace Project2
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
            Console.WriteLine("남은 무게 : {0}/{1}",curWeight,maxWeight);
            Console.WriteLine("------------------------------------------------");
            if (itemList.Count <= 0)
                Console.WriteLine("없음");
            else
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    Console.WriteLine("{0}.{1}", i + 1, itemList[i].Name);
                }
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("1.아이템 사용, 2.아이템 제거");
            Console.WriteLine("------------------------------------------------");
        }

        // 열기, 동작.
        public void Open()
        {
            bool isOpen = true;
            while(isOpen)
            {
                ShowInventory();
                Console.Write("[0입력시 닫기] 행동할 번호 : ");

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
                        RemoveItem();
                        break;

                }

            }

        }
        private void UseItem()
        {

        }
        private void RemoveItem()
        {
            ShowInventory();
            Console.Write("제거할 아이템의 번호 : ");

            int index = MyTool.OnGetNum(-1);
            DropItem(index);
        }

        private void UpdateInventory()
        {
            // 무게 갱신
            curWeight = 0;
            for (int i = 0; i < itemList.Count;)
            {
                // 값이 유효한지 체크.
                Item item = itemList[i];

                if(item == null || item.Count <= 0)
                {
                    // 유효하지 않음.
                    itemList.RemoveAt(i);
                    continue;
                }

                // 아이템이 유효하다.
                curWeight += item.TotalWeight;

                i++;
            }
        }

        private Item GetItemInv(IItem item)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                Item invItem = itemList[i];

                // 동일 아이템이면서, 최대 개수가 아니라면.
                if (item.IsSame(invItem) && !invItem.IsFull)
                {
                    return invItem;
                }
            }

            return null;
        }

        // 획득.
        public void InputItem(IItem item)
        {
            // 기존의 인벤토리 아이템.
            Item itemInv = GetItemInv(item); // 값 일수도 null일수도 있다.

            // 추가하려는 아이템.
            Item addItem = item.GetItem(RemainingWeight);

            // 기존의 아이템이 없다면.
            if(itemInv == null)
            {
                itemList.Add(addItem);
            }
            // 기존의 아이템이 있다면.
            else
            {
                itemInv.AddItem(addItem); // 기존의 아이템에 병합.

                if(addItem.Count > 0)
                {
                    // 여전히 개수가 남아있다면 add.
                    itemList.Add(addItem);
                }

            }

            // 1. 먼저 내 인벤토리에서 같은 아이템이 있는지 찾는다.
            // 2. 같은 아이템이 없다면 add한다.
            // 3. 같은 아이템이 있다면
            // 4. 해당 아이템이 최대 개수인지 판단.
            // 5. 최대 개수라면 add, 아니라면 합친다.
            // 6. add후에 가져온 item의 크기가 0이 아니라면 add.

            UpdateInventory();   // 인벤토리 상태 갱신.
        }
        public void DropItem(int index)
        {
            // 해당 index가 유효한지 확인.
            if (!itemList.IsValid(index))
                return;

            itemList.RemoveAt(index);
            UpdateInventory();          // 인벤토리 상태 갱신.
        }
    }
}
