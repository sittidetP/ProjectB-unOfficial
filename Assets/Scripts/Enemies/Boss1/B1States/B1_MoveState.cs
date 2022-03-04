using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_MoveState : BaseMoveState
{
    Boss1 boss1;
    public B1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseMoveStateData moveStateData, Boss1 boss1) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye, moveStateData)
    {
        this.boss1 = boss1;
    }

    
}
