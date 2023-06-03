using System.Globalization;
using ModestTree.Util;
using UnityEngine;
using Zenject;

public class PolishService : MonoBehaviour
{
    [SerializeField] private PolishedResourcesConfig _resourcesConfig;
    [SerializeField] private PolishView _polishView;

    private EResource _currentSelectedResource;
    
    private ResourcesData _resourcesData;
    private PolishSkillData _polishSkillData;
    private MessageBus _messageBus;

    private float _hpOfResource;
    private int _maxHPofResource;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public void Init(ResourcesData resourcesData, PolishSkillData polishSkillData)
    {
        _resourcesData = resourcesData;
        _polishSkillData = polishSkillData;

        _polishView.Init();
        _polishView.OnPolishClicked += PolishClicked;

        _currentSelectedResource = EResource.PolishedWood;

        _messageBus.OnModeChanged += ModeChanged;
        
        SetMaxHPOfResource();
        _hpOfResource = _maxHPofResource;
        
        _polishView.SetHP(_hpOfResource, _maxHPofResource);
        _polishView.SetupResourceName(_currentSelectedResource);
    }

    private void ModeChanged(EMode mode)
    {
        if (mode == EMode.Polish)
        {
            switch (_currentSelectedResource)
            {
                case EResource.PolishedWood:
                    if (_resourcesData.RawWoods <= 0) _polishView.Switch(EResource.PolishedWood, false);
                    else _polishView.Switch(EResource.PolishedWood, true);
                        break;
                case EResource.PolishedStone:
                    if (_resourcesData.RawStones <= 0) _polishView.Switch(EResource.PolishedStone, false);
                    else _polishView.Switch(EResource.PolishedStone, true);
                    break;
                case EResource.PolishedIron:
                    if (_resourcesData.RawIrons <= 0) _polishView.Switch(EResource.PolishedIron, false);
                    else _polishView.Switch(EResource.PolishedIron, true);
                    break;
                case EResource.PolishedLeather:
                    if (_resourcesData.RawLeather <= 0) _polishView.Switch(EResource.PolishedLeather, false);
                    else _polishView.Switch(EResource.PolishedLeather, true);
                    break;
                case EResource.PolishedSilver:
                    if (_resourcesData.RawSilver <= 0) _polishView.Switch(EResource.PolishedSilver, false);
                    else _polishView.Switch(EResource.PolishedSilver, true);
                    break;
                case EResource.PolishedGold:
                    if (_resourcesData.RawGold <= 0) _polishView.Switch(EResource.PolishedGold, false);
                    else _polishView.Switch(EResource.PolishedGold, true);
                    break;
                case EResource.PolishedAlchemicalIngredient:
                    if (_resourcesData.RawAlchemicalIngredients <= 0) _polishView.Switch(EResource.PolishedAlchemicalIngredient, false);
                    else _polishView.Switch(EResource.PolishedAlchemicalIngredient, true);
                    break;
                case EResource.PolishedMagicCrystal:
                    if (_resourcesData.RawMagicCrystals <= 0) _polishView.Switch(EResource.PolishedMagicCrystal, false);
                    else _polishView.Switch(EResource.PolishedMagicCrystal, true);
                    break;
                case EResource.PolishedTitan:
                    if (_resourcesData.RawTitans <= 0) _polishView.Switch(EResource.PolishedTitan, false);
                    else _polishView.Switch(EResource.PolishedTitan, true);
                    break;
                case EResource.PolishedLunocit:
                    if (_resourcesData.RawLunocits <= 0) _polishView.Switch(EResource.PolishedLunocit, false);
                    else _polishView.Switch(EResource.PolishedLunocit, true);
                    break;
            }
        }
    }

    private void SetMaxHPOfResource()
    {
        switch (_currentSelectedResource)
        {
            case EResource.PolishedWood:
                _maxHPofResource = _resourcesConfig.WoodMaxHP;
                break;
            case EResource.PolishedStone:
                _maxHPofResource = _resourcesConfig.StoneMaxHP;
                break;
            case EResource.PolishedIron:
                _maxHPofResource = _resourcesConfig.IronMaxHP;
                break;
            case EResource.PolishedLeather:
                _maxHPofResource = _resourcesConfig.LeatherMaxHP;
                break;
            case EResource.PolishedSilver:
                _maxHPofResource = _resourcesConfig.SilverMaxHP;
                break;
            case EResource.PolishedGold:
                _maxHPofResource = _resourcesConfig.GoldMaxHP;
                break;
            case EResource.PolishedAlchemicalIngredient:
                _maxHPofResource = _resourcesConfig.AlchemicalIngredientMaxHP;
                break;
            case EResource.PolishedMagicCrystal:
                _maxHPofResource = _resourcesConfig.MagicCrystalMaxHP;
                break;
            case EResource.PolishedTitan:
                _maxHPofResource = _resourcesConfig.TitanMaxHP;
                break;
            case EResource.PolishedLunocit:
                _maxHPofResource = _resourcesConfig.LunocitMaxHP;
                break;
        }
    }

    private void PolishClicked()
    {
        switch (_currentSelectedResource)
        {
            case EResource.PolishedWood:
                var resourceCount = _polishSkillData.Strength / _hpOfResource;

                if (_polishSkillData.Strength == _hpOfResource)
                    _hpOfResource = _maxHPofResource;
                else 
                    _hpOfResource -= _polishSkillData.Strength % _hpOfResource;

                if (resourceCount > 0)
                {
                    _resourcesData.PolishedWoods += Mathf.FloorToInt(resourceCount);
                    _resourcesData.RawWoods -= Mathf.FloorToInt(resourceCount);
                    
                    if (_resourcesData.RawWoods <= 0) _polishView.Switch(EResource.PolishedWood, false);
                    
                    _messageBus.OnResourceCountChanged?.Invoke();
                }

                break;
            case EResource.PolishedStone:
                break;
            case EResource.PolishedIron:
                break;
            case EResource.PolishedLeather:
                break;
            case EResource.PolishedSilver:
                break;
            case EResource.PolishedGold:
                break;
            case EResource.PolishedAlchemicalIngredient:
                break;
            case EResource.PolishedMagicCrystal:
                break;
            case EResource.PolishedTitan:
                break;
            case EResource.PolishedLunocit:
                break;
        }

        _polishView.SetHP(_hpOfResource, _maxHPofResource);
    }
}