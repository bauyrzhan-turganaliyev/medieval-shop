using System;
using System.Collections.Generic;
using ModestTree.Util;
using UnityEngine;
using UnityEngine.UI;

public class CustomerService : MonoBehaviour
{
    [SerializeField] private Button _addCustomer;
    [SerializeField] private Button _serviceCustomer;

    [SerializeField] private OrderService _orderService;
    
    [SerializeField] private Customer _customerPrefab;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _destroyPoint;

    public Action<Customer> OnCustomerUpdated;
    
    private float _elapsed;

    private List<Customer> _customers;

    public void Start()
    {
        _customers = new List<Customer>();
        _addCustomer.onClick.AddListener(SpawnCustomer);
        _serviceCustomer.onClick.AddListener(CustomerServiced);
    }

    private void CustomerServiced()
    {
        _customers[0].MoveTo(_destroyPoint.position);
        _customers.RemoveAt(0);
        
        for (int i = 0; i < _customers.Count; i++)
        {
            print($"Customer n{i} is moving to {_targetPoint.position.z + -1.5f * (i+1)}");
            if (i == 0) 
                _customers[i].MoveTo(_targetPoint.position + new Vector3(0, 0, -1.5f * (i)));
            else 
                _customers[i].MoveTo(_targetPoint.position + new Vector3(0, 0, -1.5f * (i+1)));
        }

        if (_customers.Count == 0)
        {
            _serviceCustomer.interactable = false;
            OnCustomerUpdated?.Invoke(null);
        }
        else
        {
            OnCustomerUpdated?.Invoke(_customers[0]);
        }
        
    }

    private async void SpawnCustomer()
    {
        var customer = Instantiate(_customerPrefab);

        var order = _orderService.GenerateOrder();
        
        customer.SetOrder(order);
        
        customer.transform.position = _spawnPoint.position;
        _customers.Add(customer);
        print(_targetPoint.position.z + -1.5f * _customers.Count);
        if (_customers.Count == 1)
            await customer.MoveTo(_targetPoint.position);
        else 
            await customer.MoveTo(_targetPoint.position + new Vector3(0, 0, -1.5f * _customers.Count));

        _serviceCustomer.interactable = true;
        OnCustomerUpdated?.Invoke(_customers[0]);
    }
    

    public Customer GetFirstCustomer()
    {
        return _customers != null && _customers.Count > 0 ? _customers[0] : null;
    }
}