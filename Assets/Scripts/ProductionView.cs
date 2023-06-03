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
            case EResource.RawWood:
                _resourceName.text = "Raw Wood";
                break;
            case EResource.RawStone:
                _resourceName.text = "Raw Stone";
                break;
            case EResource.RawIron:
                _resourceName.text = "Raw Iron";
                break;
            case EResource.RawLeather:
                _resourceName.text = "Raw Leather";
                break;
            case EResource.RawSilver:
                _resourceName.text = "Raw Silver";
                break;
            case EResource.RawGold:
                _resourceName.text = "Raw Gold";
                break;
            case EResource.RawAlchemicalIngredient:
                _resourceName.text = "Raw Alchemy Ingredient";
                break;
            case EResource.RawMagicCrystal:
                _resourceName.text = "Raw Magic Crystal";
                break;
            case EResource.RawTitan:
                _resourceName.text = "Raw Titan";
                break;
            case EResource.RawLunocit:
                _resourceName.text = "Raw Lunocit";
                break;
        }
    }
}