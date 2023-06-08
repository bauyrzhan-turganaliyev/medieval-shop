using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MakeView : MonoBehaviour
{
    [SerializeField] private GameObject _partsPanel;
    [SerializeField] private GameObject _makePanel;
    [SerializeField] private GameObject _jackpotPanel;

    [SerializeField] private JapckpotWheel _japckpotWheel;
    
    [SerializeField] private Item _sword;
    
    [SerializeField] private RectTransform _progressBar; 
    [SerializeField] private RectTransform _greenZone;
    [SerializeField] private MakeCursor _cursor;
    
    [SerializeField] private MakeButton _makeButton;
    
    [SerializeField] private float _greenZoneSpeed;
    [SerializeField] private float _cursorSpeed;

    public Action AllPartsPlaced;

    private float _progressBarWidth;
    private float _greenZoneWidth;
    private float _cursorWidth;
    private float _elapsed;

    private bool _isMovingRight;
    private bool _cursorRight;
    private bool _inGreenZone;

    public void Init()
    {
        _progressBarWidth = _progressBar.rect.width;
        _greenZoneWidth = _greenZone.rect.width;
        _cursorWidth = _cursor.RectTransform.rect.width;
        
        _sword.OnAllPartsPlaced += () =>
        {
            _sword.ResetProgressBar();
            AllPartsPlaced?.Invoke();
        };

        _makeButton.OnPressing += SetCursorMode;
        _cursor.OnGreenZoneOn += InGreenZone;
    
        _sword.Init();
        _sword.Reset();
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
            _sword.ProgressBar.fillAmount += 0.1f * Time.deltaTime;
            if (_sword.ProgressBar.fillAmount >= 1)
            {
                End();
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
        _jackpotPanel.gameObject.SetActive(true);
        Reset();
    }

    private void Reset()
    {
        _partsPanel.gameObject.SetActive(true);
        _makePanel.gameObject.SetActive(false);
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
}