using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIService : MonoBehaviour
{
    [SerializeField] private RawResourcesInventoryView _rawResourcesInventoryView;
    [SerializeField] private PolishedResourcesInventoryView _polishedResourcesInventoryView;
    [SerializeField] private InventoryView _inventoryView;
    
    [SerializeField] private ProcessView _tradeView;
    [SerializeField] private ProcessView _productionView;
    [SerializeField] private ProcessView _polishView;
    [SerializeField] private ProcessView _makeView;

    [SerializeField] private Button _inventoryButton;

    private MessageBus _messageBus;
    
    private EMode _currentMode;
    private ProcessView _processView;
    
    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }
    public void Init(ResourcesData resourcesData)
    {
        _currentMode = EMode.Trade;
        _messageBus.OnModeChanged += ChangeView;
        _messageBus.OnModeChanged?.Invoke(_currentMode);
        
        _rawResourcesInventoryView.Init(resourcesData);
        _polishedResourcesInventoryView.Init(resourcesData);
        
        _inventoryButton.onClick.AddListener((() => _inventoryView.gameObject.SetActive(true)));
    }
    

    private void OnEnable()
    {
        _currentMode = EMode.Trade;
        _messageBus.OnModeChanged?.Invoke(_currentMode);
    }

    private void ChangeView(EMode mode)
    {
        if (_processView != null) _processView.Switch(false);
        
        _processView = mode switch
        {
            EMode.Trade => _tradeView,
            EMode.Production => _productionView,
            EMode.Polish => _polishView,
            EMode.Make => _makeView,
            _ => _processView
        };
        
        _processView.Switch(true);
    }
}