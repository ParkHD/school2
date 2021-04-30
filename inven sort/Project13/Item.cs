using System;
using System.Collections.Generic;
using System.Text;

public enum JOB
{
    Warrior,
    Wizard,
}
public enum EQUIPMENT
{
    Weapon, // 무기.
    Head,   // 투구.
    Armor,  // 방어구.
}
public enum GRADE
{
    Rare,   // 레어.
    Hero,   // 영웅.
    Legend, // 전설.
}


public class Item : IName, ISort
{
    protected string name;

    public string GetName()
    {
        string[] text = name.Split(' ');

        return string.Format("{0}{1}({2:00})", text[0][0], text[1][0], GetSort());
    }
    public virtual int GetSort()
    {
        return -1;
    }
}
public class Equipment : Item
{
    int index;
    JOB job;
    EQUIPMENT equip;
    GRADE grade;
    int attack;
    int defence;
    int hp;

    public Equipment(string name, int index, JOB job, EQUIPMENT equip, GRADE grade, int attack, int defence, int hp)
    {
        this.name = name;
        this.index = index;
        this.job = job;
        this.equip = equip;
        this.grade = grade;
        this.attack = attack;
        this.defence = defence;
        this.hp = hp;
    }

    public void ShowInfo()
    {
        Console.WriteLine("{0,-3}{1,-10}{2,-8}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}",
            index, name, job, equip, grade, attack, defence, hp);
    }
    public override int GetSort()
    {
        return index;
    }
}