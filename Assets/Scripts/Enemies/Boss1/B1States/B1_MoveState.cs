using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_MoveState : BaseMoveState
{
    Boss1 boss1;
    public B1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseMoveStateData moveStateData, Boss1 boss1) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, moveStateData)
    {
        this.boss1 = boss1;
    }

    public override void Enter()
    {
        base.Enter();

        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(distanceFromPlayer <= argoStateData.minArgoDistance){
            stateMachine.ChangeState(boss1.IdleState);
        }else if((entity.Core.Movement.FacingDirection == 1 && playerTransform.position.x < entity.transform.position.x) 
        || (entity.Core.Movement.FacingDirection == -1 && playerTransform.position.x >= entity.transform.position.x)){
            //Debug.Log("player on behind");
            entity.Core.Movement.Filp();
            //stateMachine.ChangeState(boss1.MoveState);
        }
    }
}
