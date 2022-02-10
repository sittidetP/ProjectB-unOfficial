using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttackState : BaseArgoState
{
    protected Transform attackPosition;

    public BaseAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye,Transform attackPosition) : base(entity, stateMachine, animBoolName, stateData, enemyEye)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();
    }

}
