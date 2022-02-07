using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player playerEntity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(playerEntity, stateMachine, animBoolName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        //core.Movement.RB.sharedMaterial = player.WithFrictionMat;
        core.Movement.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
        //core.Movement.RB.sharedMaterial = player.defaultPhysicsMat;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xInput != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }else{
            core.Movement.SetVelocityX(xInput);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
