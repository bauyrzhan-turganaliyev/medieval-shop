using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MakeService : MonoBehaviour
{
    [SerializeField] private MakeView _makeView;
    [SerializeField] private JapckpotWheel _japckpotWheel;
    
    private MessageBus _messageBus;

    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public void Init(PlayerProgress playerProgress)
    {
        _messageBus.OnModeChanged += ModeChanged;
        _makeView.Init(playerProgress);
        _japckpotWheel.Init();
        _makeView.AllPartsPlaced += AllPartsPlaced;
        _japckpotWheel.OnJackpotStopped += JackpotStopped;
        _makeView.OnCreatedForm += FormCreated;
    }

    private void FormCreated()
    {
        _japckpotWheel.CreateWheel();
    }

    private void JackpotStopped(ItemQuality obj)
    {
        _makeView.ItemHasDone("Sword", obj);
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
