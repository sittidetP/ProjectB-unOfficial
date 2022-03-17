using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_DeadState : BaseDeadState
{
    Boss2 boss2;
    int enterTime = 0;
    public B2_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ItemDroper itemDroper, Boss2 boss2) : base(entity, stateMachine, animBoolName, itemDroper)
    {
        this.boss2 = boss2;
    }

    public override void Enter()
    {
        base.Enter();
        enterTime++;
        if(enterTime == 1){
            boss2.AudioSource.PlayOneShot(boss2.DeadSFX);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        //itemDroper.DropItem(boss1.transform);
        //entity.gameObject.SetActive(false);
        GameObject.Destroy(entity.gameObject);
    }
}
