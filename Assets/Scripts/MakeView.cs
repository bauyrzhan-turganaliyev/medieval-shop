using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
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

    [SerializeField] private MakeItem _makeItem;
    
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

    public Action OnCreatedForm;

    private MessageBus _messageBus;
    private PlayerProgress _playerProgress;

    private float _progressBarWidth;
    private float _greenZoneWidth;
    private float _cursorWidth;
    private float _elapsed;

    private bool _isMovingRight;
    private bool _cursorRight;
    private bool _inGreenZone;

    private ItemClass _currentChosenItem;
    private List<NeedResources> _needResources;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public void Init(PlayerProgress playerProgress)
    {
        _playerProgress = playerProgress;

        _choosePanelView.Init();
        _choosePanelView.OnItemChosen += ItemChosen;
        _chooseMaterialView.OnNeedResources += ItemClicked;

        _progressBarWidth = _progressBar.rect.width;
        _greenZoneWidth = _greenZone.rect.width;
        _cursorWidth = _cursor.RectTransform.rect.width;
        
        _makeItem.Reset();
  
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
        _needResources = needResources;
        var isOk = true;
        foreach (var resource in needResources)
        {
            switch (resource.Resource)
            {
                case EResource.PolishedWood:
                    if (_playerProgress.ResourcesData.PolishedWoods < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedWoods -= resource.Count;
                    break;
                case EResource.PolishedStone:
                    if (_playerProgress.ResourcesData.PolishedStones < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedStones -= resource.Count;
                    break;
                case EResource.PolishedIron:
                    if (_playerProgress.ResourcesData.PolishedIrons < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedIrons -= resource.Count;
                    break;
                case EResource.PolishedLeather:
                    if (_playerProgress.ResourcesData.PolishedLeather < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedLeather -= resource.Count;
                    break;
                case EResource.PolishedSilver:
                    if (_playerProgress.ResourcesData.PolishedSilver < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedSilver -= resource.Count;
                    break;
                case EResource.PolishedGold:
                    if (_playerProgress.ResourcesData.PolishedGold < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedGold -= resource.Count;
                    break;
                case EResource.PolishedAlchemicalIngredient:
                    if (_playerProgress.ResourcesData.PolishedAlchemicalIngredients < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedAlchemicalIngredients -= resource.Count;
                    break;
                case EResource.PolishedMagicCrystal:
                    if (_playerProgress.ResourcesData.PolishedMagicCrystals < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedMagicCrystals -= resource.Count;
                    break;
                case EResource.PolishedTitan:
                    if (_playerProgress.ResourcesData.PolishedTitans < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedTitans -= resource.Count;
                    break;
                case EResource.PolishedLunocit:
                    if (_playerProgress.ResourcesData.PolishedLunocits < resource.Count) isOk = false;
                    else _playerProgress.ResourcesData.PolishedLunocits -= resource.Count;
                    break;
            }
        }

        if (!isOk)
        {
            print("Not enough resource");
            return;
        }

        SwitchMaterialPanel(false);
        
        _choosePanelButton.gameObject.SetActive(false);
        _partsPanel.SetActive(true);
        
        print($"Current item class {_currentChosenItem}, material {needResources[0].Resource}");

        _makeItem.Reset();
        MakeMode();
        
        _messageBus.OnResourceCountChanged?.Invoke();
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
            _makeItem.ProgressBar.fillAmount += 0.1f * Time.deltaTime;
            if (_makeItem.ProgressBar.fillAmount >= 1)
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
        _makeItem.Reset();
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
        
        _playerProgress.Inventory.Items.Add(new Item(_currentChosenItem, _needResources, itemQuality));
        _resultText.text = $"You made {item}\n" + $"Quality - {itemQuality}";
        
        _messageBus.OnInventoryUpdate?.Invoke();
    }
}