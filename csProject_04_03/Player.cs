using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    public class Player
    {
        Inventory inventory;
        string name;
        int hp;
        int maxHp;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Hp
        {
            get
            {
                return hp;
            }
        }
        public int MaxHp
        {
            get
            {
                return maxHp;
            }
        }
        public Player(string name ,int maxHp)
        {
            this.name = name;
            this.maxHp = maxHp;
            hp = maxHp;

            inventory = new Inventory(1000);
        }
        public void ShowInventory()
        {
            inventory.Open();
        }
        public void GetItem(Item item)
        {
            inventory.InputItem(item);
        }
        public void RemoveItem(int index)
        {
            inventory.DropItem(index);
        }
       
    }
}
