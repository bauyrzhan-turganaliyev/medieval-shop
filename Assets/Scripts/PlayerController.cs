using DefaultNamespace;
using UnityEngine;

public class PlayerController : Pawn
{
    [SerializeField] private DestinationsData _destinationsData;
    
    private MessageBus _messageBus;

    public void Init(MessageBus messageBus)
    {
        _messageBus = messageBus;
        _messageBus.OnMoveTo += MoveTo;
    }

    private async void MoveTo(EDestionation destination)
    {
        var position = _destinationsData.GetPosition(destination);

        print($"Player is going to {destination}");
        
        await MoveAndWaitAsync(position);
        
        print("Player reached the position");
    }
}