using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseArgoState : State
{
    protected BaseArgoStateData stateData;

    protected bool isMinArgoRange;
    protected bool isMaxArgoRange;
    public BaseArgoState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
    public override void DoChecks()
    {
        base.DoChecks();

        isMinArgoRange = Physics2D.Raycast(entity.transform.position, entity.transform.right, stateData.minArgoDistance, entity.Core.CollisionSenses.getWhatIsGround());
        isMaxArgoRange = Physics2D.Raycast(entity.transform.position, entity.transform.right, stateData.maxArgoDistance, entity.Core.CollisionSenses.getWhatIsGround());
    }
}
