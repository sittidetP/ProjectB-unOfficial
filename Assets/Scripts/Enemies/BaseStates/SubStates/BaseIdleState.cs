using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIdleState : State
{
    protected BaseIdleStateData stateData;

    protected bool isIdleOver;

    public BaseIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseIdleStateData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
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

        if(Time.time > startTime + stateData.idleTime)
        {
            isIdleOver = true;
        }
    }
}
