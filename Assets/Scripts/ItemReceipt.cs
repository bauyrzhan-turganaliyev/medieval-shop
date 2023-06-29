using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemReceipt", menuName = "ScriptableObjects/ItemReceipt", order = 1)]
public class ItemReceipt : ScriptableObject
{
    public ItemClass ItemClass;
    public List<Resources> CanMadeFrom;
}