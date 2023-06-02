using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Zenject;

public class ModeSwitcherService : MonoBehaviour
{
    [SerializeField] private Button _tradeButton;
    [SerializeField] private Button _productionButton;
    [SerializeField] private Button _polishButton;
    [SerializeField] private Button _makeButton;
    private MessageBus _messageBus;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }
    public void Init()
    {
        _tradeButton.onClick.AddListener((() =>
        {
            _messageBus.OnModeChanged?.Invoke(EMode.Trade);
        }));
        _productionButton.onClick.AddListener((() =>
        {
            _messageBus.OnModeChanged?.Invoke(EMode.Production);
        }));
        _polishButton.onClick.AddListener((() =>
        {
            _messageBus.OnModeChanged?.Invoke(EMode.Polish);
        }));
        _makeButton.onClick.AddListener((() =>
        {
            _messageBus.OnModeChanged?.Invoke(EMode.Make);
        }));
    }
    

}
    

