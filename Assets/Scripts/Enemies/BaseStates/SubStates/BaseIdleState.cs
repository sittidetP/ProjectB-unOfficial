using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIdleState : BaseArgoState
{
    protected BaseIdleStateData idleStateData;

    protected bool isIdleOver;

    public BaseIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, BaseIdleStateData idleStateData) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.idleStateData = idleStateData;
    }

    public override void Enter()
    {
        base.Enter();

        isIdleOver = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(0.0f);

        if(Time.time > startTime + idleStateData.idleTime)
        {
            isIdleOver = true;
        }
    }
}
