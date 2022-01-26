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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isHurtOver){
            stateMachine.ChangeState(enemy1.IdleState);
        }
    }
}
