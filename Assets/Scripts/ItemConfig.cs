using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemCFG", menuName = "ScriptableObjects/ItemCFG", order = 1)]
public class ItemConfig : ScriptableObject
{
    public ItemClass ItemClass;
    public List<NeedResources> NeedResources;
}