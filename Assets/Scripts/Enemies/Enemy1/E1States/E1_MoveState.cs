using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : BaseMoveState
{
    Enemy1 enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseMoveStateData stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > startTime + stateData.moveDuration|| !isGroundedL)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }
    }
}
