using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttackState : PlayerAbilityState
{
    private Transform rangeAttackPos;
    private float lastShootTime;
    private bool secondaryAttackInput;
    private bool canShoot;

    public PlayerRangeAttackState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData, Transform rangeAttackPos) : base(entity, stateMachine, animBoolName, playerData)
    {
        this.rangeAttackPos = rangeAttackPos;
    }

    public override void Enter()
    {
        base.Enter();

        canShoot = true;

        ShootProjectile();

        if (isGrounded)
        {
            core.Movement.SetVelocityZero();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        secondaryAttackInput = player.InputHandler.SecondaryAttackInput;

        if (isGrounded)
        {
            core.Movement.SetVelocityZero();
        }

        if(Time.time > lastShootTime + playerStateData.rangeAttackCooldown){
            canShoot = true;
        }
        
        if (Time.time > lastShootTime + playerStateData.rangeAttackIdleTime || (player.InputHandler.isPressAnykey() && !secondaryAttackInput))
        {
            isAbilityDone = true;
        }
        else if (secondaryAttackInput)
        {
            ShootProjectile();
        }

    }

    private void ShootProjectile()
    {
        if (canShoot)
        {
            GameObject projectile = GameObject.Instantiate(player.Inventory.getSelectedProjectile(), rangeAttackPos.position, player.Inventory.getSelectedProjectile().transform.rotation);
            Projectile projectileScript = projectile.GetComponent<Projectile>();
            projectileScript.SetUpProjectile(core.Movement.FacingDirection, playerStateData.whatToDamage, player.gameObject.layer);
            lastShootTime = Time.time;
            canShoot = false;
            player.InputHandler.UseSecondaryAttackInput();
        }
    }
}
