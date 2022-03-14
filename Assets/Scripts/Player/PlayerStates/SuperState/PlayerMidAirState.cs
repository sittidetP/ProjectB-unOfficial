using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMidAirState : PlayerState
{
    protected int xInput;
    protected bool jumpInput;
    protected bool jumpInputHeld;
    protected bool primaryAttackInput;
    protected bool dashInput;
    protected bool secondaryAttackInput;

    bool isGrounded;
    float yVelocity;

    private bool isJumping;

    private float fallVelocity;
    private float startCoyoteTime;
    private bool canCoyote;
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
        jumpInputHeld = player.InputHandler.JumpInputHeld;
        primaryAttackInput = player.InputHandler.PrimaryAttackInput;
        secondaryAttackInput = player.InputHandler.SecondaryAttackInput;
        dashInput = player.InputHandler.DashInput;

        //CheckJumpHeld();
        CheckJumpMultipiler();
        CheckCanCoyote();
        //Debug.Log(CheckHigherPosJump());
        /*
        if (player.ExtraPlayer.Ceiling ||
        (Time.time > startTime + player.InputHandler.InputHoldTime &&
         player.Core.Movement.RB.velocity.y >= playerStateData.jumpVelocity))
        {
            core.Movement.SetVelocityY(0f);
        }
        */

        if (primaryAttackInput)
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (secondaryAttackInput && player.SecondaryAttackState.CanShootRangeWeapon())
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }


        if (dashInput && player.DashState.CanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }

        if (isGrounded && yVelocity < 0.01f)
        {
            //Debug.Log("MidAir : isGround");
            stateMachine.ChangeState(player.IdleState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            canCoyote = false;
            stateMachine.ChangeState(player.JumpState);
            /*
            if(CheckHigherPosJump()){
                
            }else{
                if(CheckCanCoyote()){
                    stateMachine.ChangeState(player.JumpState);
                }
            }
            */
        }
        else
        {
            /*
            if (core.Movement.RB.velocity.y < playerStateData.jumpVelocityFalloffs && !isJumping)
            {
                fallVelocity += Physics2D.gravity.y * playerStateData.fallMultipiler * Time.deltaTime;
            }
            else
            {
                fallVelocity = core.Movement.CurrentVelocity.y;
            }
            */

            //core.Movement.SetVelocityXY(xInput * playerStateData.moveVelocity, fallVelocity);
            core.Movement.SetVelocityX(xInput * playerStateData.moveVelocity);
            core.Movement.CheckIfShouldFilp(xInput);


            player.Animator.SetFloat("yVelocity", core.Movement.RB.velocity.y);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCanCoyote()
    {
        /*
        Debug.Log("Time : " + Time.time);
        Debug.Log("CT : " + startCoyoteTime + playerStateData.coyoteTime);
        Debug.Log("CheckCoyoteFormDash : " + player.DashState.CheckCoyoteFormDash());
        */
        if (canCoyote && (Time.time > startCoyoteTime + playerStateData.coyoteTime || player.DashState.CheckCoyoteFormDash()))
        {
            player.JumpState.DecreaseAmountOfJump();
            canCoyote = false;
        }
    }

    public void StartCoyoteTime()
    {
        canCoyote = true;
        startCoyoteTime = Time.time;
    }

    public void SetIsJumping() => isJumping = true;

    private void CheckJumpMultipiler()
    {
        if (isJumping)
        {
            if (jumpInputHeld)
            {
                core.Movement.SetVelocityY(core.Movement.CurrentVelocity.y * playerStateData.jumpBootsMultipiler);
                isJumping = false;
            }
            else if (core.Movement.CurrentVelocity.y < 0.01f)
            {
                isJumping = false;
            }
        }
    }

}
