using System;
using System.Collections.Generic;
using System.Text;


public enum ITEM_TPYE
{
    Weapon_AKM,
    Weapon_Vector,
    Weapon_M24,

    Ammo_5_56,
    Ammo_7_62,
    Ammo_9_00,

    Bomb_Grenade,
    Bomb_Flare,
    Bomb_Smoke,

    Use_Bandage,
    Use_Healkit,
    Use_Mdeicalkit,
}
//public enum WEAPON_TYPE
//{
//    None,
//    AKM,
//    Vector,
//    M24,
//}
//public enum AMMO_TYPE
//{
//    None,
//    _5_56,
//    _7_62,
//    _9_00,
//}
//public enum BOMB_TYPE
//{
//    None,
//    Grenade,
//    Flare,
//    Smoke,
//}
//public enum USEITEM_TYPE
//{
//    None,
//    Bandage,
//    HealKit,
//    MedicalKit,
//}
    

interface IItem
{
    Item GetItem(int remainingSize);
    bool IsSame(Item item);
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
            new ItemInfo("0001", "AKM", "소총 AKM입니다.",            50, 1, 1, ITEM_TPYE.Weapon_AKM),
            new ItemInfo("0002", "Vector", "기관단총 Vector입니다.",  50, 1, 1, ITEM_TPYE.Weapon_Vector),
            new ItemInfo("0003", "M24", "저격소총 M24입니다.",        50, 1, 1, ITEM_TPYE.Weapon_M24),

            new ItemInfo("1001", "5.56mm", "5.56mm 탄약입니다.",      1, 200, 30, ITEM_TPYE.Ammo_5_56),
            new ItemInfo("1002", "7.62mm", "9mm 탄약입니다.",         1, 200, 30, ITEM_TPYE.Ammo_7_62),
            new ItemInfo("1003", "9mm", "9mm 탄약입니다.",            1, 200, 30, ITEM_TPYE.Ammo_9_00),

            new ItemInfo("2001", "수류탄", "M67 세열수류탄입니다.",    15, 10, 1, ITEM_TPYE.Bomb_Grenade),
            new ItemInfo("2002", "섬광탄", "M84 섬광수류탄입니다.",    12, 10, 1, ITEM_TPYE.Bomb_Flare),
            new ItemInfo("2003", "연막탄", "M18 연막탄입니다.",        10, 10, 1, ITEM_TPYE.Bomb_Smoke),

            new ItemInfo("3001", "붕대", "HP를 10 회복한다.",         2, 20, 5, ITEM_TPYE.Use_Bandage),
            new ItemInfo("3002", "구급상자", "체력을 75 회복한다.",    10, 10, 1, ITEM_TPYE.Use_Healkit),
            new ItemInfo("3003", "의료용 키트", "HP를 모두 회복한다.", 20, 5, 1, ITEM_TPYE.Use_Mdeicalkit),
        };

    public Database()
    {
        instance = this;
    }

    public Item GetItem(ITEM_TPYE itemType)
    {
        Item item = null;

        for (int i = 0; i < itemData.Length; i++)
        {
            if (itemData[i].itemType == itemType)
            {
                item = new Item(itemData[i]);
                break;
            }
        }

        return item;
    }
    public Item GetItemRandom()
    {
        Random random = new Random();
        int ran = random.Next(0, itemData.Length);

        // random.Next(0, 5) 0,1,2,3,4

        return new Item(itemData[ran]);
    }

    public string GetItemCode(ITEM_TPYE iType, ITEM_TPYE wType)
    {
        int code = ((int)iType * 1000) + (int)wType;
        return code.ToString("0000");
    }

}

