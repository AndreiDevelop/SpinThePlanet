using System;
using UnityEngine;

public class RobotGlovBehaviour : MonoBehaviour, IRobotBehaviour
{
    [SerializeField] private GameObject _outline;
    public void Activate(Action onActivated, params object[] param)
    {
        _outline.SetActive(true);
    }

    public void DeActivate(Action onDeActivated, params object[] param)
    {
        _outline.SetActive(false);
    }
}
