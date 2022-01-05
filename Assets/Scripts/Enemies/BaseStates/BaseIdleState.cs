using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIdleState : State
{
    protected BaseIdleStateData stateData;

    public BaseIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseIdleStateData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(0.0f);
    }
}
