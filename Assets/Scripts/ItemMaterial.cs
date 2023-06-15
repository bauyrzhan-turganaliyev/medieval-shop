using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemMaterial : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ItemResource _itemResourcePrefab;
    [SerializeField] private Transform _parent;

    public Action OnClick;

    public void Init()
    {
        _button.onClick.AddListener((() => OnClick?.Invoke()));
    }
    public void AddResource(NeedResources needResources)
    {
        var resource = Instantiate(_itemResourcePrefab, _parent);
        resource.SetCount(needResources.Count);
    }
}