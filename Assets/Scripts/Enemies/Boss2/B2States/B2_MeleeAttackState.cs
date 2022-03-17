using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_MeleeAttackState : BaseMeleeAttackState
{
    Boss2 boss2;
    public B2_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseMeleeAttackStateData meleeAttackData, Boss2 boss2) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, meleeAttackData)
    {
        this.boss2 = boss2;
    }

    public override void Enter()
    {
        base.Enter();

        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!canAttack){
            stateMachine.ChangeState(boss2.MoveState);
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        boss2.AudioSource.PlayOneShot(meleeAttackData.attackSFX);
    }
}
