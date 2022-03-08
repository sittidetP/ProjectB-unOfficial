using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MeleeAttackState : BaseMeleeAttackState
{
    Enemy2 enemy2;
    public E2_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseMeleeAttackStateData meleeAttackData, Enemy2 enemy2) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, meleeAttackData)
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

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        enemy2.AudioSource.PlayOneShot(meleeAttackData.attackSFX);
    }
}
