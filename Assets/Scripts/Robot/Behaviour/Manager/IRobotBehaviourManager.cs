
using System;

public interface IRobotBehaviourManager
{
    void Initialize(IRobotBehaviour[] behaviourArray);
    IRobotBehaviour SelectBehaviour(Type behaviourType);
}
