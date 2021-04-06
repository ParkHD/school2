using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp6
{
    class Player
    {
        static Player instance;
        public static Player Instance
        {
            get
            {
                return instance;
            }
        }


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
        public Player(string name, int maxHp)
        {
            this.name = name;
            this.maxHp = hp;
            hp = maxHp;
            instance = this;

            inventory = new Inventory(200);
        }
        public void ShowInventory()
        {
            inventory.Open();
        }
        public void GetItem(Item item)
        {
            inventory.GetItem(item);
        }
    }
}
