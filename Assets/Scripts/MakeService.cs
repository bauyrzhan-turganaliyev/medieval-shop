using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MakeService : MonoBehaviour
{
    [SerializeField] private MakeView _makeView;
    
    private MessageBus _messageBus;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public void Init()
    {
        _messageBus.OnModeChanged += ModeChanged;
        _makeView.Init();
        _makeView.AllPartsPlaced += AllPartsPlaced;
    }

    private void AllPartsPlaced()
    {
        _makeView.MakeMode();
    }

    private void ModeChanged(EMode obj)
    {
        if (obj == EMode.Make)
        {
            _makeView.Switch(true);
        }
    }
}
