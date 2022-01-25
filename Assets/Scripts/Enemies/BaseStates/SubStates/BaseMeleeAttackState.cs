using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMeleeAttackState : BaseAttackState
{
    private float stopAttactTime;
    protected bool canAttack;
    BaseMeleeAttackStateData meleeAttackData;
    public BaseMeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye,Transform attackPosition, BaseMeleeAttackStateData meleeAttackData) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition)
    {
        this.meleeAttackData = meleeAttackData;
    }

    public override void Enter()
    {
        base.Enter();
        canAttack = true;
        core.Movement.SetVelocityX(meleeAttackData.attackVelocity);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        //Debug.Log("hit Player");

        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(attackPosition.position, meleeAttackData.HitboxRadius, argoStateData.whatIsPlayer);

        foreach(Collider2D obj in detectedObject){
            IDamageable damageable = obj.GetComponent<IDamageable>();

            if(damageable != null){
                damageable.Damage(meleeAttackData.attackDamage);
            }
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > stopAttactTime + meleeAttackData.cooldownTime){
            isAnimationFinished = false;
            canAttack = true;
        }
    }

    public override void Exit()
    {
        base.Exit();

        canAttack = false;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        stopAttactTime = Time.time;
        canAttack = false;
    }
}
