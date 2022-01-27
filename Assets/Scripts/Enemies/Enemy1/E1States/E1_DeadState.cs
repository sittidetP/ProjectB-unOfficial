using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeadState : BaseDeadState
{
    Enemy1 enemy1;
    public E1_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Enemy1 enemy1) : base(entity, stateMachine, animBoolName)
    {
        this.enemy1 = enemy1;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        entity.gameObject.SetActive(false);
    }
}
