using System;
using System.Collections.Generic;
using System.Text;


    // 1. 종류는 : 총기, 폭탄, 탄약, 소비
    // 2. 총기는 인벤토리로 오지 않는다.
    // 3. 폭탄,탄약,소비 아이템은 n개를 뭉칠 수 있다.
    // 4. 모든 탄약은 한번에 최대 200발 까지.

    class Item : IItem
    {
        private ItemInfo itemInfo;

        int count; // 현재 개수.

        public int Count
        {
            get
            {
                return count;
            }
        }

        public string ItemCode
        {
            get
            {
                return itemInfo.itemCode;
            }
        }
        public string Name
        {
            get
            {
                if(MaxCount <= 1)
                    return string.Format(itemInfo.name);
                else
                    return string.Format("{0}[{1}]", itemInfo.name, count);
            }
        }
        public string Conetnt
        {
            get
            {
                return itemInfo.content;
            }
        }
        public int Weight
        {
            get
            {
                return itemInfo.weight;
            }
        }
        public int MaxCount
        {
            get
            {
                return itemInfo.maxCount;
            }
        }

        public void CombineItem(Item item)
        {
            // 다른 아이템을 합치려고 하면 리턴.
            if (itemInfo.itemCode != item.itemInfo.itemCode)
                return;

            int totalCount = Count + item.Count;

            if(totalCount <= MaxCount)
            {
                count = totalCount;
                item.count = 0;
            }
            else
            {
                count = MaxCount;
                item.count = totalCount - MaxCount;
            }
        }

        public Item(ItemInfo itemInfo)
        {
            // Item내부 생성자에서 readonly 상수를 초기화하고 있다.
            this.itemInfo = itemInfo;

            count = itemInfo.initCount;
        }

        Item IItem.GetItem(int remainingSize)
        {
            // 허용 공간이 아이템 1개의 무게보다 적다면.
            if (remainingSize <= Weight)
                return null;

            // 나와 동일한 아이템 클래스 생성.
            Item giveItem = new Item(itemInfo);

            int remaingCount = remainingSize / Weight; // 최대 허용 개수.

            // 현재 아이템이 인벤토리에 다 들어간다면.
            if(count <= remaingCount)
            {                
                giveItem.count = count;
                count = 0;
            }
            else
            {
                giveItem.count = remaingCount;
                count = count - remaingCount;
            }

            return giveItem;
        }

        public virtual void UseItem()
        {
            // 아이템 사용.
        }
    }






    class Weapon : Item
    {
        public Weapon(ItemInfo itemInfo) : base(itemInfo)
        {
            
        }
    }
    class Ammo : Item
    {
        public Ammo(ItemInfo itemInfo) : base(itemInfo)
        {

        }
    }
    class Bomb : Item
    {
        public Bomb(ItemInfo itemInfo) : base(itemInfo)
        {

        }
    }
    class UseItem : Item
    {
        public UseItem(ItemInfo itemInfo) : base(itemInfo)
        {

        }
    }

