using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveState : State
{
    protected BaseMoveStateData stateData;

    protected bool isGroundedL;
    public BaseMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseMoveStateData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGroundedL = core.CollisionSenses.GroundLeft;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.SetVelocityX(stateData.moveVelocity * core.Movement.FacingDirection);
    }
}
