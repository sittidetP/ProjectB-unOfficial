using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIdleState : BaseArgoState
{
    protected BaseIdleStateData idleStateData;

    protected bool isIdleOver;
    protected bool isPlayerClosed;

    public BaseIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, BaseIdleStateData idleStateData) : base(entity, stateMachine, animBoolName, stateData, enemyEye)
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
