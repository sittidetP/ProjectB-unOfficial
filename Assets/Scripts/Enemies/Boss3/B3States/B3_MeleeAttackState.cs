using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_MeleeAttackState : BaseMeleeAttackState
{
    Boss3 boss3;

    private bool isFinishAttack;
    public B3_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseMeleeAttackStateData meleeAttackData, Boss3 boss3) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, meleeAttackData)
    {
        this.boss3 = boss3;
    }

    public override void Enter()
    {
        base.Enter();
        isFinishAttack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isFinishAttack){
            stateMachine.ChangeState(boss3.MoveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        isFinishAttack = false;
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        boss3.AudioSource.PlayOneShot(meleeAttackData.attackSFX);
        
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isFinishAttack = true;
    }
}
