using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_IdleState : BaseIdleState
{
    Boss3 boss3;
    private int useRangeAttack = 0;

    public B3_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, BaseIdleStateData idleStateData, Boss3 boss3) : base(entity, stateMachine, animBoolName, stateData, enemyEye, idleStateData)
    {
        this.boss3 = boss3;
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (canPerformCloseRangeAction)
        {
            if (Time.time > startTime + boss3.DelayTime)
            {

                stateMachine.ChangeState(boss3.MeleeAttackState);
            }

        }
        else if (isIdleOver && !canPerformCloseRangeAction)
        {
            if (useRangeAttack < 2)
            {
                int randInt = Random.Range(0, 2);
                if (randInt == 0)
                {
                    if (boss3.RangeAttackState1.getCanAttack())
                    {
                        useRangeAttack++;
                        stateMachine.ChangeState(boss3.RangeAttackState1);
                    }
                }
                else if (randInt == 1)
                {
                    if (boss3.RangeAttackState2.getCanAttack())
                    {
                        useRangeAttack++;
                        stateMachine.ChangeState(boss3.RangeAttackState2);
                    }
                }
            }else{
                useRangeAttack = 0;
                stateMachine.ChangeState(boss3.JumpState);
            }


        }
        else if (distanceFromPlayer > argoStateData.minArgoDistance)
        {
            //Debug.Log(distanceFromPlayer);
            stateMachine.ChangeState(boss3.MoveState);
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
