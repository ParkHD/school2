using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class Inventory
    {
        Item[] itemArray;
        const string EMPTY = "";
        public Inventory(int maxSize)
        {
            itemArray = new Item[maxSize];
            for(int i =0; i<itemArray.Length;i++)
            {
                itemArray[i] = null;
            }
        }
        bool IsFull
        {
            get 
            {
                return ItemCount() == itemArray.Length ? true : false;
            }
        }

        int ItemCount()
        {
            int count = 0;
            for (int i = 0; i < itemArray.Length; i++)
            {
                if (itemArray[i] != null)
                {
                    count++;
                }
            }
            return count;
        }
        public bool InputItem(Item item)
        {
            if (IsFull)
            {
                Console.WriteLine("아이탬창이 꽉찼다.");
                return false;
            }

            for(int i =0;i<itemArray.Length;i++)
            {
                if(itemArray[i] == null)
                {
                    itemArray[i] = item;
                    return true;
                }
            }
            return false;
        }

        public Item DropItem(int index)
        {
            if(itemArray[index] != null)
            {
                Item item = itemArray[index];
                itemArray[index] = null;
                return item;
            }
            return null;
        }
        public void ShowInvectory()
        {
            Console.Clear();
            for(int i=0;i<itemArray.Length;i++)
            {
                Console.Write("{0}.{1,-7} ", i + 1, itemArray[i]);
            }
            Console.WriteLine();
        }
        public void ShowAction()
        {
            //ShowInvectory();
            //Console.Write("1.아이템 넣기 2.아이템 빼기 3.인벤토리보기");
            //int input = int.Parse(Console.ReadLine());

            //switch (input)
            //{
            //    case 1:
            //        Console.Write("아이템 : ");
            //        Item item = Console.ReadLine();
            //        InputItem(item);
            //        break;
            //    case 2:
            //        Console.Write("제거할 번호 입력 : ");
            //        input = int.Parse(Console.ReadLine());
            //        DropItem(input - 1);
            //        break;
            //    case 3:
            //        ShowInvectory();
            //        break;
            //}
        }
    }
}
