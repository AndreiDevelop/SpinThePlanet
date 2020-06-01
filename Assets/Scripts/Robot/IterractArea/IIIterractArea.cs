using System;

public interface IIterractArea
{
    event CustomEventHandler.EventHandler OnEnterArea;
    event CustomEventHandler.EventHandler OnExitArea;

    void SetActivate(bool isActive);
}
