using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    public Weapon Weapon { get; private set; }

    private int xInput;

    private float velocityToset;
    private bool canSetVelocity;
    private bool shouldFilp;

    public bool IsJustAttack { get; private set; }
    public PlayerAttackState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        player.InputHandler.UsePrimaryAttackInput();
        if(isGrounded && isOnSlope){
            core.Movement.RB.sharedMaterial = player.WithFrictionMat;
        }
        isAbilityDone = true;
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

        if(isGrounded && isOnSlope){
            core.Movement.RB.sharedMaterial = player.WithFrictionMat;
        }
        IsJustAttack = true;
        canSetVelocity = false;
        Weapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();
        Weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;


        if (shouldFilp)
        {
            core.Movement.CheckIfShouldFilp(xInput);
        }

        if (canSetVelocity)
        {
            core.Movement.SetVelocityX(velocityToset * core.Movement.FacingDirection);
        }

        if(isOnSlope && core.Movement.RB.velocity.y < 0){
            core.Movement.RB.sharedMaterial = player.WithFrictionMat;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetPlayerVelocity(float velocity)
    {
        if(isGrounded && isOnSlope){
            core.Movement.RB.sharedMaterial = player.WithFrictionMat;
        }
        core.Movement.SetVelocityX(velocity * core.Movement.FacingDirection);

        velocityToset = velocity;
        canSetVelocity = true;
    }

    public void SetFilpCheck(bool value)
    {
        shouldFilp = value;
    }

    public void SetWeapon(Weapon weapon)
    {
        this.Weapon = weapon;
        weapon.InitializeWeapon(this, core);
    }

    public void SetFalseIsJustAttack()
    {
        IsJustAttack = false;
    }
}
