using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public ItemClass ItemClass;
    public List<NeedResources> Resources;
    public ItemQuality ItemQuality;

    public Item(ItemClass itemClass, List<NeedResources> needResources, ItemQuality itemQuality)
    {
        ItemClass = itemClass;
        Resources = needResources;
        ItemQuality = itemQuality;
    }
}