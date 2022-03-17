using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_RangeAttackState : BaseRangeAttackState
{
    Boss2 boss2;
    public B2_RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseRangeAttackStateData rangeAttackStateData, Transform rangeAttackPosition, Boss2 boss2) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, rangeAttackStateData, rangeAttackPosition)
    {
        this.boss2 = boss2;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        
        if(!canAttack){
            stateMachine.ChangeState(boss2.MoveState);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        if(IsPlayerBehind()){
            core.Movement.Filp();
        }
    }

    
}
