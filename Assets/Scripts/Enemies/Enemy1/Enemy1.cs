using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState IdleState {get; private set;}
    public E1_MoveState MoveState{get; private set;}

    [SerializeField] BaseIdleStateData idleStateData;
    [SerializeField] BaseMoveStateData moveStateData;
    [SerializeField] BaseArgoStateData argoStateData;

    [SerializeField] Transform meleeHitboxPosition;
    public override void Awake()
    {
        base.Awake();

        Core.Movement.InitialFacingDirection(-1);

        IdleState = new E1_IdleState(this, StateMachine, "idle", argoStateData, idleStateData, this);
        MoveState = new E1_MoveState(this, StateMachine, "move", moveStateData, this);
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    private void OnDrawGizmos() {
        int facing = -1;

        if(Core != null){
            facing = Core.Movement.FacingDirection;
        }
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + new Vector3(argoStateData.minArgoDistance * facing, 0.0f, 0.0f), 1.0f);
    }
}
