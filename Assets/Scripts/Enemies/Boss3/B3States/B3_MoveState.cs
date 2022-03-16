using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_MoveState : BaseMoveState
{
    Boss3 boss3;
    public B3_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseMoveStateData moveStateData, Boss3 boss3) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, moveStateData)
    {
        this.boss3 = boss3;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(distanceFromPlayer <= argoStateData.minArgoDistance){
            stateMachine.ChangeState(boss3.IdleState);
        }else if((entity.Core.Movement.FacingDirection == 1 && playerTransform.position.x < entity.transform.position.x) 
        || (entity.Core.Movement.FacingDirection == -1 && playerTransform.position.x >= entity.transform.position.x)){
            //Debug.Log("player on behind");
            entity.Core.Movement.Filp();
            //stateMachine.ChangeState(boss1.MoveState);
        }
    }
}
