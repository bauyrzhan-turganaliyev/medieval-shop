using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemVisual : MonoBehaviour
{
    [SerializeField] private Image _qualityBorder;
    [SerializeField] private Image _icon;

    [SerializeField] private List<Color> _colors;
    public void Setup(Item item)
    {
        switch (item.ItemQuality)
        {
            case ItemQuality.Broken:
                _qualityBorder.color = _colors[0];
                break;
            case ItemQuality.Bad:
                _qualityBorder.color = _colors[1];
                break;
            case ItemQuality.Okay:
                _qualityBorder.color = _colors[2];
                break;
            case ItemQuality.Good:
                _qualityBorder.color = _colors[3];
                break;
            case ItemQuality.Great:
                _qualityBorder.color = _colors[4];
                break;
            case ItemQuality.Legendary:
                _qualityBorder.color = _colors[5];
                break;
        }
    }
}