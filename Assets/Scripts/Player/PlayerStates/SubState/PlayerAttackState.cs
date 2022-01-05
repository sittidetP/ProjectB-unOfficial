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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetPlayerVelocity(float velocity)
    {
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
