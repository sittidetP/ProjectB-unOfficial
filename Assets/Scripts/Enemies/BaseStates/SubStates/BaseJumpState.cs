using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJumpState : BaseArgoState
{
    public BaseJumpState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye)
    {
    }
}
