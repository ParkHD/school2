using System;
using System.Collections.Generic;
using System.Text;

class Inventory
{
    Item[] inven;

    readonly int maxCount; // 최대 개수.
    readonly int width;    // 넓이.
    readonly int height;   // 높이.
    int currentCount;      // 현재 개수.

    public bool IsFull
    {
        get
        {
            return currentCount >= maxCount;
        }
    }

    public Inventory()
    {   
        width = 7;
        height = 7;

        maxCount = width * height;
        currentCount = 0;

        inven = new Item[maxCount]; // 7x7칸.
    }
    
    public void AddItem(params Item[] itemArray)
    {
        int pick = 0;

        for (int index = 0; index < itemArray.Length; index++)
        {
            if (IsFull)
                return;

            Item newItem = itemArray[index];

            for (int i = pick; i < maxCount; i++)
            {
                // 빈 공간 발견.
                if(inven[i] == null)
                {
                    // 새 아이템 대입.
                    inven[i] = newItem;
                    currentCount += 1;
                    itemArray[index] = null;
                    pick = i;
                    break;
                }
            }
        }
    }
    public void RemoveItem(int index)
    {
        if (index < 0 || maxCount <= index)
            return;

        inven[index] = null;
        currentCount -= 1;
    }
    public void Sort()
    {
        Queue<int> blank = new Queue<int>();

        // 빈 공간 없이 앞으로 정렬.
        for(int i = 0; i<maxCount; i++)
        {
            Item item = inven[i];

            if(item == null)
            {
                blank.Enqueue(i);
            }
            else if((item != null) && blank.Count > 0)
            {
                int pos = blank.Dequeue();
                inven[pos] = item;
                inven[i] = null;
                blank.Enqueue(i);
            }
        }

        //inven.BubbleSort(false);
        //inven.SelectionSort(false);
        inven.InsertionSort(false);
    }
    public void ShowInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            string itemName = (inven[i] == null) ? "        " : inven[i].GetName();

            Console.Write("[{0}] ", itemName);

            // i+1값 / 7의 나머지 값.
            if (((i + 1) % 7) == 0)
            {
                Console.WriteLine();
            }
        }
    }
}