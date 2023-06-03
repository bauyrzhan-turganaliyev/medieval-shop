using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _itemCount;

    public void SetCount(int count)
    {
        _itemCount.text = count.ToString();
    }
}