using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AchievementCollectBehaviour : MonoBehaviour, IAchievementBehaviour
{
    private Animator _animator;

    void Awake()
    {
        Initialize(null);
    }

    public void Activate(Action onFinish)
    {
        _animator.SetTrigger("Collect");
        onFinish?.Invoke();
    }

    public void Deactivate(Action onFinish)
    {
        onFinish?.Invoke();
    }

    public void Initialize(Action onFinish)
    {
        _animator = GetComponent<Animator>();
        Reset(null);

        onFinish?.Invoke();
    }

    public void Reset(Action onFinish)
    {

        onFinish?.Invoke();
    }
}
