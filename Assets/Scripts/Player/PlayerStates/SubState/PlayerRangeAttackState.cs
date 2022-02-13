using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttackState : PlayerAbilityState
{
    Transform rangeAttackPos;
    public PlayerRangeAttackState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData, Transform rangeAttackPos) : base(entity, stateMachine, animBoolName, playerData)
    {
        this.rangeAttackPos = rangeAttackPos;
    }

    public override void Enter()
    {
        base.Enter();
        GameObject projectile = GameObject.Instantiate(player.Inventory.getSelectedProjectile(), rangeAttackPos.position, player.Inventory.getSelectedProjectile().transform.rotation);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetUpProjectile(core.Movement.FacingDirection, playerStateData.whatToDamage);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(isGrounded){
            core.Movement.SetVelocityZero();
        }
    }
}
