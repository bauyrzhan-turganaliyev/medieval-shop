using System;

public class MessageBus
{
    public Action<EMode> OnModeChanged;
    public Action OnResourceCountChanged;
    public Action OnInventoryUpdate;
}