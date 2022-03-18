using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWrapState : BaseArgoState
{
    public BaseWrapState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye)
    {
    }

    public override void Enter()
    {
        base.Enter();

        entity.transform.position = playerTransform.position;
    }
}
