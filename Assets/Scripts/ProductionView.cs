using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionView : MonoBehaviour
{
    [SerializeField] private Button _productionButton;
    [SerializeField] private TMP_Text _resourceName;
    [SerializeField] private Slider _hpSlider;

    public Action OnProductionClicked;

    public void Init()
    {
        _productionButton.onClick.AddListener((() => OnProductionClicked?.Invoke()));
    }

    public void SetHP(float current, float max)
    {
        _hpSlider.maxValue = max;
        _hpSlider.value = current;
    }

    public void SetupResourceName(EResource resource)
    {
        switch (resource)
        {
            case EResource.Wood:
                _resourceName.text = "Wood";
                break;
            case EResource.Stone:
                _resourceName.text = "Stone";
                break;
            case EResource.Iron:
                _resourceName.text = "Iron";
                break;
            case EResource.Leather:
                _resourceName.text = "Leather";
                break;
            case EResource.Silver:
                _resourceName.text = "Silver";
                break;
            case EResource.Gold:
                _resourceName.text = "Gold";
                break;
            case EResource.AlchemicalIngredient:
                _resourceName.text = "Alchemy Ingredient";
                break;
            case EResource.MagicCrystal:
                _resourceName.text = "Magic Crystal";
                break;
            case EResource.Titan:
                _resourceName.text = "Titan";
                break;
            case EResource.Lunocit:
                _resourceName.text = "Lunocit";
                break;
        }
    }
}