using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private float jumpBootsVelocity;

    private int amountOfJumpLeft;
    private float startJumpTime;
    public PlayerJumpState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
        amountOfJumpLeft = playerStateData.amountOfJump;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        startJumpTime = Time.time;
        player.OnPlaySFX?.Invoke(playerStateData.jumpSFX);
        player.InputHandler.UseJumpInput();
        /*
        if (player.DashState.IsJustDash)
        {
            //Debug.Log("dash and jump");
            core.Movement.SetVelocityXY(player.InputHandler.NormInputX * playerStateData.moveVelocity, playerStateData.jumpVelocity);
            player.DashState.SetFalseIsJustDash();
        }
        else
        {
            
        }
        */
        core.Movement.SetVelocityY(playerStateData.jumpVelocity);
        player.MidAirState.SetIsJumping();
        amountOfJumpLeft--;
        isAbilityDone = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //Debug.Log(jumpBootsVelocity);
        /*
        if (player.InputHandler.JumpInputHeld)
        {
            //Debug.Log("JumpInput Hold");
            jumpBootsVelocity += core.Movement.CurrentVelocity.y * playerStateData.jumpBootsMultipiler * Time.deltaTime;
            //Debug.Log(jumpBootsVelocity);
            core.Movement.SetVelocityY(jumpBootsVelocity);
        }
        else if (!player.InputHandler.JumpInputHeld)
        {
            
            if(jumpBootsVelocity > 0f)
            {
                jumpBootsVelocity -= core.Movement.CurrentVelocity.y * playerStateData.jumpBootsMultipiler * Time.deltaTime;
                core.Movement.SetVelocityY(jumpBootsVelocity);
            }
            
            //Debug.Log("JumpInput not Hold");
            isAbilityDone = true;
        }
        */
        /*
        if (player.ExtraPlayer.Ceiling)
        {
            core.Movement.SetVelocityY(0f);
            isAbilityDone = true;
        }
        */

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool CanJump()
    {
        if(amountOfJumpLeft > 0)
        {
            return true;
        }
        else
        {
            //player.InputHandler.UseJumpInput();
            return false;
        }
    }

    public void ResetAmountOfJumpLeft()
    {
        amountOfJumpLeft = playerStateData.amountOfJump;
    }
    public void DecreaseAmountOfJump()
    {
        amountOfJumpLeft--;
    }
}
