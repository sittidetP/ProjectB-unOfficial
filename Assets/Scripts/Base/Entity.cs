using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine StateMachine { get; private set; }

    public Animator Animator { get; private set; }

    public Core Core { get; private set; }

    public StateToAnimation StateToAnimation {get; private set;}
    public SpriteRenderer SpriteRenderer{get; private set;}

    private Vector2 workspace;

    public virtual void Awake() {
        Core = GetComponentInChildren<Core>();
        StateMachine = new FiniteStateMachine();
        Animator = GetComponent<Animator>();
        StateToAnimation = GetComponent<StateToAnimation>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void Update(){
        Core.LogicUpdate();

        if(StateMachine.currentState != null)
        {
            StateMachine.currentState.LogicUpdate();
        }
    }

    public virtual void FixedUpdate(){
        if (StateMachine.currentState != null)
        {
            StateMachine.currentState.PhysicsUpdate();
        }
    }
}
