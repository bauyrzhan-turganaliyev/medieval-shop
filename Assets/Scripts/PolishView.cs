using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PolishView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _resourceName;
    
    [SerializeField] private RectTransform _progressBarRectTransform;
    [SerializeField] private RectTransform _cursorRectTransform;
    [SerializeField] private RectTransform _greenZoneRectTransform;
    [SerializeField] private RectTransform _yellowZoneLeft;
    [SerializeField] private RectTransform _yellowZoneRight;
    
    [SerializeField] private RectTransform _cursorPast;
    
    [SerializeField] private float _cursorSpeed = 5f;

    public Action<PolishService.PolishAccuracy> OnPolishClicked;
    
    private float _progressBarWidth;
    private float _cursorWidth;

    private float _greenZoneMinX;
    private float _greenZoneMaxX;

    private float _yellowZoneLeftMinX;
    private float _yellowZoneLeftMaxX;

    private float _yellowZoneRightMinX;
    private float _yellowZoneRightMaxX;

    private bool _isMovingRight = true;
    private bool _isOn;

    public void Init()
    {
        _progressBarWidth = _progressBarRectTransform.rect.width;
        _cursorWidth = _cursorRectTransform.rect.width;
        _button.onClick.AddListener(OnButtonClick);
        AdjustZones();
    }
    
    private void OnButtonClick()
    {
        float cursorPosition = _cursorRectTransform.localPosition.x;
        _cursorPast.position = _cursorRectTransform.position;
        
        if (cursorPosition >= _greenZoneMinX && cursorPosition <= _greenZoneMaxX)
        {
            OnPolishClicked?.Invoke(PolishService.PolishAccuracy.Green);
        } 
        else if ((cursorPosition >= _yellowZoneLeftMinX && cursorPosition <= _yellowZoneLeftMaxX) ||
                 (cursorPosition >= _yellowZoneRightMinX && cursorPosition <= _yellowZoneRightMaxX))
        {
            OnPolishClicked?.Invoke(PolishService.PolishAccuracy.Yellow);
        }
        else
        {
            OnPolishClicked?.Invoke(PolishService.PolishAccuracy.Red);
        }
    }
    private void Update()
    {
        if (!_isOn) return;
        
        float cursorPosition = _cursorRectTransform.localPosition.x;

        if (_isMovingRight)
        {
            cursorPosition += _cursorSpeed * Time.deltaTime;
            if (cursorPosition >= _progressBarWidth / 2f - _cursorWidth / 2f)
            {
                cursorPosition = _progressBarWidth / 2f - _cursorWidth / 2f;
                _isMovingRight = false;
            }
        }
        else
        {
            cursorPosition -= _cursorSpeed * Time.deltaTime;
            if (cursorPosition <= -_progressBarWidth / 2f + _cursorWidth / 2f)
            {
                cursorPosition = -_progressBarWidth / 2f + _cursorWidth / 2f;
                _isMovingRight = true;
            }
        }

        _cursorRectTransform.localPosition = new Vector3(cursorPosition, _cursorRectTransform.localPosition.y, _cursorRectTransform.localPosition.z);
    }
    public void SetupResourceName(EResource resource)
    {
        switch (resource)
        {
            case EResource.PolishedWood:
                _resourceName.text = "Polished Wood";
                break;
            case EResource.PolishedStone:
                _resourceName.text = "Polished Stone";
                break;
            case EResource.PolishedIron:
                _resourceName.text = "Polished Iron";
                break;
            case EResource.PolishedLeather:
                _resourceName.text = "Polished Leather";
                break;
            case EResource.PolishedSilver:
                _resourceName.text = "Polished Silver";
                break;
            case EResource.PolishedGold:
                _resourceName.text = "Polished Gold";
                break;
            case EResource.PolishedAlchemicalIngredient:
                _resourceName.text = "Polished Alchemy Ingredient";
                break;
            case EResource.PolishedMagicCrystal:
                _resourceName.text = "Polished Magic Crystal";
                break;
            case EResource.PolishedTitan:
                _resourceName.text = "Polished Titan";
                break;
            case EResource.PolishedLunocit:
                _resourceName.text = "Polished Lunocit";
                break;
        }
    }
    public void SetupNoneResourceName(EResource resource)
    {
        switch (resource)
        {
            case EResource.PolishedWood:
                _resourceName.text = "You don't have raw wood";
                break;
            case EResource.PolishedStone:
                _resourceName.text = "You don't have raw stone";
                break;
            case EResource.PolishedIron:
                _resourceName.text = "You don't have raw iron";
                break;
            case EResource.PolishedLeather:
                _resourceName.text = "You don't have raw leather";
                break;
            case EResource.PolishedSilver:
                _resourceName.text = "You don't have raw silver";
                break;
            case EResource.PolishedGold:
                _resourceName.text = "You don't have raw gold";
                break;
            case EResource.PolishedAlchemicalIngredient:
                _resourceName.text = "You don't have raw alchemical ingredient";
                break;
            case EResource.PolishedMagicCrystal:
                _resourceName.text = "You don't have raw magic crystal";
                break;
            case EResource.PolishedTitan:
                _resourceName.text = "You don't have raw titan";
                break;
            case EResource.PolishedLunocit:
                _resourceName.text = "You don't have raw lunocit";
                break;
        }
    }
    private void AdjustZones()
    {
        float progressBarHeight = _progressBarRectTransform.rect.height;
        
        float greenZoneHeight = progressBarHeight;
        var greenZoneWidth = Random.Range(50, 100);
        
        _greenZoneRectTransform.sizeDelta = new Vector2(greenZoneWidth, greenZoneHeight);

        var minGreenZoneXPosition = _progressBarRectTransform.rect.xMin + _greenZoneRectTransform.sizeDelta.x;
        var maxGreenZoneXPosition = _progressBarRectTransform.rect.xMax - _greenZoneRectTransform.sizeDelta.x;

        float randomOffset = Random.Range(minGreenZoneXPosition, maxGreenZoneXPosition);
        float greenZoneXPosition = _greenZoneRectTransform.localPosition.x + randomOffset;
        greenZoneXPosition = Mathf.Clamp(greenZoneXPosition, minGreenZoneXPosition, maxGreenZoneXPosition);

        _greenZoneRectTransform.localPosition = new Vector3(greenZoneXPosition, 0, 0);

        _greenZoneMinX = _greenZoneRectTransform.localPosition.x - _greenZoneRectTransform.sizeDelta.x / 2;
        _greenZoneMaxX = _greenZoneRectTransform.localPosition.x + _greenZoneRectTransform.sizeDelta.x / 2;

        var yellowZoneWidth = Random.Range(50, 100);

        _yellowZoneLeft.sizeDelta = new Vector2(yellowZoneWidth, greenZoneHeight);
        _yellowZoneRight.sizeDelta = new Vector2(yellowZoneWidth, greenZoneHeight);
        
        
        if (_greenZoneMinX - _yellowZoneLeft.sizeDelta.x < -150)
        {
            var a = -150 - (_greenZoneMinX - _yellowZoneLeft.sizeDelta.x);
            
            _yellowZoneLeft.sizeDelta = new Vector2(_yellowZoneLeft.sizeDelta.x - a, greenZoneHeight);
        }

        if (_greenZoneMaxX + _yellowZoneRight.sizeDelta.x > 150)
        {
            var a = 150 - (_greenZoneMaxX + _yellowZoneRight.sizeDelta.x);
            _yellowZoneRight.sizeDelta = new Vector2(_yellowZoneRight.sizeDelta.x + a, greenZoneHeight);
        }
        
        _yellowZoneLeft.localPosition = new Vector3(_greenZoneMinX - _yellowZoneLeft.sizeDelta.x / 2, 0, 0);
        _yellowZoneRight.localPosition = new Vector3(_greenZoneMaxX + _yellowZoneRight.sizeDelta.x/2, 0, 0);
        
        _yellowZoneLeftMinX = (_greenZoneMinX - _yellowZoneLeft.sizeDelta.x / 2) - _yellowZoneLeft.sizeDelta.x/2;
        _yellowZoneLeftMaxX = _yellowZoneLeftMinX + _yellowZoneLeft.sizeDelta.x;
        
        _yellowZoneRightMinX = (_greenZoneMaxX + _yellowZoneRight.sizeDelta.x/2) - _yellowZoneRight.sizeDelta.x/2;
        _yellowZoneRightMaxX = _yellowZoneRightMinX + _yellowZoneRight.sizeDelta.x;
    }
    
    public void Switch(EResource resource, bool flag)
    {
        _isOn = flag;
        _progressBarRectTransform.gameObject.SetActive(flag);
        _cursorRectTransform.gameObject.SetActive(flag);
        _greenZoneRectTransform.gameObject.SetActive(flag);
        _button.interactable = flag;
        
        if (flag)
        {
            SetupResourceName(resource);
        }
        else
        {
            SetupNoneResourceName(resource);
        }
    }

    public void UpdateView()
    {
        AdjustZones();
    }
}