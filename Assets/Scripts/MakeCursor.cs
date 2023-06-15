using System;
using UnityEngine;

public class MakeCursor : MonoBehaviour
{
    public Action<bool> OnGreenZoneOn;
    public RectTransform RectTransform;
    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.localPosition;
    }

    public void Reset()
    {
        RectTransform.localPosition = _initialPosition;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnGreenZoneOn?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnGreenZoneOn?.Invoke(false);
    }
}