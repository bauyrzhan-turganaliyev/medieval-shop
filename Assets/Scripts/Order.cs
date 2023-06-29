using System;

[Serializable]
public class Order
{
    public ItemClass Item;
    public Resources Material;
    public int Count;
    public float Price;
}