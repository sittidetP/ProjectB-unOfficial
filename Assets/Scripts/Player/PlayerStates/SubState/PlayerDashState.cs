using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    private float startDash;
    private float onMidAirTime;
    private float endMidAirTime;

    private bool isDashFromGround; //Check Dash From Ground to MidAir
    private bool isDashOnGround; //Check Dash on Ground or MidAir when start to dash

    private Vector2 lastAfterImagePos;

    private float playerGScale;
    public bool IsJustDash { get; private set; }
    public PlayerDashState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
        IsJustDash = false;

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
    }

    public override void Enter()
    {
        base.Enter();
        playerGScale = core.Movement.RB.gravityScale;
        player.InputHandler.UseDashInput();
        startDash = Time.time;
        if (core.CollisionSenses.Ground)
        {
            Debug.Log("dash on ground");
            isDashOnGround = true;
            if (isGrounded)
            {
                isDashFromGround = true;
            }
            else
            {
                isDashFromGround = false;
            }
        }else{
            Debug.Log("dash on midair");
            isDashOnGround = false;
            isDashFromGround = false;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isGrounded)
        {
            core.Movement.RB.gravityScale = 0f;
        }


        if (!isGrounded && isDashFromGround && isDashOnGround)
        {
            onMidAirTime = Time.time;
            isDashFromGround = false;
        }

        if (Time.time >= startDash + playerStateData.dashDuration)
        {
            core.Movement.RB.drag = 0f;
            if (!isGrounded && isDashOnGround)
            {
                endMidAirTime = Time.time;
            }
            core.Movement.RB.gravityScale = playerGScale;
            IsJustDash = true;
            isAbilityDone = true;
        }
        else
        {
            CheckIfShouldPlaceAfterImage();
            core.Movement.SetVelocityX(playerStateData.dashVelocity * core.Movement.FacingDirection);
            core.Movement.RB.drag = playerStateData.dashGLinearDrag;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public bool CheckCoyoteFormDash()
    {
        /*
        Debug.Log("endMidAirTime : " + endMidAirTime);
        Debug.Log("onMidAir : " + onMidAirTime);
        */
        if ((endMidAirTime - onMidAirTime > playerStateData.coyoteTime && isDashOnGround))
        {
            return true; //Can't Coyote
        }
        else
        {
            return false; //Can Coyote
        }
    }

    public void SetFalseIsJustDash()
    {
        IsJustDash = false;
    }

    private void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.GetFromPool();
        lastAfterImagePos = player.transform.position;
    }

    private void CheckIfShouldPlaceAfterImage()
    {
        if (Vector2.Distance(player.transform.position, lastAfterImagePos) >= playerStateData.distBetweenAfterImage)
        {
            PlaceAfterImage();
        }
    }
}
