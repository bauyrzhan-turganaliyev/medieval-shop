using System;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWeaponView : ChooseView
{
    [SerializeField] private Button _swordButton;
    [SerializeField] private Button _axeButton;
    [SerializeField] private Button _spearButton;
    [SerializeField] private Button _bowButton;

    public Action<ItemClass> OnItemClicked;
    
    public void Init()
    {
        _swordButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Sword)));
        _axeButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Axe)));
        _spearButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Spear)));
        _bowButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Bow)));
    }
}