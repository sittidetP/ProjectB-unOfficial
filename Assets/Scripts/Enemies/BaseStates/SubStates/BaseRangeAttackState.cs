using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRangeAttackState : BaseAttackState
{
    Transform rangeAttackPosition;
    BaseRangeAttackStateData rangeAttackStateData;
    protected bool canAttack;
    protected float stopAttactTime;
    public BaseRangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseRangeAttackStateData rangeAttackStateData, Transform rangeAttackPosition) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition)
    {
        this.rangeAttackStateData = rangeAttackStateData;
        this.rangeAttackPosition = rangeAttackPosition;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isAnimationFinished){
            core.Movement.SetVelocityX(0.0f);
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        GameObject projectile = GameObject.Instantiate(rangeAttackStateData.Projectile, rangeAttackPosition.position, rangeAttackStateData.Projectile.transform.rotation);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetUpProjectile(core.Movement.FacingDirection, argoStateData.whatIsPlayer);
        
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        stopAttactTime = Time.time;
        canAttack = false;
    }

    public bool getCanAttack(){
        if(Time.time > stopAttactTime + rangeAttackStateData.CooldownTime){
            canAttack = true;
        }else{
            canAttack = false;
        }
        return canAttack;
    }
}
