using System;
using System.Collections.Generic;
using System.Text;
using AreaData;
using Project2;
using Tool;
namespace World
{
    class WorldMap
    {
        List<Area> areaList;
        public WorldMap()
        {
            areaList = new List<Area>();
            Area pochinki = new Area("Pochiniki");
            pochinki.AddHouse(
                new Area.House("3층집", 10, ITEM_TPYE.Weapon_AKM, ITEM_TPYE.Weapon_M24, ITEM_TPYE.Weapon_Vector, ITEM_TPYE.Ammo_5_56,
                ITEM_TPYE.Ammo_7_62, ITEM_TPYE.Bomb_Flare, ITEM_TPYE.Use_Bandage));
            pochinki.AddHouse(new Area.House("차고", 5, ITEM_TPYE.Ammo_7_62, ITEM_TPYE.Ammo_5_56, ITEM_TPYE.Use_Bandage));

            Area rozhok = new Area("Rozhok");
            rozhok.AddHouse(new Area.House("2층집", 8, ITEM_TPYE.Weapon_M24, ITEM_TPYE.Ammo_7_62, ITEM_TPYE.Bomb_Grenade, ITEM_TPYE.Use_Mdeicalkit));
            rozhok.AddHouse(new Area.House("차고", 5, ITEM_TPYE.Ammo_7_62, ITEM_TPYE.Ammo_5_56, ITEM_TPYE.Use_Healkit));

            Area yasnaya = new Area("Yasnaya");
            yasnaya.AddHouse(new Area.House("1층집", 5, ITEM_TPYE.Weapon_Vector, ITEM_TPYE.Ammo_9_00, ITEM_TPYE.Bomb_Smoke, ITEM_TPYE.Use_Healkit));
            yasnaya.AddHouse(new Area.House("차고", 3, ITEM_TPYE.Ammo_7_62, ITEM_TPYE.Ammo_5_56, ITEM_TPYE.Use_Healkit));

            areaList.Add(pochinki);
            areaList.Add(rozhok);
            areaList.Add(yasnaya);
        }

        public void ShowArea()
        {
            Console.Clear();
            Console.WriteLine("월드 맵");
            Console.WriteLine("-------------------");
            for (int i =0;i<areaList.Count;i++)
            {
                Console.WriteLine("{0}.{1}",i+1,areaList[i].Name);
            }

            Console.WriteLine("-------------------");
            Console.Write("입장할 지역을 선택하세요 : ");
            int input = MyTool.OnGetNum();
            switch(input)
            {
                case 1:
                    areaList[0].ShowHouse();
                    break;
                case 2:
                    areaList[1].ShowHouse();
                    break;
                case 3:
                    areaList[2].ShowHouse();
                    break;
                default:
                    break;
            }
        }
       
    }
}
