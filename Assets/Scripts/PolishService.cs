using System.Globalization;
using ModestTree.Util;
using UnityEngine;
using UnityEngine.UI;
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

        _polishView.OnPolishClicked += OnButtonClick;
        _messageBus.OnResourceCountChanged += ResourcesCountChanged;
        _messageBus.OnModeChanged += ModeChanged;
        _polishView.Init();

        _currentSelectedResource = EResource.PolishedWood;
    }

    private void ModeChanged(EMode obj)
    {
        if (obj == EMode.Polish)
        {
            ResourcesCountChanged();
        }
    }

    private void ResourcesCountChanged()
    {
        switch (_currentSelectedResource)
        {
            case EResource.PolishedWood:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawWoods > 0);
                break;
            case EResource.PolishedStone:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawStones > 0);
                break;
            case EResource.PolishedIron:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawIrons > 0);
                break;
            case EResource.PolishedLeather:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawLeather > 0);
                break;
            case EResource.PolishedSilver:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawSilver > 0);
                break;
            case EResource.PolishedGold:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawGold > 0);
                break;
            case EResource.PolishedAlchemicalIngredient:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawAlchemicalIngredients > 0);
                break;
            case EResource.PolishedMagicCrystal:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawMagicCrystals > 0);
                break;
            case EResource.PolishedTitan:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawTitans > 0);
                break;
            case EResource.PolishedLunocit:
                _polishView.Switch(_currentSelectedResource, _resourcesData.RawLunocits > 0);
                break;
        }
    }

    private void OnButtonClick(PolishAccuracy obj)
    {
        if (obj == PolishAccuracy.Green)
        {
            var max = 0;
            switch (_currentSelectedResource)
            {
                case EResource.PolishedWood:
                    max = _resourcesData.RawWoods;
                    break;
                case EResource.PolishedStone:
                    max = _resourcesData.RawStones;
                    break;
                case EResource.PolishedIron:
                    max = _resourcesData.RawIrons;
                    break;
                case EResource.PolishedLeather:
                    max = _resourcesData.RawLeather;
                    break;
                case EResource.PolishedSilver:
                    max = _resourcesData.RawSilver;
                    break;
                case EResource.PolishedGold:
                    max = _resourcesData.RawGold;
                    break;
                case EResource.PolishedAlchemicalIngredient:
                    max = _resourcesData.RawAlchemicalIngredients;
                    break;
                case EResource.PolishedMagicCrystal:
                    max = _resourcesData.RawMagicCrystals;
                    break;
                case EResource.PolishedTitan:
                    max = _resourcesData.RawTitans;
                    break;
                case EResource.PolishedLunocit:
                    max = _resourcesData.RawLunocits;
                    break;
            }

            bool isOut = max <= _polishSkillData.Strength;

            if (isOut)
            {
                switch (_currentSelectedResource)
                {
                    case EResource.PolishedWood:
                        _resourcesData.RawWoods = 0;
                        _resourcesData.PolishedWoods += max;
                        break;
                    case EResource.PolishedStone:
                        _resourcesData.RawStones = 0;
                        _resourcesData.PolishedStones += max;
                        break;
                    case EResource.PolishedIron:
                        _resourcesData.RawIrons = 0;
                        _resourcesData.PolishedIrons += max;
                        break;
                    case EResource.PolishedLeather:
                        _resourcesData.RawLeather = 0;
                        _resourcesData.PolishedLeather += max;
                        break;
                    case EResource.PolishedSilver:
                        _resourcesData.RawSilver = 0;
                        _resourcesData.PolishedSilver += max;
                        break;
                    case EResource.PolishedGold:
                        _resourcesData.RawGold = 0;
                        _resourcesData.PolishedGold += max;
                        break;
                    case EResource.PolishedAlchemicalIngredient:
                        _resourcesData.RawAlchemicalIngredients = 0;
                        _resourcesData.PolishedAlchemicalIngredients += max;
                        break;
                    case EResource.PolishedMagicCrystal:
                        _resourcesData.RawMagicCrystals = 0;
                        _resourcesData.PolishedMagicCrystals += max;
                        break;
                    case EResource.PolishedTitan:
                        _resourcesData.RawTitans = 0;
                        _resourcesData.PolishedTitans += max;
                        break;
                    case EResource.PolishedLunocit:
                        _resourcesData.RawLunocits = 0;
                        _resourcesData.PolishedLunocits += max;
                        break;
                }
                
                _messageBus.OnResourceCountChanged?.Invoke();
            }
            else
            {
                 switch (_currentSelectedResource)
                {
                    case EResource.PolishedWood:
                        _resourcesData.RawWoods -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedWoods += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedStone:
                        _resourcesData.RawStones -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedStones += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedIron:
                        _resourcesData.RawIrons -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedIrons += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedLeather:
                        _resourcesData.RawLeather -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedLeather += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedSilver:
                        _resourcesData.RawSilver -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedSilver += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedGold:
                        _resourcesData.RawGold -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedGold += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedAlchemicalIngredient:
                        _resourcesData.RawAlchemicalIngredients -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedAlchemicalIngredients += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedMagicCrystal:
                        _resourcesData.RawMagicCrystals -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedMagicCrystals += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedTitan:
                        _resourcesData.RawTitans -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedTitans += (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedLunocit:
                        _resourcesData.RawLunocits -= (int)_polishSkillData.Strength;
                        _resourcesData.PolishedLunocits += (int)_polishSkillData.Strength;
                        break;
                }
                 
                 _messageBus.OnResourceCountChanged?.Invoke();
            }
            
        } 
        else if (obj == PolishAccuracy.Red)
        {
            var max = 0;
            switch (_currentSelectedResource)
            {
                case EResource.PolishedWood:
                    max = _resourcesData.RawWoods;
                    break;
                case EResource.PolishedStone:
                    max = _resourcesData.RawStones;
                    break;
                case EResource.PolishedIron:
                    max = _resourcesData.RawIrons;
                    break;
                case EResource.PolishedLeather:
                    max = _resourcesData.RawLeather;
                    break;
                case EResource.PolishedSilver:
                    max = _resourcesData.RawSilver;
                    break;
                case EResource.PolishedGold:
                    max = _resourcesData.RawGold;
                    break;
                case EResource.PolishedAlchemicalIngredient:
                    max = _resourcesData.RawAlchemicalIngredients;
                    break;
                case EResource.PolishedMagicCrystal:
                    max = _resourcesData.RawMagicCrystals;
                    break;
                case EResource.PolishedTitan:
                    max = _resourcesData.RawTitans;
                    break;
                case EResource.PolishedLunocit:
                    max = _resourcesData.RawLunocits;
                    break;
            }

            bool isOut = max <= _polishSkillData.Strength;

            if (isOut)
            {
                switch (_currentSelectedResource)
                {
                    case EResource.PolishedWood:
                        _resourcesData.RawWoods = 0;
                        break;
                    case EResource.PolishedStone:
                        _resourcesData.RawStones = 0;
                        break;
                    case EResource.PolishedIron:
                        _resourcesData.RawIrons = 0;
                        break;
                    case EResource.PolishedLeather:
                        _resourcesData.RawLeather = 0;
                        break;
                    case EResource.PolishedSilver:
                        _resourcesData.RawSilver = 0;
                        break;
                    case EResource.PolishedGold:
                        _resourcesData.RawGold = 0;
                        break;
                    case EResource.PolishedAlchemicalIngredient:
                        _resourcesData.RawAlchemicalIngredients = 0;
                        break;
                    case EResource.PolishedMagicCrystal:
                        _resourcesData.RawMagicCrystals = 0;
                        break;
                    case EResource.PolishedTitan:
                        _resourcesData.RawTitans = 0;
                        break;
                    case EResource.PolishedLunocit:
                        _resourcesData.RawLunocits = 0;
                        break;
                }
            }
            else
            {
                 switch (_currentSelectedResource)
                {
                    case EResource.PolishedWood:
                        _resourcesData.RawWoods -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedStone:
                        _resourcesData.RawStones -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedIron:
                        _resourcesData.RawIrons -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedLeather:
                        _resourcesData.RawLeather -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedSilver:
                        _resourcesData.RawSilver -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedGold:
                        _resourcesData.RawGold -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedAlchemicalIngredient:
                        _resourcesData.RawAlchemicalIngredients -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedMagicCrystal:
                        _resourcesData.RawMagicCrystals -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedTitan:
                        _resourcesData.RawTitans -= (int)_polishSkillData.Strength;
                        break;
                    case EResource.PolishedLunocit:
                        _resourcesData.RawLunocits -= (int)_polishSkillData.Strength;
                        break;
                }
            }
            
            
            _messageBus.OnResourceCountChanged?.Invoke();
        }
        
        _polishView.UpdateView();
    }
    

    public enum PolishAccuracy
    {
        Red,
        Yellow,
        Green
    }
}