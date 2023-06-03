using UnityEngine;
using Zenject;

public class PolishedResourcesInventoryView : MonoBehaviour
{
    [SerializeField] private ResourcesItemView _polishedWoodView;
    [SerializeField] private ResourcesItemView _polishedStoneView;
    [SerializeField] private ResourcesItemView _polishedIronView;
    [SerializeField] private ResourcesItemView _polishedLeatherView;
    [SerializeField] private ResourcesItemView _polishedSilverView;
    [SerializeField] private ResourcesItemView _polishedGoldView;
    [SerializeField] private ResourcesItemView _polishedAlchemicalIngredientView;
    [SerializeField] private ResourcesItemView _polishedMagicCrystalView;
    [SerializeField] private ResourcesItemView _polishedTitanView;
    [SerializeField] private ResourcesItemView _polishedLunocitView;

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
        _polishedWoodView.SetCount(_resourcesData.PolishedWoods);
        _polishedStoneView.SetCount(_resourcesData.PolishedStones);
        _polishedIronView.SetCount(_resourcesData.PolishedIrons);
        _polishedLeatherView.SetCount(_resourcesData.PolishedLeather);
        _polishedSilverView.SetCount(_resourcesData.PolishedSilver);
        _polishedGoldView.SetCount(_resourcesData.PolishedGold);
        _polishedAlchemicalIngredientView.SetCount(_resourcesData.PolishedAlchemicalIngredients);
        _polishedMagicCrystalView.SetCount(_resourcesData.PolishedMagicCrystals);
        _polishedTitanView.SetCount(_resourcesData.PolishedTitans);
        _polishedLunocitView.SetCount(_resourcesData.PolishedLunocits);
    }
}