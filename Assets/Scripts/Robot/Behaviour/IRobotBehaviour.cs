
using System;

public interface IRobotBehaviour
{
    void Activate(Action onActivated, params object[] param);
    void DeActivate(Action onDeActivated, params object[] param);
}
