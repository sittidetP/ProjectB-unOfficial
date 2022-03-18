using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_WrapState : BaseWrapState
{
    Boss2 boss2;
    public B2_WrapState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseWrapStateData wrapStateData, Boss2 boss2) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, wrapStateData)
    {
        this.boss2 = boss2;
    }

    public override void Enter()
    {
        base.Enter();

        if(wrapStateData.wrapSFX != null){
            boss2.AudioSource.PlayOneShot(wrapStateData.wrapSFX);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished){
            stateMachine.ChangeState(boss2.IdleState);
        }
    }
}
