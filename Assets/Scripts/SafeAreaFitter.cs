using UnityEngine;

public class SafeAreaFitter : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        RecalculateSafeArea(Screen.safeArea);
    }

    private void OnEnable()
    {
        SafeAreaDetection.OnSafeAreaChanged += RecalculateSafeArea;
    }
    
    private void RecalculateSafeArea(Rect safeArea)
    {
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;

        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _rectTransform.anchorMin = anchorMin;
        _rectTransform.anchorMax = anchorMax;
    }
}