using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TradeInfoView : MonoBehaviour
{
    public TMP_Text ItemClass;
    public TMP_Text Material;
    public TMP_Text Count;
    public TMP_Text Income;

    public void SetInfo(ItemClass itemClass, Resources material, int count, float income)
    {
        ItemClass.text = "Item class: " + itemClass;
        Material.text = "Material: " + material;
        Count.text = "Count: " + count;
        Income.text = "Expected income: " + income;
    }
    public void SetInfo(Customer customer)
    {
        if (customer == null) return;
        ItemClass.text = "Item class: " + customer.GetOrder().Item;
        Material.text = "Material: " + customer.GetOrder().Material;
        Count.text = "Count: " + customer.GetOrder().Count;
        Income.text = "Expected income: " + customer.GetOrder().Price;
    }
}
