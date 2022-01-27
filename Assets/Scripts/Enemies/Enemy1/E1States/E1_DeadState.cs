using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeadState : BaseDeadState
{
    public E1_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }
}
