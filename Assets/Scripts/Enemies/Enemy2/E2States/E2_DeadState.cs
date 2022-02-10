using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DeadState : BaseDeadState
{
    Enemy2 enemy2;
    public E2_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Enemy2 enemy2) : base(entity, stateMachine, animBoolName)
    {
        this.enemy2 = enemy2;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        entity.gameObject.SetActive(false);
    }
}
