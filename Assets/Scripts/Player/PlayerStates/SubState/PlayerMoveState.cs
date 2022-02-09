using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player playerEntity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(playerEntity, stateMachine, animBoolName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        core.Movement.CheckIfShouldFilp(xInput);

        if(core.CollisionSenses.isOnSlope){
            core.Movement.SetVelocityXY(playerStateData.moveVelocity * core.CollisionSenses.slopeNormalPrep.x * -xInput,
             playerStateData.moveVelocity * core.CollisionSenses.slopeNormalPrep.y * -xInput);
        }else{
            core.Movement.SetVelocityX(playerStateData.moveVelocity * xInput);
        }

        if(xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
