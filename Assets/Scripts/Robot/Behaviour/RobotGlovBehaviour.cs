using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGlovBehaviour : MonoBehaviour, IRobotBehaviour
{
    [SerializeField] private GameObject cub;
    public void Activate(Action onActivated, params object[] param)
    {
        cub.SetActive(true);
    }

    public void DeActivate(Action onDeActivated, params object[] param)
    {
        cub.SetActive(false);
    }
}
