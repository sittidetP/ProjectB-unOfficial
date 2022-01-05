using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackState : BaseArgoState
{
    protected Transform attackPosition;
    public BaseAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform attackPosition) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.attackPosition = attackPosition;
    }


}
