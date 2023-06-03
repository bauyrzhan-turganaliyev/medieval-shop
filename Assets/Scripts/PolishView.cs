using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PolishView : MonoBehaviour
{
    [SerializeField] private Button _polishButton;
    [SerializeField] private TMP_Text _resourceName;
    [SerializeField] private Slider _hpSlider;

    public Action OnPolishClicked;

    public void Init()
    {
        _polishButton.onClick.AddListener((() => OnPolishClicked?.Invoke()));
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
            case EResource.PolishedWood:
                _resourceName.text = "Polished Wood";
                break;
            case EResource.PolishedStone:
                _resourceName.text = "Polished Stone";
                break;
            case EResource.PolishedIron:
                _resourceName.text = "Polished Iron";
                break;
            case EResource.PolishedLeather:
                _resourceName.text = "Polished Leather";
                break;
            case EResource.PolishedSilver:
                _resourceName.text = "Polished Silver";
                break;
            case EResource.PolishedGold:
                _resourceName.text = "Polished Gold";
                break;
            case EResource.PolishedAlchemicalIngredient:
                _resourceName.text = "Polished Alchemy Ingredient";
                break;
            case EResource.PolishedMagicCrystal:
                _resourceName.text = "Polished Magic Crystal";
                break;
            case EResource.PolishedTitan:
                _resourceName.text = "Polished Titan";
                break;
            case EResource.PolishedLunocit:
                _resourceName.text = "Polished Lunocit";
                break;
        }
    }
    public void SetupNoneResourceName(EResource resource)
    {
        switch (resource)
        {
            case EResource.PolishedWood:
                _resourceName.text = "You don't have raw wood";
                break;
            case EResource.PolishedStone:
                _resourceName.text = "You don't have raw stone";
                break;
            case EResource.PolishedIron:
                _resourceName.text = "You don't have raw iron";
                break;
            case EResource.PolishedLeather:
                _resourceName.text = "You don't have raw leather";
                break;
            case EResource.PolishedSilver:
                _resourceName.text = "You don't have raw silver";
                break;
            case EResource.PolishedGold:
                _resourceName.text = "You don't have raw gold";
                break;
            case EResource.PolishedAlchemicalIngredient:
                _resourceName.text = "You don't have raw alchemical ingredient";
                break;
            case EResource.PolishedMagicCrystal:
                _resourceName.text = "You don't have raw magic crystal";
                break;
            case EResource.PolishedTitan:
                _resourceName.text = "You don't have raw titan";
                break;
            case EResource.PolishedLunocit:
                _resourceName.text = "You don't have raw lunocit";
                break;
        }
    }

    public void Switch(EResource resource, bool flag)
    {
        _hpSlider.gameObject.SetActive(flag);
        _polishButton.interactable = flag;
        if (flag)
        {
            SetupResourceName(resource);
        }
        else
        {
            SetupNoneResourceName(resource);
        }
    }
}