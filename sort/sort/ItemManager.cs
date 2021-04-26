using System;
using System.Collections.Generic;
using System.Text;


enum ITEMTYPE
{
    Equipment,
    Acces,
    Use,
    Stuff,
}

public interface IName
{
    string GetName();
}
public interface ISort
{
    int GetSort();
}

class item : IName, ISort
{
    int itemCode;
    string name;
    ITEMTYPE type;
    int index;
    public item(string name, ITEMTYPE type, int index)
    {
        this.name = name;
        this.type = type;
        this.index = index;
    }
    public string GetName()
    {
        return name;
    }
    public int GetSort()
    {
        return ((int)type*100) * index;
    }
    public void ShowInfo()
    {
        Console.WriteLine(GetName());
    }
}
class ItemManager
{
    
}
