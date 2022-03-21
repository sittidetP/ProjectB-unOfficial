using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_MoveState : BaseMoveState
{
    Boss2 boss2;
    int startCount = 0;
    public B2_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseMoveStateData moveStateData, Boss2 boss2) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, moveStateData)
    {
        this.boss2 = boss2;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (distanceFromPlayer > argoStateData.maxArgoDistance){
            startCount++;
            if(startCount == 1){
                boss2.WrapState.StartCountdownTime();
            }
            if(boss2.WrapState.getCountdown()){
                stateMachine.ChangeState(boss2.WrapState);
            }
        }else if (distanceFromPlayer > argoStateData.closeToPlayerDistance && distanceFromPlayer <= argoStateData.maxArgoDistance)
        {
            if (boss2.RangeAttackState1.getCanAttack())
            {
                stateMachine.ChangeState(boss2.RangeAttackState1);
            }
        }
        else if (distanceFromPlayer <= argoStateData.minArgoDistance)
        {
            stateMachine.ChangeState(boss2.IdleState);
        }
        else if ((entity.Core.Movement.FacingDirection == 1 && playerTransform.position.x < entity.transform.position.x)
       || (entity.Core.Movement.FacingDirection == -1 && playerTransform.position.x >= entity.transform.position.x))
        {
            //Debug.Log("player on behind");
            entity.Core.Movement.Filp();
            //stateMachine.ChangeState(boss1.MoveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        ResetCount();
    }

    public void ResetCount(){
        startCount = 0;
    }
}
