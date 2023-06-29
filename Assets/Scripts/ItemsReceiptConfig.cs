using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsReceiptConfig", menuName = "ScriptableObjects/ItemsReceiptConfig", order = 1)]
public class ItemsReceiptConfig : ScriptableObject
{
    public List<ItemReceipt> ItemsReceipt;
}       