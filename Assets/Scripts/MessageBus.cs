using System;

public class MessageBus
{
    public Action<EMode> OnModeChanged;
}