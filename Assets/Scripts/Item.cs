using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Action OnAllPartsPlaced;
    
    public Image ProgressBar;
    public List<PlaceholderOfItem> PlaceholderOfItems;
    public List<PartOfItem> PartOfItems;

    private int _placedParts;
    public void Init()
    {
        foreach (var pi in PartOfItems)
        {
            pi.Init();
            pi.OnPartPlaced += PartPlaced;
        }

        foreach (var pi in PlaceholderOfItems)
        {
            pi.Init();
        }
    }

    private void PartPlaced(Transform part)
    {
        part.SetParent(ProgressBar.transform);
        _placedParts++;
        if (PartOfItems.Count == _placedParts) OnAllPartsPlaced?.Invoke();
    }

    public void Reset()
    {
        _placedParts = 0;
        foreach (var pi in PlaceholderOfItems)
        {
            pi.Reset();
        }

        foreach (var pi in PartOfItems)
        {
            pi.Reset();
        }
    }

    public void ResetProgressBar()
    {
        ProgressBar.fillAmount = 0;
    }
}