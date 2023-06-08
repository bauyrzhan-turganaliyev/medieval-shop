using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> OnPressing;
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressing?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPressing?.Invoke(false);
    }
}