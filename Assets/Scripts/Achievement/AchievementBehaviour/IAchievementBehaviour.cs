using System;
public interface IAchievementBehaviour
{
    void Initialize(Action onFinish);
    void Activate(Action onFinish);
    void Deactivate(Action onFinish);
    void Reset(Action onFinish);
}
