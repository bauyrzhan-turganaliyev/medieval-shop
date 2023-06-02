using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ModeSwitcherService : MonoBehaviour
{
    [SerializeField] private Button _tradeButton;
    [SerializeField] private Button _productionButton;
    [SerializeField] private Button _polishButton;
    [SerializeField] private Button _makeButton;
    private MessageBus _messageBus;

    public void Init(MessageBus messageBus)
    {
        _messageBus = messageBus;
        
        _tradeButton.onClick.AddListener((() =>
        {
            _messageBus.OnMoveTo?.Invoke(EDestionation.Trade);
        }));
        _productionButton.onClick.AddListener((() =>
        {
            _messageBus.OnMoveTo?.Invoke(EDestionation.Production);
        }));
        _polishButton.onClick.AddListener((() =>
        {
            _messageBus.OnMoveTo?.Invoke(EDestionation.Polish);
        }));
        _makeButton.onClick.AddListener((() =>
        {
            _messageBus.OnMoveTo?.Invoke(EDestionation.Make);
        }));
    }
    

}
    

