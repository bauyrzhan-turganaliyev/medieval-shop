using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsCFG", menuName = "ScriptableObjects/ItemsCFG", order = 1)]
public class ItemsConfig : ScriptableObject
{
    public List<ItemConfig> Items;
}