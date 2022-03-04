using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BaseArgoState : State
{
    protected BaseArgoStateData argoStateData;

    protected bool isMinArgoRange;
    protected bool isMaxArgoRange;
    protected bool canPerformCloseRangeAction;

    private Transform enemyEye;
    private Transform playerTransform;
    private BaseArgoStateData stateData;

    public BaseArgoState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye) : base(entity, stateMachine, animBoolName)
    {
        this.argoStateData = argoStateData;
        this.enemyEye = enemyEye;
    }
    
    public override void DoChecks()
    {
        base.DoChecks();

        isMinArgoRange = Physics2D.Raycast(enemyEye.transform.position, Vector2.right * core.Movement.FacingDirection, argoStateData.minArgoDistance, argoStateData.whatIsPlayer);
        isMaxArgoRange = Physics2D.Raycast(enemyEye.transform.position,  Vector2.right * core.Movement.FacingDirection, argoStateData.maxArgoDistance, argoStateData.whatIsPlayer);
        canPerformCloseRangeAction = Physics2D.Raycast(enemyEye.transform.position,  Vector2.right * core.Movement.FacingDirection, argoStateData.closeToPlayerDistance, argoStateData.whatIsPlayer);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        /*
        Debug.Log("isMinArgoRange : " + isMinArgoRange);
        Debug.Log("canPerformCloseRangeAction : " + canPerformCloseRangeAction);
        */
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        playerTransform = GameObject.FindObjectOfType<Player>().transform;
    }
}
