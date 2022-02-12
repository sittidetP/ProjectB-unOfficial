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
        /*
        Debug.Log(" Vector2.right * core.Movement.FacingDirection : " +  Vector2.right * core.Movement.FacingDirection);
        Debug.Log("isMinArgoRange : " + isMinArgoRange);
        Debug.Log("isMaxArgoRange : " + isMaxArgoRange);
        */
        if(Time.time > startTime + stateData.moveDuration|| !isRealGround || isFrontWall)
        {
            stateMachine.ChangeState(enemy2.IdleState);
        }else if(isMinArgoRange && enemy2.RangeState.getCanAttack()){
            stateMachine.ChangeState(enemy2.RangeState);
        }else if(canPerformCloseRangeAction && enemy2.MeleeState.getCanAttack()){
            stateMachine.ChangeState(enemy2.MeleeState);
        }
    }
}
