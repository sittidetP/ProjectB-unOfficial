using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_IdleState : BaseIdleState
{
    Boss3 boss3;
    public B3_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, BaseIdleStateData idleStateData, Boss3 boss3) : base(entity, stateMachine, animBoolName, stateData, enemyEye, idleStateData)
    {
        this.boss3 = boss3;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isIdleOver && !canPerformCloseRangeAction){
            stateMachine.ChangeState(boss3.RangeAttackState1);
        }else if(canPerformCloseRangeAction && boss3.MeleeAttackState.getCanAttack()){
            stateMachine.ChangeState(boss3.MeleeAttackState);
        }else if(distanceFromPlayer > argoStateData.minArgoDistance){
            //Debug.Log(distanceFromPlayer);
            stateMachine.ChangeState(boss3.MoveState);
        }else if((entity.Core.Movement.FacingDirection == 1 && playerTransform.position.x < entity.transform.position.x) 
        || (entity.Core.Movement.FacingDirection == -1 && playerTransform.position.x >= entity.transform.position.x)){
            //Debug.Log("player on behind");
            entity.Core.Movement.Filp();
            //stateMachine.ChangeState(boss1.MoveState);
        }
    }
}
