using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeadState : BaseDeadState
{
    Enemy1 enemy1;
    int enterTime = 0;

    public E1_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ItemDroper itemDroper, Enemy1 enemy1) : base(entity, stateMachine, animBoolName, itemDroper)
    {
        this.enemy1 = enemy1;
    }

    public override void Enter()
    {
        base.Enter();
        enterTime++;
        if(enterTime == 1){
            enemy1.AudioSource.PlayOneShot(enemy1.DeadSFX);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        itemDroper.DropItem(enemy1.transform);
        entity.gameObject.SetActive(false);
    }
}
