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


        if (canPerformCloseRangeAction)
        {
            if (distanceFromPlayer <= boss2.RangeAttack2Distance)
            {
                if (boss2.RangeAttackState2.getCanAttack())
                {
                    stateMachine.ChangeState(boss2.RangeAttackState2);
                }
            }
            else if(distanceFromPlayer > boss2.RangeAttack2Distance && distanceFromPlayer <= argoStateData.closeToPlayerDistance)
            {
                if (boss2.MeleeAttackState.getCanAttack())
                {
                    stateMachine.ChangeState(boss2.MeleeAttackState);
                }
            }
        }
        else if (distanceFromPlayer > argoStateData.closeToPlayerDistance)
        {
            //Debug.Log(distanceFromPlayer);
            stateMachine.ChangeState(boss2.MoveState);
        }
        else if ((entity.Core.Movement.FacingDirection == 1 && playerTransform.position.x < entity.transform.position.x)
      || (entity.Core.Movement.FacingDirection == -1 && playerTransform.position.x >= entity.transform.position.x))
        {
            //Debug.Log("player on behind");
            entity.Core.Movement.Filp();
            //stateMachine.ChangeState(boss1.MoveState);
        }
    }
}
