using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_DeadState : BaseDeadState
{
    Boss1 boss1;
    int enterTime = 0;
    public B1_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ItemDroper itemDroper, Boss1 boss1) : base(entity, stateMachine, animBoolName, itemDroper)
    {
        this.boss1 = boss1;
    }

    public override void Enter()
    {
        base.Enter();
        enterTime++;
        if(enterTime == 1){
            boss1.AudioSource.PlayOneShot(boss1.DeadSFX);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        itemDroper.DropItem(boss1.transform);
        //entity.gameObject.SetActive(false);
        GameObject.Destroy(entity.gameObject);
    }
}
