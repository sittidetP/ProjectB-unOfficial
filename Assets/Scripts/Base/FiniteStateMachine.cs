using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State currentState { get; private set; }

    public void Initialize(State state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        //Debug.Log("currentState : " + currentState.getAnimBoolName());
        currentState.Enter();
    }
}
