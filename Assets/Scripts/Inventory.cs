using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
    public List<Item> Items;

    public Inventory()
    {
        Items = new List<Item>();
    }
}