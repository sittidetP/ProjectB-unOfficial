using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.OnPlaySFX?.Invoke(playerStateData.hurtSFX);
        player.Inventory.getSelectedWeapon().SetAnimationFalse();
        player.Inventory.getSelectedWeapon().gameObject.SetActive(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished){
            //Debug.Log("Hurt finish");
            stateMachine.ChangeState(player.IdleState);
        }else{
            core.Movement.SetVelocityX(0);
        }
    }

    public override void Exit()
    {
        base.Exit();
        core.Combat.setIsNotDamage();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        //Debug.Log("Hurt finish");
    }
}
