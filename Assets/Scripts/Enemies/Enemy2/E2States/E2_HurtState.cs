using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_HurtState : BaseHurtState
{
    Enemy2 enemy2;
    public E2_HurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseHurtStateData hurtStateData, SpriteRenderer sr, Enemy2 enemy2) : base(entity, stateMachine, animBoolName, hurtStateData, sr)
    {
        this.enemy2 = enemy2;
    }

    public override void Enter()
    {
        base.Enter();

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
            stateMachine.ChangeState(enemy2.MoveState);
        }
    }

}
