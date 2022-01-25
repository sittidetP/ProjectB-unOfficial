using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackState : BaseArgoState
{
    protected Transform attackPosition;

    protected bool isPlayerNotClosed;
    protected bool isPlayerNotMin;
    protected bool isPlayerNotMax;

    public BaseAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform attackPosition) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerNotClosed = false;
        isPlayerNotMin = false;
        isPlayerNotMax = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!canPerformCloseRangeAction){
            isPlayerNotClosed = true;
        }else{
            if(!isMinArgoRange){
                isPlayerNotMin = true;
            }else if(!isMaxArgoRange){
                isPlayerNotMax = true;
            }
        }
    }


}
