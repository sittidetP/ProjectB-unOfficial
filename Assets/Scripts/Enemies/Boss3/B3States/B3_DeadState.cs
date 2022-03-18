using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_DeadState : BaseDeadState
{
    Boss3 boss3;
    int enterTime = 0;
    public B3_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ItemDroper itemDroper, Boss3 boss3) : base(entity, stateMachine, animBoolName, itemDroper)
    {
        this.boss3 = boss3;
    }

    public override void Enter()
    {
        base.Enter();
        enterTime++;
        if(enterTime == 1){
            boss3.AudioSource.PlayOneShot(boss3.DeadSFX);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        itemDroper.DropItem(boss3.transform);
        //entity.gameObject.SetActive(false);
        GameObject.Destroy(entity.gameObject);
    }
}
