using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_HurtState : BaseHurtState
{
    Boss1 boss1;
    public B1_HurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseHurtStateData hurtStateData, SpriteRenderer sr, Boss1 boss1) : base(entity, stateMachine, animBoolName, hurtStateData, sr)
    {
        this.boss1 = boss1;
    }

    public override void Enter()
    {
        base.Enter();
        boss1.AudioSource.PlayOneShot(hurtStateData.hitSFX);
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
            stateMachine.ChangeState(boss1.MoveState);
        }
    }
}
