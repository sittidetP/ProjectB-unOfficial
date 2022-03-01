using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeadState : State
{
    protected ItemDroper itemDroper;

    public BaseDeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ItemDroper itemDroper) : base(entity, stateMachine, animBoolName)
    {
        this.itemDroper = itemDroper;
    }

    public override void Enter()
    {
        base.Enter();
    }
}
