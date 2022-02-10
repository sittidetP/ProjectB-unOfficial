using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MoveState : BaseMoveState
{
    Enemy2 enemy2;
    public E2_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseMoveStateData moveStateData, Enemy2 enemy2) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, moveStateData)
    {
        this.enemy2 = enemy2;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > startTime + stateData.moveDuration|| !isRealGround || isFrontWall)
        {
            stateMachine.ChangeState(enemy2.IdleState);
        }else if(canPerformCloseRangeAction && enemy2.MeleeState.getCanAttack()){
            stateMachine.ChangeState(enemy2.MeleeState);
        }
    }
}
