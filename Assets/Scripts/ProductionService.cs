using System.Globalization;
using ModestTree.Util;
using UnityEngine;
using Zenject;

public class ProductionService : MonoBehaviour
{
    [SerializeField] private ResourcesConfig _resourcesConfig;
    [SerializeField] private ProductionView _productionView;

    private EResource _currentSelectedResource;
    
    private ResourcesData _resourcesData;
    private ProductionSkillData _productionSkillData;
    private MessageBus _messageBus;

    private float _hpOfResource;
    private int _maxHPofResource;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public void Init(ResourcesData resourcesData, ProductionSkillData productionSkillData)
    {
        _resourcesData = resourcesData;
        _productionSkillData = productionSkillData;

        _productionView.Init();
        _productionView.OnProductionClicked += ProductionClicked;

        _currentSelectedResource = EResource.Wood;
        
        SetMaxHPOfResource();
        _hpOfResource = _maxHPofResource;
        
        _productionView.SetHP(_hpOfResource, _maxHPofResource);
        _productionView.SetupResourceName(_currentSelectedResource);
    }

    private void SetMaxHPOfResource()
    {
        switch (_currentSelectedResource)
        {
            case EResource.Wood:
                _maxHPofResource = _resourcesConfig.WoodMaxHP;
                break;
            case EResource.Stone:
                _maxHPofResource = _resourcesConfig.StoneMaxHP;
                break;
            case EResource.Iron:
                _maxHPofResource = _resourcesConfig.IronMaxHP;
                break;
            case EResource.Leather:
                _maxHPofResource = _resourcesConfig.LeatherMaxHP;
                break;
            case EResource.Silver:
                _maxHPofResource = _resourcesConfig.SilverMaxHP;
                break;
            case EResource.Gold:
                _maxHPofResource = _resourcesConfig.GoldMaxHP;
                break;
            case EResource.AlchemicalIngredient:
                _maxHPofResource = _resourcesConfig.AlchemicalIngredientMaxHP;
                break;
            case EResource.MagicCrystal:
                _maxHPofResource = _resourcesConfig.MagicCrystalMaxHP;
                break;
            case EResource.Titan:
                _maxHPofResource = _resourcesConfig.TitanMaxHP;
                break;
            case EResource.Lunocit:
                _maxHPofResource = _resourcesConfig.LunocitMaxHP;
                break;
        }
    }

    private void ProductionClicked()
    {
        switch (_currentSelectedResource)
        {
            case EResource.Wood:
                var resourceCount = _productionSkillData.Strength / _hpOfResource;

                if (_productionSkillData.Strength == _hpOfResource)
                    _hpOfResource = _maxHPofResource;
                else 
                    _hpOfResource -= _productionSkillData.Strength % _hpOfResource;

                if (resourceCount > 0)
                {
                    _resourcesData.Woods += Mathf.FloorToInt(resourceCount);
                    _messageBus.OnResourceCountChanged?.Invoke();
                }

                break;
            case EResource.Stone:
                break;
            case EResource.Iron:
                break;
            case EResource.Leather:
                break;
            case EResource.Silver:
                break;
            case EResource.Gold:
                break;
            case EResource.AlchemicalIngredient:
                break;
            case EResource.MagicCrystal:
                break;
            case EResource.Titan:
                break;
            case EResource.Lunocit:
                break;
        }

        _productionView.SetHP(_hpOfResource, _maxHPofResource);
    }
}