using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMeleeAttackState : BaseAttackState
{
    private float stopAttactTime;
    protected bool canAttack = true;
    protected BaseMeleeAttackStateData meleeAttackData;
    public BaseMeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye,Transform attackPosition, BaseMeleeAttackStateData meleeAttackData) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition)
    {
        this.meleeAttackData = meleeAttackData;
    }

    public override void Enter()
    {
        base.Enter();
        //canAttack = true;
        core.Movement.SetVelocityX(meleeAttackData.attackVelocity * core.Movement.FacingDirection);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        //Debug.Log("hit Player");

        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(attackPosition.position, meleeAttackData.HitboxRadius, argoStateData.whatIsPlayer);

        foreach(Collider2D obj in detectedObject){
            IDamageable damageable = obj.GetComponentInChildren<IDamageable>();
            IKnockbackable knockbackable = obj.GetComponentInChildren<IKnockbackable>();
            //Player player = obj.GetComponent<Player>();
            if(damageable != null){
                //Debug.Log("player not null");
                damageable.Damage(meleeAttackData.attackDamage);
                knockbackable.Knockback(meleeAttackData.knockbackAngle, meleeAttackData.knockbackVelocity, core.Movement.FacingDirection);
            }else{
                //Debug.Log("player null");
            }
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        stopAttactTime = Time.time;
        canAttack = false;
    }

    public bool getCanAttack(){
        if(Time.time > stopAttactTime + meleeAttackData.cooldownTime){
            canAttack = true;
        }else{
            canAttack = false;
        }
        return canAttack;
    }
}
