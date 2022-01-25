using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseArgoState : State
{
    protected BaseArgoStateData argoStateData;

    protected bool isMinArgoRange;
    protected bool isMaxArgoRange;
    protected bool canPerformCloseRangeAction;
    public BaseArgoState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData) : base(entity, stateMachine, animBoolName)
    {
        this.argoStateData = argoStateData;
    }
    public override void DoChecks()
    {
        base.DoChecks();

        isMinArgoRange = Physics2D.Raycast(entity.transform.position, entity.transform.right, argoStateData.minArgoDistance, entity.Core.CollisionSenses.getWhatIsGround());
        isMaxArgoRange = Physics2D.Raycast(entity.transform.position, entity.transform.right, argoStateData.maxArgoDistance, entity.Core.CollisionSenses.getWhatIsGround());
        canPerformCloseRangeAction = Physics2D.Raycast(entity.transform.position, entity.transform.right, argoStateData.closeToPlayerDistance, argoStateData.whatIsPlayer);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        /*
        Debug.Log("canPerformCloseRangeAction : " + canPerformCloseRangeAction);*/
    }
}
