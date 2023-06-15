using System;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMaterialView : MonoBehaviour
{
    [SerializeField] private ItemMaterial _itemMaterialPrefab;
    [SerializeField] private Transform _parent;

    public Action<List<NeedResources>> OnNeedResources; 
    public void CreateMaterials(ItemConfig item)
    {
        print(item.ItemClass);
        var resource = Instantiate(_itemMaterialPrefab, _parent);
        resource.Init();
        resource.OnClick += () => OnNeedResources?.Invoke(item.NeedResources);

        foreach (var nr in item.NeedResources)
        {
            resource.AddResource(nr);
        }
    }

    public void Clear()
    {
        for (int i = 0; i < _parent.childCount; i++)
        {
            Destroy(_parent.GetChild(i).gameObject);
        }
    }
}