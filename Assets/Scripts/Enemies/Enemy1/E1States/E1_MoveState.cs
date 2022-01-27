using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : BaseMoveState
{
    Enemy1 enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseMoveStateData stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > startTime + stateData.moveDuration|| !isGroundedL)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }else if(canPerformCloseRangeAction && enemy.MeleeState.getCanAttack()){
            stateMachine.ChangeState(enemy.MeleeState);
        }
    }
}
