using System;
using UnityEngine;
public class SafeAreaDetection : MonoBehaviour
{
    public static Action<Rect> OnSafeAreaChanged;
    private Rect _safeArea;
    private void Awake()
    {
        _safeArea = Screen.safeArea;
    }

    private void Update()
    {
        if (_safeArea != Screen.safeArea)
        {
            _safeArea = Screen.safeArea;
            OnSafeAreaChanged?.Invoke(_safeArea);
        }
    }
}