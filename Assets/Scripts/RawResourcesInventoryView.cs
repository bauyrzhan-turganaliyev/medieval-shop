using UnityEngine;
using Zenject;

public class RawResourcesInventoryView : MonoBehaviour
{
    [SerializeField] private ResourcesItemView _woodView;
    [SerializeField] private ResourcesItemView _stoneView;
    [SerializeField] private ResourcesItemView _ironView;
    [SerializeField] private ResourcesItemView _leatherView;
    [SerializeField] private ResourcesItemView _silverView;
    [SerializeField] private ResourcesItemView _goldView;
    [SerializeField] private ResourcesItemView _alchemicalIngredientView;
    [SerializeField] private ResourcesItemView _magicCrystalView;
    [SerializeField] private ResourcesItemView _titanView;
    [SerializeField] private ResourcesItemView _lunocitView;

    private MessageBus _messageBus;
    private ResourcesData _resourcesData;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }
    
    public void Init(ResourcesData resourcesData)
    {
        _resourcesData = resourcesData;

        _messageBus.OnResourceCountChanged += UpdateAllResources;
        UpdateAllResources();
    }

    private void UpdateAllResources()
    {
        _woodView.SetCount(_resourcesData.RawWoods);
        _stoneView.SetCount(_resourcesData.RawStones);
        _ironView.SetCount(_resourcesData.RawIrons);
        _leatherView.SetCount(_resourcesData.RawLeather);
        _silverView.SetCount(_resourcesData.RawSilver);
        _goldView.SetCount(_resourcesData.RawGold);
        _alchemicalIngredientView.SetCount(_resourcesData.RawAlchemicalIngredients);
        _magicCrystalView.SetCount(_resourcesData.RawMagicCrystals);
        _titanView.SetCount(_resourcesData.RawTitans);
        _lunocitView.SetCount(_resourcesData.RawLunocits);
    }
}