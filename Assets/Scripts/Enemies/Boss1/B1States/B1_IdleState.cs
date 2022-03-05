using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_IdleState : BaseIdleState
{
    Boss1 boss1;
    public B1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, BaseIdleStateData idleStateData, Boss1 boss1) : base(entity, stateMachine, animBoolName, stateData, enemyEye, idleStateData)
    {
        this.boss1 = boss1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isIdleOver && !canPerformCloseRangeAction){
            if(boss1.TackleState.getCanAttack()){
                stateMachine.ChangeState(boss1.TackleState);
            }
        }else if(canPerformCloseRangeAction && boss1.MeleeAttackState.getCanAttack()){
            stateMachine.ChangeState(boss1.MeleeAttackState);
        }else if(distanceFromPlayer > argoStateData.minArgoDistance){
            //Debug.Log(distanceFromPlayer);
            stateMachine.ChangeState(boss1.MoveState);
        }else if((entity.Core.Movement.FacingDirection == 1 && playerTransform.position.x < entity.transform.position.x) 
        || (entity.Core.Movement.FacingDirection == -1 && playerTransform.position.x >= entity.transform.position.x)){
            //Debug.Log("player on behind");
            entity.Core.Movement.Filp();
            //stateMachine.ChangeState(boss1.MoveState);
        }
    }
}
