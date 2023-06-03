using UnityEngine;
using Zenject;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryItemView _woodView;
    [SerializeField] private InventoryItemView _stoneView;
    [SerializeField] private InventoryItemView _ironView;
    [SerializeField] private InventoryItemView _leatherView;
    [SerializeField] private InventoryItemView _silverView;
    [SerializeField] private InventoryItemView _goldView;
    [SerializeField] private InventoryItemView _alchemicalIngredientView;
    [SerializeField] private InventoryItemView _magicCrystalView;
    [SerializeField] private InventoryItemView _titanView;
    [SerializeField] private InventoryItemView _lunocitView;

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
        _woodView.SetCount(_resourcesData.Woods);
        _stoneView.SetCount(_resourcesData.Stones);
        _ironView.SetCount(_resourcesData.Irons);
        _leatherView.SetCount(_resourcesData.Leather);
        _silverView.SetCount(_resourcesData.Silver);
        _goldView.SetCount(_resourcesData.Gold);
        _alchemicalIngredientView.SetCount(_resourcesData.AlchemicalIngredients);
        _magicCrystalView.SetCount(_resourcesData.MagicCrystals);
        _titanView.SetCount(_resourcesData.Titans);
        _lunocitView.SetCount(_resourcesData.Lunocits);
    }
}