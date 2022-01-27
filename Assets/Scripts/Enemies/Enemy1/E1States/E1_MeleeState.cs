using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MeleeState : BaseMeleeAttackState
{
    Enemy1 enemy1;
    public E1_MeleeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseMeleeAttackStateData meleeAttackData, Enemy1 enemy1) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, meleeAttackData)
    {
        this.enemy1 = enemy1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!canAttack){
            stateMachine.ChangeState(enemy1.MoveState);
        }
    }
}
