using System;
using UnityEngine;

public class MakeCursor : MonoBehaviour
{
    public Action<bool> OnGreenZoneOn;
    public RectTransform RectTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnGreenZoneOn?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnGreenZoneOn?.Invoke(false);
    }
}