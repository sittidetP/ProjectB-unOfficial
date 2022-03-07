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
    [SerializeField] private float damageCooldown = 0.2f;
    private float damageTime;

    private bool isAttackedFromBehind = false;
    
    public override void LogicUpdate(){
        CheckKnockback();
        CheckCanDamage();
    }

    public void Damage(float amount)
    {
        //print(canDamage);   
        if(canDamage){
            damageTime = Time.time;
            //Debug.Log("Can Hit");
            isDamged = true;
            core.Stats.DecreaseHealth(amount);
            canDamage = false;
        }else{
            //isDamged = false;
            //Debug.Log("Can't Hit");
        }
    }

    public void CheckCanDamage(){
        if(Time.time > damageTime + damageCooldown){
            canDamage = true;
        }else{
            canDamage = false;
        }
    }

    public void Damage(float amount, int attackedDirection){
        Damage(amount);
        if(attackedDirection == core.Movement.FacingDirection){
            //Debug.Log("Behind true");
            isAttackedFromBehind = true;
        }else{
            //Debug.Log("Behind false");
            isAttackedFromBehind = false;
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

    public bool getIsAttackedFormBehind(){
        return isAttackedFromBehind;
    }

    public float getDamageCoolDown(){
        return damageCooldown;
    }
}
