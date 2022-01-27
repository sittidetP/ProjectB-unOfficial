using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMidAirState : PlayerState
{
    protected int xInput;
    protected bool jumpInput;
    protected bool primaryAttackInput;
    protected bool dashInput;

    bool isGrounded;
    float yVelocity;

    private bool isJumping;

    private float fallVelocity;
    private float startCoyoteTime;
    public PlayerMidAirState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = core.CollisionSenses.Ground;
        yVelocity = core.Movement.RB.velocity.y;
    }

    public override void Enter()
    {
        base.Enter();
        fallVelocity = 0f;
        startCoyoteTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();

        isGrounded = false;
        player.Animator.SetFloat("yVelocity", playerStateData.jumpVelocity);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        primaryAttackInput = player.InputHandler.PrimaryAttackInput;
        dashInput = player.InputHandler.DashInput;

        //CheckJumpHeld();
        if (primaryAttackInput)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }

        if(dashInput){
            stateMachine.ChangeState(player.DashState);
        }

        if (isGrounded && yVelocity < 0.01f)
        {
            //Debug.Log("MidAir : isGround");
            stateMachine.ChangeState(player.IdleState);
        } else if (jumpInput && player.JumpState.CanJump() && CheckCanCoyote())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else
        {
            if (core.Movement.RB.velocity.y < playerStateData.jumpVelocityFalloffs && !isJumping)
            {
                fallVelocity += Physics2D.gravity.y * playerStateData.fallMultipiler * Time.deltaTime;
            }
            else
            {
                fallVelocity = core.Movement.CurrentVelocity.y;
            }

            core.Movement.SetVelocityXY(xInput * playerStateData.moveVelocity, fallVelocity);
            core.Movement.CheckIfShouldFilp(xInput);

            
            player.Animator.SetFloat("yVelocity", core.Movement.RB.velocity.y);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private bool CheckCanCoyote() {
        /*
        Debug.Log("Time : " + Time.time);
        Debug.Log("CT : " + startCoyoteTime + playerStateData.coyoteTime);
        Debug.Log("CheckCoyoteFormDash : " + player.DashState.CheckCoyoteFormDash());
        */
        if(Time.time > startCoyoteTime + playerStateData.coyoteTime || player.DashState.CheckCoyoteFormDash())
        {
            player.JumpState.DecreaseAmountOfJump();
            return false;
        }
        else
        {
            return true;
        }
    }

}
