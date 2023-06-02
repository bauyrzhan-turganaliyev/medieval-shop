using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private ModeSwitcherService _modeSwitcherService;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private UIService _uiService;

    private void Start()
    {
        _modeSwitcherService.Init();
        _playerController.Init();
        _uiService.Init();
    }
}
