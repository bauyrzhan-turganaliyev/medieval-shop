using System;
using UnityEngine;
using UnityEngine.UI;

public class ChooseExpendablesView : ChooseView
{
    [SerializeField] private Button _arrowButton;
    [SerializeField] private Button _healPotionButton;
    [SerializeField] private Button _poisonPotionButton;
    [SerializeField] private Button _agilityPotionButton;
    [SerializeField] private Button _strengthPotionButton;
    [SerializeField] private Button _staminaPotionButton;

    public Action<ItemClass> OnItemClicked;
    
    public void Init()
    {
        _arrowButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.Arrow)));
        _healPotionButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.HealPotion)));
        _poisonPotionButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.PoisonPotion)));
        _agilityPotionButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.AgilityPotion)));
        _strengthPotionButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.StrengthPotion)));
        _staminaPotionButton.onClick.AddListener((() => OnItemClicked?.Invoke(ItemClass.StaminaPotion)));
    }
}

