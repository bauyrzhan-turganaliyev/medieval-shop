using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemResource : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _count;

    public void SetCount(int needResourcesCount)
    {
        _count.text = needResourcesCount.ToString();
    }
}