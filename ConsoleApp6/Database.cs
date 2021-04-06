using System;
using System.Collections.Generic;
using System.Text;


public enum ITEM_TPYE
{
    Weapon, // 무기
    Ammo,   // 탄약
    Bomb,   // 폭탄
    UseItem,// 사용 아이템
}

interface IItem
{
    Item GetItem(int remainingSize);
}

public struct ItemInfo
{
    public string itemCode;    // 아이템 코드.

    public string name;        // 이름.
    public string content;     // 설명.
    public int weight;         // 무게.
    public int maxCount;       // 최대 
    public int initCount;      // 최초 개수.
    public ITEM_TPYE itemType; // 아이템 타입.

    public ItemInfo(string itemCode, string name, string content, int weight, int maxCount, int initCount, ITEM_TPYE itemType)
    {
        this.itemCode = itemCode;
        this.name = name;
        this.content = content;
        this.weight = weight;
        this.maxCount = maxCount;
        this.initCount = initCount;
        this.itemType = itemType;
    }
}

class Database
{
    static Database instance;
    public static Database Instance
    {
        get
        {
            return instance;
        }
    }

    ItemInfo[] itemData = new ItemInfo[] {
        new ItemInfo("0001", "AKM", "소총 AKM입니다.",            50, 1, 1, ITEM_TPYE.Weapon),
        new ItemInfo("0002", "Vector", "기관단총 Vector입니다.",  50, 1, 1, ITEM_TPYE.Weapon),
        new ItemInfo("0003", "M24", "저격소총 M24입니다.",        50, 1, 1, ITEM_TPYE.Weapon),

        new ItemInfo("1001", "5.56mm", "5.56mm 탄약입니다.",      1, 200, 30, ITEM_TPYE.Ammo),
        new ItemInfo("1002", "7.62mm", "9mm 탄약입니다.",         1, 200, 30, ITEM_TPYE.Ammo),
        new ItemInfo("1003", "9mm", "9mm 탄약입니다.",            1, 200, 30, ITEM_TPYE.Ammo),

        new ItemInfo("2001", "수류탄", "M67 세열수류탄입니다.",    15, 10, 1, ITEM_TPYE.Bomb),
        new ItemInfo("2002", "섬광탄", "M84 섬광수류탄입니다.",    12, 10, 1, ITEM_TPYE.Bomb),
        new ItemInfo("2003", "연막탄", "M18 연막탄입니다.",        10, 10, 1, ITEM_TPYE.Bomb),

        new ItemInfo("3001", "붕대", "HP를 10 회복한다.",         2, 20, 5, ITEM_TPYE.UseItem),
        new ItemInfo("3002", "구급상자", "체력을 75 회복한다.",    10, 10, 1, ITEM_TPYE.UseItem),
        new ItemInfo("3003", "의료용 키트", "HP를 모두 회복한다.", 20, 5, 1, ITEM_TPYE.UseItem),
    };

    public Database()
    {
        instance = this;
    }

    public Item GetItem(string itemCode)
    {
        Item item = null;

        for(int i = 0; i<itemData.Length; i++)
        {
            if(itemData[i].itemCode == itemCode)
            {
                item = new Item(itemData[i]);
                break;
            }
        }

        return item;
    }
    public Item GetRandomItem(int itemIndex)
    {
        Item item = null;
        item = new Item(itemData[itemIndex]);
        return item;
    }

}

