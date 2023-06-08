using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PartOfItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Part Part;
    public Action<Transform> OnPartPlaced;
    
    private RectTransform rectTransform;
    private Canvas _canvas;
    private bool _isIn;
    private bool _isInteractable = true;
    private Transform _transformOfIn;
    private Vector3 _initialPosition;
    
    public void Init()
    {
        _initialPosition = transform.position;
        rectTransform = GetComponent<RectTransform>();
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void Reset()
    {
        transform.position = _initialPosition;
        _isIn = false;
        _isInteractable = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isInteractable)
            rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isIn)
        {
            transform.position = _transformOfIn.position;
            _transformOfIn.gameObject.SetActive(false);
            
            _isInteractable = false;
            OnPartPlaced?.Invoke(transform);
        }
        else
        {
            transform.position = _initialPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlaceholderOfItem placeholderOfItem))
        {
            if (placeholderOfItem.Part == Part)
            {
                _transformOfIn = other.gameObject.transform;
                _isIn = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isIn = false;
    }
}

public enum Part
{
    A,
    B,
    C,
    D,
    E
}