using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoveState : BaseArgoState
{
    protected BaseMoveStateData stateData;

    protected bool isGroundedL;
    public BaseMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseMoveStateData moveStateData) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye)
    {
        this.stateData = moveStateData;
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
