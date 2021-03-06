using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;

    private bool isGround;
    protected bool jumpInput;
    private bool primaryAttackInput;
    private bool secondaryAttackInput;
    private bool dashInput;

    private float yVelocity;
    public PlayerGroundedState(Player playerEntity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(playerEntity, stateMachine, animBoolName, playerData)
    {

    }
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        
        isGround = core.CollisionSenses.Ground;
        yVelocity = core.Movement.CurrentVelocity.y;
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetAmountOfJumpLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        jumpInput = player.InputHandler.JumpInput;
        primaryAttackInput = player.InputHandler.PrimaryAttackInput;
        secondaryAttackInput = player.InputHandler.SecondaryAttackInput;
        dashInput = player.InputHandler.DashInput;

        if (primaryAttackInput)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (secondaryAttackInput && player.SecondaryAttackState.CanShootRangeWeapon())
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if(jumpInput && player.JumpState.CanJump())
        {
            if(yInput == -1 && player.isOnPlatform){
                player.InputHandler.FallThroughInput = true;
            }else{
                stateMachine.ChangeState(player.JumpState);
            }
        }
        else if(!isGround)
        {
            //Debug.Log("Ground : MidAir");
            player.MidAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.MidAirState);
        }else  if (dashInput && player.DashState.CanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
