using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_RangeAttackState : BaseRangeAttackState
{
    Boss3 boss3;
    public B3_RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseRangeAttackStateData rangeAttackStateData, Transform rangeAttackPosition, Boss3 boss3) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, rangeAttackStateData, rangeAttackPosition)
    {
        this.boss3 = boss3;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!canAttack){
            stateMachine.ChangeState(boss3.MoveState);
        }
    }
}
