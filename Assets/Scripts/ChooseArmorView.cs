using System;
using UnityEngine;
using UnityEngine.UI;

public class ChooseArmorView : ChooseView
{
    [SerializeField] private Button _helmetButton;
    [SerializeField] private Button _chestButton;
    [SerializeField] private Button _bracersButton;
    [SerializeField] private Button _leggingsButton;
    [SerializeField] private Button _shieldButton;
    
    public Action<ItemClass> OnItemClicked;
    
    public void Init()
    {
        _helmetButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Helmet)));
        _chestButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Chest)));
        _bracersButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Bracers)));
        _leggingsButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Leggings)));
        _shieldButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Shield)));
    }
}