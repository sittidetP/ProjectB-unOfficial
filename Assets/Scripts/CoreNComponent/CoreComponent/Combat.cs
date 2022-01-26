using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    private bool isKnockbackActive;

    private float knockbackStartTime;

    private bool canDamage = true;

    private bool isDamged = false;

    [SerializeField] private float knockbackTime = 0.2f;
    
    public override void LogicUpdate(){
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        if(canDamage){
            Debug.Log("Can Hit");
            isDamged = true;
            core.Stats.DecreaseHealth(amount);
        }else{
            Debug.Log("Can't Hit");
        }
        
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

    public void setCanDamage(bool value){
        canDamage = value;
    }

    public void setIsNotDamage(){
        isDamged = false;
    }

    public bool getIsDamaged(){
        return isDamged;
    }
}
