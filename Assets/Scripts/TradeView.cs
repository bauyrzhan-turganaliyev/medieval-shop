using System;
using UnityEngine;
using UnityEngine.UI;

public class TradeView : MonoBehaviour
{
    [SerializeField] private TradeInfoView _tradeInfoView;
    [SerializeField] private GameObject _hasCustomers;
    [SerializeField] private GameObject _noCustomers;
    
    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _tradeButton;
    [SerializeField] private Button _rejectButton;

    public Action OnAccept;
    public Action OnTrade;
    public Action OnReject;
    
    public void Init()
    {
        _acceptButton.onClick.AddListener((() => OnAccept?.Invoke()));
        _tradeButton.onClick.AddListener((() => OnTrade?.Invoke()));
        _rejectButton.onClick.AddListener((() => OnReject?.Invoke()));
    }

    public void Switch(bool b, Customer customer)
    {
        gameObject.SetActive(b);
        SwitchHasCustomer(customer);
    }

    public void SwitchHasCustomer(Customer customer)
    {
        _hasCustomers.SetActive(customer!=null);
        _noCustomers.SetActive(customer==null);

        _tradeInfoView.SetInfo(customer);
    }
}