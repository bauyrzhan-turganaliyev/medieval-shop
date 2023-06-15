using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class JapckpotWheel : MonoBehaviour
{
    [SerializeField] private int _level;
    
    [SerializeField] private int _partCount;

    [SerializeField] private Image _wheelPart;

    [SerializeField] private Transform _parent;
    [SerializeField] private Button _stopButton;
    [SerializeField] private List<Color> _colors;
    [SerializeField] private Color _pickColor;

    public Action<ItemQuality> OnJackpotStopped;
    
    private Dictionary<int, QualityWheelData> _array;
    private List<WheelPart> _list;
    private bool _isStop; 

    public void Init()
    {
        _list = new List<WheelPart>();
        _stopButton.onClick.AddListener((() => _isStop = true));
        _array = new Dictionary<int, QualityWheelData>
        { { 1, new QualityWheelData()
        {
            ItemQualityData = new List<ItemQuality>()
            {
                ItemQuality.Bad,
                ItemQuality.Broken,
                ItemQuality.Okay,
                ItemQuality.Bad,
                ItemQuality.Broken,
                ItemQuality.Bad,
                ItemQuality.Okay,
                ItemQuality.Broken,
                ItemQuality.Broken,
                ItemQuality.Good,
                ItemQuality.Broken,
                ItemQuality.Broken,
                ItemQuality.Okay,
                ItemQuality.Bad,
                ItemQuality.Broken,
                ItemQuality.Bad,
                ItemQuality.Okay,
                ItemQuality.Broken,
                ItemQuality.Bad,
            }
        } } };
        /*for (int i = 0; i < _partCount; i++)
        {
            var part = Instantiate(_wheelPart, _parent);
            var color = Random.ColorHSV();
            part.color = color;
            part.fillAmount = 1f / _partCount * (i + 1);
            part.transform.SetAsFirstSibling();
        }*/

    }

    public void CreateWheel()
    {
        for (int i = 0; i < _partCount; i++)
        {
            var part = Instantiate(_wheelPart, _parent);
            var color = new Color();
            switch (_array[_level].ItemQualityData[i])
            {
                case ItemQuality.Broken:
                    color = _colors[0];
                    break;
                case ItemQuality.Bad:
                    color = _colors[1];
                    break;
                case ItemQuality.Okay:
                    color = _colors[2];
                    break;
                case ItemQuality.Good:
                    color = _colors[3];
                    break;
                case ItemQuality.Great:
                    color = _colors[4];
                    break;
                case ItemQuality.Legendary:
                    color = _colors[5];
                    break;
            }

            part.color = color;
            part.fillAmount = 1f / _partCount * (i + 1);
            part.transform.SetAsFirstSibling();
            _list.Add(new WheelPart(part, _array[_level].ItemQualityData[i]));
        }
        
        StartWheel();
    }

    private async void StartWheel()
    {
        var index = 0;
        var color = _list[index].Visual.color;
        _list[index].Visual.color = _pickColor;
        var last = _list[index];
        
        while (!_isStop)
        {
            await Task.Delay(32);
            last.Visual.color = color;
            index++;
            if (index >= _list.Count)
            {
                index = 0;
            }
            color = _list[index].Visual.color;
            _list[index].Visual.color = _pickColor;
            last = _list[index];

        }

        Reset();
        _isStop = false;
        OnJackpotStopped?.Invoke(last.Quality);
    }

    private void Reset()
    {
        _list.Clear();
        for (int i = 0; i < _parent.childCount; i++)
        {
            Destroy(_parent.GetChild(i).gameObject);
        }
    }
}

public class WheelPart
{
    public Image Visual;
    public ItemQuality Quality;

    public WheelPart(Image part, ItemQuality itemQuality)
    {
        Visual = part;
        Quality = itemQuality;
    }
}

public class QualityWheelData
{
    public List<ItemQuality> ItemQualityData;
}
public enum ItemQuality
{
    Broken,
    Bad,
    Okay,
    Good,
    Great,
    Legendary,
}

public enum Resources
{
    Wood,
    Stone,
    Iron,
    Leather,
    Silver,
    Ingredients,
    MagicCrystal,
    Titan,
    Lunocit
}
