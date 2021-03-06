using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_HurtState : BaseHurtState
{
    Enemy1 enemy1;
    public E1_HurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseHurtStateData hurtStateData, SpriteRenderer sr, Enemy1 enemy1) : base(entity, stateMachine, animBoolName, hurtStateData, sr)
    {
        this.enemy1 = enemy1;
    }

    public override void Enter()
    {
        base.Enter();
        enemy1.AudioSource.PlayOneShot(hurtStateData.hitSFX);
        core.Movement.SetVelocityZero();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isHurtOver)
        {
            if (core.Combat.getIsAttackedFormBehind())
            {
                core.Movement.Filp();
            }
            stateMachine.ChangeState(enemy1.MoveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
