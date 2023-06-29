using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject.ReflectionBaking.Mono.Cecil;
using Random = System.Random;

public class OrderService : MonoBehaviour
{
    [SerializeField] private ItemsReceiptConfig _itemsReceiptConfig;

    private Resources[] _levelToResources;

    private void Awake()
    {
        _levelToResources = new Resources[10];
        _levelToResources[0] = Resources.Wood;
        _levelToResources[1] = Resources.Stone;
        _levelToResources[2] = Resources.Iron;
        _levelToResources[3] = Resources.Leather;
        _levelToResources[4] = Resources.Silver;
        _levelToResources[5] = Resources.Gold;
        _levelToResources[6] = Resources.Ingredients;
        _levelToResources[7] = Resources.MagicCrystal;
        _levelToResources[8] = Resources.Titan;
        _levelToResources[9] = Resources.Lunocit;
    }

    public Order GenerateOrder()
    {
        var order = new Order();
        
        Array values = Enum.GetValues(typeof(ItemClass));

        Random random = new Random();
        ItemClass itemClass = (ItemClass)values.GetValue(random.Next(values.Length));

        List<Resources> needRes = new List<Resources>();
        foreach (var ir in _itemsReceiptConfig.ItemsReceipt)
        {
            if (ir.ItemClass == itemClass)
            {
                needRes = ir.CanMadeFrom;
                break;
            }
        }

        order.Material = needRes[0];
        
        var randCount = UnityEngine.Random.Range(1, 3);
        order.Item = itemClass;
        order.Count = randCount;

        var randPrice = UnityEngine.Random.Range(2, 5);
        order.Price = randPrice;

        return order;
    }
}