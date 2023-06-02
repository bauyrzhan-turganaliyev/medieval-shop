using System;
using UnityEngine;
using Zenject;

public class UIService : MonoBehaviour
{
    [SerializeField] private ProcessView _tradeView;
    [SerializeField] private ProcessView _productionView;
    [SerializeField] private ProcessView _polishView;
    [SerializeField] private ProcessView _makeView;

    private MessageBus _messageBus;
    
    private EMode _currentMode;
    private ProcessView _processView;
    
    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }
    public void Init()
    {
        _currentMode = EMode.Trade;
        _messageBus.OnModeChanged += ChangeView;
        _messageBus.OnModeChanged?.Invoke(_currentMode);
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