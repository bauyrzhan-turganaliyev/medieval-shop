using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var messageBus = new MessageBus();
        Container.Bind<MessageBus>().FromInstance(messageBus).NonLazy();
    }
}