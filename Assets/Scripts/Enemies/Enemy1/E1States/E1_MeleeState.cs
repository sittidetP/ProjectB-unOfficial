using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeState : BaseMeleeAttackState
{
    Enemy1 enemy1;
    public E1_MeleeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform attackPosition, BaseMeleeAttackStateData meleeAttackData, Enemy1 enemy1) : base(entity, stateMachine, animBoolName, stateData, attackPosition, meleeAttackData)
    {
        this.enemy1 = enemy1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!canPerformCloseRangeAction){
            stateMachine.ChangeState(enemy1.IdleState);
        }else if(canAttack){
            stateMachine.ChangeState(enemy1.MeleeState);
        }
    }
}
