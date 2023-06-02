using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private ModeSwitcherService _modeSwitcherService;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private UIService _uiService;
    [SerializeField] private ProcessService _processService;
    private PlayerProgress _playerProgress;

    private void Start()
    {
        _playerProgress = new PlayerProgress();
        
        _modeSwitcherService.Init();
        _playerController.Init();
        _uiService.Init();
        _processService.Init(_playerProgress);
    }
}
