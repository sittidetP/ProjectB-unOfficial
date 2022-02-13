using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_IdleState : BaseIdleState
{
    Enemy2 enemy2;
    public E2_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, BaseIdleStateData idleStateData, Enemy2 enemy2) : base(entity, stateMachine, animBoolName, stateData, enemyEye, idleStateData)
    {
        this.enemy2 = enemy2;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Debug.Log("isMinArgoRange : " + isMinArgoRange);
        if(isIdleOver)
        {
            core.Movement.Filp();
            stateMachine.ChangeState(enemy2.MoveState);
        }else if(isMinArgoRange && enemy2.RangeState.getCanAttack()){
            stateMachine.ChangeState(enemy2.RangeState);
        }else if(canPerformCloseRangeAction && enemy2.MeleeState.getCanAttack()){
            stateMachine.ChangeState(enemy2.MeleeState);
        }
    }
}
