using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine StateMachine { get; private set; }

    public Animator Animator { get; private set; }

    public Core Core { get; private set; }

    private Vector2 workspace;

    public virtual void Awake() {
        Core = GetComponentInChildren<Core>();
        StateMachine = new FiniteStateMachine();
        Animator = GetComponent<Animator>();
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
