using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeadState : State
{
    public BaseDeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        entity.gameObject.SetActive(false);
    }
}
