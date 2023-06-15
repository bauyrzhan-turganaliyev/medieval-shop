using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MakeView : MonoBehaviour
{
    [SerializeField] private ItemsConfig _itemsConfig;
    
    [SerializeField] private ChoosePanelView _choosePanelView;
    [SerializeField] private ChooseMaterialView _chooseMaterialView;
    
    [SerializeField] private GameObject _partsPanel;
    [SerializeField] private GameObject _makePanel;
    [SerializeField] private GameObject _jackpotPanel;
    [SerializeField] private GameObject _acceptPanel;
    
    [SerializeField] private List<MakeItem> _items;
    
    [SerializeField] private RectTransform _progressBar; 
    [SerializeField] private RectTransform _greenZone;
    [SerializeField] private MakeCursor _cursor;
    
    [SerializeField] private Button _choosePanelButton;
    [SerializeField] private Button _backChooseItemButton;
    [SerializeField] private Button _backChooseMaterialButton;
    [SerializeField] private MakeButton _makeButton;

    [SerializeField] private Button _resultButton;
    [SerializeField] private TMP_Text _resultText;
    
    [SerializeField] private float _greenZoneSpeed;
    [SerializeField] private float _cursorSpeed;

    public Action AllPartsPlaced;
    public Action OnCreatedForm;

    private float _progressBarWidth;
    private float _greenZoneWidth;
    private float _cursorWidth;
    private float _elapsed;

    private bool _isMovingRight;
    private bool _cursorRight;
    private bool _inGreenZone;
    
    private ItemClass _currentChosenItem;
    private MakeItem _currentMakeItem;

    public void Init()
    {
        _choosePanelView.Init();
        _choosePanelView.OnItemChosen += ItemChosen;
        _chooseMaterialView.OnNeedResources += ItemClicked;

        _progressBarWidth = _progressBar.rect.width;
        _greenZoneWidth = _greenZone.rect.width;
        _cursorWidth = _cursor.RectTransform.rect.width;

        foreach (var item in _items)
        {
            item.Init();
            item.OnAllPartsPlaced += () =>
            {
                item.ResetProgressBar();
                AllPartsPlaced?.Invoke();
            };    
        }
        
        
        _backChooseMaterialButton.onClick.AddListener((() =>
        {
            SwitchMaterialPanel(false);
            SwitchChoosePanel(true);
        }));
        _backChooseItemButton.onClick.AddListener(() => SwitchChoosePanel(false));
        _choosePanelButton.onClick.AddListener((() => SwitchChoosePanel(true)));

        _makeButton.OnPressing += SetCursorMode;
        _cursor.OnGreenZoneOn += InGreenZone;
        _resultButton.onClick.AddListener(Reset);
    }

    private void ItemClicked(List<NeedResources> needResources)
    {
        foreach (var item in _items)
        {
            if (item.ItemClass == _currentChosenItem)
            {
                _currentMakeItem = item;
                break;
            }
        }
        _currentMakeItem.Reset();
        SwitchMaterialPanel(false);
        _choosePanelButton.gameObject.SetActive(false);
        _partsPanel.SetActive(true);
        print($"Current item class {_currentChosenItem}, material {needResources[0].Resource}");
    }

    private void ItemChosen(ItemClass obj)
    {
        _currentChosenItem = obj;
        
        SwitchChoosePanel(false);
        _chooseMaterialView.Clear();
        foreach (var item in _itemsConfig.Items)
        {
            if (item.ItemClass == obj)
            {
                _chooseMaterialView.CreateMaterials(item);
            }
        }

        SwitchMaterialPanel(true);
    }

    private void SwitchMaterialPanel(bool b)
    {
        _chooseMaterialView.gameObject.SetActive(b);
    }

    private void SwitchChoosePanel(bool b)
    {
        _choosePanelView.gameObject.SetActive(b);
    }

    private void InGreenZone(bool obj)
    {
        _inGreenZone = obj;
    }

    private void SetCursorMode(bool obj)
    {
        _cursorRight = obj;
    }

    private void Update()
    {
        _elapsed += Time.deltaTime;

        if (_inGreenZone)
        {
            _currentMakeItem.ProgressBar.fillAmount += 0.1f * Time.deltaTime;
            if (_currentMakeItem.ProgressBar.fillAmount >= 1)
            {
                End();
                _cursorRight = false;
            }
        }
        
        if (_elapsed > 0.75f)
        {
            _elapsed = 0;
            var randInt = Random.Range(0, 100);
            if (50 > randInt)
            {
                _isMovingRight = !_isMovingRight;
            }
        }

        float cursorPosition = _cursor.RectTransform.localPosition.x;

        if (_cursorRight)
        {
            cursorPosition += _cursorSpeed * Time.deltaTime;
            if (cursorPosition >= _progressBarWidth / 2f - _cursorWidth / 2f)
            {
                cursorPosition = _progressBarWidth / 2f - _cursorWidth / 2f;
            }
        }
        else
        {
            cursorPosition -= _cursorSpeed * Time.deltaTime;
            if (cursorPosition <= -_progressBarWidth / 2f + _cursorWidth / 2f)
            {
                cursorPosition = -_progressBarWidth / 2f + _cursorWidth / 2f;
            }
        }

        _cursor.RectTransform.localPosition = new Vector3(cursorPosition, _cursor.RectTransform.localPosition.y, _cursor.RectTransform.localPosition.z);
        
        float greenZonePosition = _greenZone.localPosition.x;

        if (_isMovingRight)
        {
            greenZonePosition += _greenZoneSpeed * Time.deltaTime;
            if (greenZonePosition >= _progressBarWidth / 2f - _greenZoneWidth / 2f)
            {
                greenZonePosition = _progressBarWidth / 2f - _greenZoneWidth / 2f;
                _isMovingRight = false;
            }
        }
        else
        {
            greenZonePosition -= _greenZoneSpeed * Time.deltaTime;
            if (greenZonePosition <= -_progressBarWidth / 2f + _greenZoneWidth / 2f)
            {
                greenZonePosition = -_progressBarWidth / 2f + _greenZoneWidth / 2f;
                _isMovingRight = true;
            }
        }

        _greenZone.localPosition = new Vector3(greenZonePosition, _greenZone.localPosition.y, _greenZone.localPosition.z);
    }

    private void End()
    {
        Reset();

        OnCreatedForm?.Invoke();
        
        _choosePanelView.gameObject.SetActive(false);
        _choosePanelButton.gameObject.SetActive(false);
        _jackpotPanel.gameObject.SetActive(true);
    }

    private void Reset()
    {
        _choosePanelView.gameObject.SetActive(false);
        _partsPanel.SetActive(false);
        _makePanel.SetActive(false);
        _jackpotPanel.SetActive(false);
        _acceptPanel.SetActive(false);
        _choosePanelButton.gameObject.SetActive(true);
        _currentMakeItem?.Reset();
    }

    public void Switch(bool b)
    {
        gameObject.SetActive(b);
        Reset();
    }

    public void MakeMode()
    {
        _makePanel.SetActive(true);
    }

    public void ItemHasDone(string item, ItemQuality itemQuality)
    {
        _jackpotPanel.SetActive(false);
        _acceptPanel.SetActive(true);
        _resultText.text = $"You made {item}\n" + $"Quality - {itemQuality}";
    }
}