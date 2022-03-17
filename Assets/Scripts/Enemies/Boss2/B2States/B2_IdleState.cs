using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_IdleState : BaseIdleState
{
    Boss2 boss2;
    public B2_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, BaseIdleStateData idleStateData, Boss2 boss2) : base(entity, stateMachine, animBoolName, stateData, enemyEye, idleStateData)
    {
        this.boss2 = boss2;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
