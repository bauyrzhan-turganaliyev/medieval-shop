using UnityEngine;
using Zenject;

public class PlayerController : Pawn
{
    [SerializeField] private DestinationsData _destinationsData;
    
    private MessageBus _messageBus;
    
    [Inject]
    public void Construct(MessageBus messageBus)
    {
        _messageBus = messageBus;
    }
    public void Init()
    {
        _messageBus.OnModeChanged += MoveTo;
    }

    private async void MoveTo(EMode destination)
    {
        var position = _destinationsData.GetPosition(destination);

        print($"Player is going to {destination}");
        
        await MoveAndWaitAsync(position);
        
        print("Player reached the position");
    }
}