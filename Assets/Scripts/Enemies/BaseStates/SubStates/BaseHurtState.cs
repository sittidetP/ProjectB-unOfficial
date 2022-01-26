using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHurtState : State
{
    BaseHurtStateData hurtStateData;
    public BaseHurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseHurtStateData hurtStateData) : base(entity, stateMachine, animBoolName)
    {
        this.hurtStateData = hurtStateData;
    }
}
