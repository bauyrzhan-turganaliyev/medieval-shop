using UnityEngine;
using Zenject;

public class TradeService : MonoBehaviour
{
    [SerializeField] private TradeView _tradeView;
    [SerializeField] private CustomerService _customerService;
    
    private MessageBus _messageBus;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public void Init()
    {
        _messageBus.OnModeChanged += ModeChanged;
        _customerService.OnCustomerUpdated += CustomerUpdate;
        _tradeView.Init();
    }

    private void CustomerUpdate(Customer customer)
    {
        _tradeView.SwitchHasCustomer(customer);
    }

    private void ModeChanged(EMode obj)
    {
        _tradeView.Switch(obj == EMode.Trade, _customerService.GetFirstCustomer());
    }
}