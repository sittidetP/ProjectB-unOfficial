using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3_JumpState : BaseJumpState
{
    Boss3 boss3;
    public B3_JumpState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseJumpStateData jumpStateData, Boss3 boss3) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, jumpStateData)
    {
        this.boss3 = boss3;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isJumpOver)
        {
            stateMachine.ChangeState(boss3.MoveState);
            /*
            if (isGrounded)
            {
                
            }
            */
        }
    }
}
