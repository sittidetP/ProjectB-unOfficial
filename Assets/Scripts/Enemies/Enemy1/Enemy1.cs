using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState IdleState {get; private set;}
    public E1_MoveState MoveState{get; private set;}

    [SerializeField] BaseIdleStateData idleStateData;
    [SerializeField] BaseMoveStateData moveStateData;
    public override void Awake()
    {
        base.Awake();

        Core.Movement.InitialFacingDirection(-1);

        //Add comment
        IdleState = new E1_IdleState(this, StateMachine, "idle", idleStateData, this);
        MoveState = new E1_MoveState(this, StateMachine, "move", moveStateData, this);
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }
}
