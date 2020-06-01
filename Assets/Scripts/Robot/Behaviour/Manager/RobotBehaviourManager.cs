using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RobotBehaviourManager : MonoBehaviour, IRobotBehaviourManager
{
    private IRobotBehaviour[] _behaviourArray;

    void Awake()
    {
        Initialize(GetComponentsInChildren<IRobotBehaviour>());
    }

    public void Initialize(IRobotBehaviour[] behaviourArray)
    {
        _behaviourArray = behaviourArray;
    }

    public IRobotBehaviour SelectBehaviour(Type typeBehaviour)
    {
        return _behaviourArray.First(x => x.GetType() == typeBehaviour);
    }
}
