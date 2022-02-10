using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRangeAttackState : BaseAttackState
{
    Transform rangeAttackPosition;
    BaseRangeAttackStateData rangeAttackStateData;
    public BaseRangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseRangeAttackStateData rangeAttackStateData, Transform rangeAttackPosition) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition)
    {
        this.rangeAttackStateData = rangeAttackStateData;
        this.rangeAttackPosition = rangeAttackPosition;
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        GameObject projectile =   GameObject.Instantiate(rangeAttackStateData.Projectile, rangeAttackPosition.position, rangeAttackPosition.rotation);

    }
}
