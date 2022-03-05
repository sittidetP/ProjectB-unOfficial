using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_MeleeAttackState : BaseMeleeAttackState
{
    Boss1 boss1;
    public B1_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseMeleeAttackStateData meleeAttackData, Boss1 boss1) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, meleeAttackData)
    {
        this.boss1 = boss1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!canAttack){
            stateMachine.ChangeState(boss1.MoveState);
        }
    }
}
