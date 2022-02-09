using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRangeAttackState : BaseAttackState
{
    BaseRangeAttackStateData rangeAttackStateData;
    public BaseRangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseRangeAttackStateData rangeAttackStateData) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition)
    {
        this.rangeAttackStateData = rangeAttackStateData;
    }
}
