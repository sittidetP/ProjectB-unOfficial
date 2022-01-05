using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    private bool isKnockbackActive;

    private float knockbackStartTime;

    [SerializeField] private float knockbackTime = 0.2f;
    
    public override void LogicUpdate(){
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        core.Stats.DecreaseHealth(amount);
    }

    public void knockback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    public void CheckKnockback(){
        if(isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.Ground || Time.time >= knockbackStartTime + knockbackTime){
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }
}
