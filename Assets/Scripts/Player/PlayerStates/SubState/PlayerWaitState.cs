using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitState : PlayerState
{
    private float enterTime;
    private float xInput;

    private bool isGround;
    private bool primaryAttackInput;
    public PlayerWaitState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGround = core.CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();
        player.PrimaryAttackState.SetFalseIsJustAttack();
        enterTime = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        /*
        if(isGround){
            core.Movement.RB.sharedMaterial = player.defaultPhysicsMat;
        }
        */
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        primaryAttackInput = player.InputHandler.PrimaryAttackInput;

        
        if (Time.time > enterTime + player.PrimaryAttackState.Weapon.WaitAttackDuration)
        {
            //Debug.Log("Finish");
            player.PrimaryAttackState.Weapon.SetZeroAttackCounter();
            player.PrimaryAttackState.Weapon.SetAnimationFalse();
            player.PrimaryAttackState.Weapon.SetWeaponActiveFalse();
            
            if (isGround)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                stateMachine.ChangeState(player.MidAirState);
            }
            

        }
        else
        {
            //Debug.Log("not Finish");
            if (primaryAttackInput)
            {
                player.PrimaryAttackState.Weapon.SetAnimationFalse();
                stateMachine.ChangeState(player.PrimaryAttackState);
            }else if(xInput != 0)
            {
                player.PrimaryAttackState.Weapon.SetZeroAttackCounter();
                player.PrimaryAttackState.Weapon.SetAnimationFalse();
                player.PrimaryAttackState.Weapon.SetWeaponActiveFalse();

                if (isGround)
                {
                    stateMachine.ChangeState(player.MoveState);
                }
                else
                {
                    stateMachine.ChangeState(player.MidAirState);
                }
                
            }
            
        }
    }
}
