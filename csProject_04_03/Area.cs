using System;
using System.Collections.Generic;
using System.Text;
using Project2;
namespace AreaData
{
    public class Area
    {
        public class House
        {
            string name;
            public string Name
            {
                get
                {
                    return name;
                }
            }
            List<Item> itemList;
            public House(string name, int maxItemCount, params ITEM_TPYE[] itemTypes)
            {
                this.name = name;
                itemList = new List<Item>();
                Random random = new Random();
                int itemCount = random.Next(1, maxItemCount + 1);
                for(int i =0;i< itemCount; i++)
                {
                    ITEM_TPYE type = itemTypes[random.Next(0, itemTypes.Length)];
                    itemList.Add(Database.Instance.GetItem(type));
                }
            }
            public void ShowItem()
            {
                Console.Clear();
                Console.WriteLine("{0}", name);
                Console.WriteLine("-------------------");
                for (int i = 0; i < itemList.Count; i++)
                {
                    Console.WriteLine("{0}.{1}", i + 1, itemList[i].Name);
                }

                Console.WriteLine("-------------------");
                Console.Write("아이탬 선택하세요 : ");
                int input = int.Parse(Console.ReadLine());

                Program.player.GetItem(itemList[input]);
                
                
            }
        }
        
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        List<House> houseList;
        public Area(string name)
        {
            this.name = name;
            houseList = new List<House>();
        }
        public void AddHouse(House house)
        {
            houseList.Add(house);
        }
        public void ShowHouse( )
        {
            Console.Clear();
            Console.WriteLine("{0}",name);
            Console.WriteLine("-------------------");
            for (int i =0; i<houseList.Count;i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, houseList[i].Name);
            }

            Console.WriteLine("-------------------");
            Console.Write("입장할 집을 선택하세요 : ");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    houseList[0].ShowItem();
                    break;
                case 2:
                    houseList[1].ShowItem();
                    break;
                case 3:
                    houseList[2].ShowItem();
                    break;
            }
        }
    }
}
