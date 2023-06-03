using System.Globalization;
using ModestTree.Util;
using UnityEngine;
using Zenject;

public class ProductionService : MonoBehaviour
{
    [SerializeField] private RawResourcesConfig _resourcesConfig;
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

        _currentSelectedResource = EResource.RawWood;
        
        SetMaxHPOfResource();
        _hpOfResource = _maxHPofResource;
        
        _productionView.SetHP(_hpOfResource, _maxHPofResource);
        _productionView.SetupResourceName(_currentSelectedResource);
    }

    private void SetMaxHPOfResource()
    {
        switch (_currentSelectedResource)
        {
            case EResource.RawWood:
                _maxHPofResource = _resourcesConfig.WoodMaxHP;
                break;
            case EResource.RawStone:
                _maxHPofResource = _resourcesConfig.StoneMaxHP;
                break;
            case EResource.RawIron:
                _maxHPofResource = _resourcesConfig.IronMaxHP;
                break;
            case EResource.RawLeather:
                _maxHPofResource = _resourcesConfig.LeatherMaxHP;
                break;
            case EResource.RawSilver:
                _maxHPofResource = _resourcesConfig.SilverMaxHP;
                break;
            case EResource.RawGold:
                _maxHPofResource = _resourcesConfig.GoldMaxHP;
                break;
            case EResource.RawAlchemicalIngredient:
                _maxHPofResource = _resourcesConfig.AlchemicalIngredientMaxHP;
                break;
            case EResource.RawMagicCrystal:
                _maxHPofResource = _resourcesConfig.MagicCrystalMaxHP;
                break;
            case EResource.RawTitan:
                _maxHPofResource = _resourcesConfig.TitanMaxHP;
                break;
            case EResource.RawLunocit:
                _maxHPofResource = _resourcesConfig.LunocitMaxHP;
                break;
        }
    }

    private void ProductionClicked()
    {
        switch (_currentSelectedResource)
        {
            case EResource.RawWood:
                var resourceCount = _productionSkillData.Strength / _hpOfResource;

                if (_productionSkillData.Strength == _hpOfResource)
                    _hpOfResource = _maxHPofResource;
                else 
                    _hpOfResource -= _productionSkillData.Strength % _hpOfResource;

                if (resourceCount > 0)
                {
                    _resourcesData.RawWoods += Mathf.FloorToInt(resourceCount);
                    _messageBus.OnResourceCountChanged?.Invoke();
                }

                break;
            case EResource.RawStone:
                break;
            case EResource.RawIron:
                break;
            case EResource.RawLeather:
                break;
            case EResource.RawSilver:
                break;
            case EResource.RawGold:
                break;
            case EResource.RawAlchemicalIngredient:
                break;
            case EResource.RawMagicCrystal:
                break;
            case EResource.RawTitan:
                break;
            case EResource.RawLunocit:
                break;
        }

        _productionView.SetHP(_hpOfResource, _maxHPofResource);
    }
}