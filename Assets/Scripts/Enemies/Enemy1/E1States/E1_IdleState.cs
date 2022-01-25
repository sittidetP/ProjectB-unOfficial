using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : BaseIdleState
{
    Enemy1 enemy;
    public E1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData,BaseIdleStateData idleStateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData, idleStateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isIdleOver)
        {
            core.Movement.Filp();
            stateMachine.ChangeState(enemy.MoveState);
        }else if(canPerformCloseRangeAction){
            stateMachine.ChangeState(enemy.MeleeState);
        }
    }
}
