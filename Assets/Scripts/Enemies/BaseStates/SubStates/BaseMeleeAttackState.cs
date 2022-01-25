using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMeleeAttackState : BaseAttackState
{
    BaseMeleeAttackStateData meleeAttackData;
    public BaseMeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform attackPosition, BaseMeleeAttackStateData meleeAttackData) : base(entity, stateMachine, animBoolName, stateData, attackPosition)
    {
        this.meleeAttackData = meleeAttackData;
    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityX(meleeAttackData.attackVelocity);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(attackPosition.position, meleeAttackData.HitboxRadius, argoStateData.whatIsPlayer);

        foreach(Collider2D obj in detectedObject){
            IDamageable damageable = obj.GetComponent<IDamageable>();

            if(damageable != null){
                damageable.Damage(meleeAttackData.attackDamage);
            }
        }
    }
}
