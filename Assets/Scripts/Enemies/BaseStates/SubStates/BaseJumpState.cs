using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJumpState : BaseArgoState
{
    protected BaseJumpStateData jumpStateData;
    protected bool isJumpOver;
    protected bool isGrounded;
    public BaseJumpState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseJumpStateData jumpStateData) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye)
    {
        this.jumpStateData = jumpStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = core.CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();

        isJumpOver = false;

        core.Movement.SetVelocity(jumpStateData.jumpVelocity, jumpStateData.jumpAngle, jumpStateData.jumpDirection * core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + jumpStateData.jumpTime && isGrounded)
        {
            isJumpOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool GetIsDodgeOver()
    {
        return isJumpOver;
    }
}
