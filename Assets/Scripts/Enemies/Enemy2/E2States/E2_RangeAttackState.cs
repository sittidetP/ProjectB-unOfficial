using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_RangeAttackState : BaseRangeAttackState
{
    Enemy2 enemy2;
    public E2_RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseRangeAttackStateData rangeAttackStateData, Transform rangeAttackPosition, Enemy2 enemy2) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, rangeAttackStateData, rangeAttackPosition)
    {
        this.enemy2 = enemy2;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!canAttack){
            stateMachine.ChangeState(enemy2.MoveState);
        }
    }
}
