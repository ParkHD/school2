using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    enum ITEM_TYPE
    {
        Weapon,
        Bomb,
        Ammo,
        UseItem,
    }
    class Item
    {
        readonly string name;
        readonly string content;
        readonly int weight;
        readonly int maxCount;
        protected readonly int itemCode;
        int count;
        public int Count
        {
            get
            {
                return count;
            }
        }
        public int AddItem(Item item)
        {
            if (itemCode != item.itemCode)
                return item.Count;
            int allCount = count + item.count;
            if(allCount > maxCount)
            {
                int addCount = maxCount- count;
                count = maxCount;

                item.count -= addCount;
                return item.count;
            }
            else
            {
                count += item.count;
                item.count = 0;
                return 0;
            }
        }
        protected readonly ITEM_TYPE itemType;
        public Item(string name, string content, int weight, int maxCount, ITEM_TYPE itemType)
        {
            this.name = name;
            this.content = content;
            this.weight = weight;
            this.maxCount = maxCount;
            this.itemType = itemType;

            count = 1;
        }
    }
    class Weapon : Item
    {
        public Weapon(string name, string content)
            : base(name, content, 0, 1, ITEM_TYPE.Weapon)
        {

        }
    }
    class Bomb : Item
    {
        public Bomb(string name, string content, int weight, int maxCount)
            : base(name, content, weight, maxCount, ITEM_TYPE.Bomb)
        {

        }
    }
    class Ammo : Item
    {
        public Ammo(string name, string content, int weight, int maxCount)
            : base(name, content, weight, 200, ITEM_TYPE.Ammo)
        {

        }
    }
    class UseItem : Item
    {
        public UseItem(string name, string content, int weight, int maxCount)
            : base(name, content, weight, maxCount, ITEM_TYPE.UseItem)
        {

        }
    }
}
