using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeItem : MonoBehaviour
{
    public Image ProgressBar;
    
    public void Reset()
    {
        ProgressBar.fillAmount = 0;
    }
}