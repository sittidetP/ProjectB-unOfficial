using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_DeadState : BaseDeadState
{
    Enemy2 enemy2;
    int enterTime = 0;
    public E2_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ItemDroper itemDroper, Enemy2 enemy2) : base(entity, stateMachine, animBoolName, itemDroper)
    {
        this.enemy2 = enemy2;
    }

    public override void Enter()
    {
        base.Enter();
        enterTime++;
        if(enterTime == 1){
            enemy2.AudioSource.PlayOneShot(enemy2.DeadSFX);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        itemDroper.DropItem(enemy2.transform);
        entity.gameObject.SetActive(false);
    }
}
