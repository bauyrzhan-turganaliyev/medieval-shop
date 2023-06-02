using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private ModeSwitcherService _modeSwitcherService;
    [SerializeField] private PlayerController _playerController;
    private MessageBus _messageBus;

    private void Start()
    {
        _messageBus = new MessageBus();
        _modeSwitcherService.Init(_messageBus);
        _playerController.Init(_messageBus);
    }
}
