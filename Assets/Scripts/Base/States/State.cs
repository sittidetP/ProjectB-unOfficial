using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FiniteStateMachine stateMachine;
    protected Core core;
    protected Entity entity;

    protected float startTime;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    private string animBoolName;

    public State(Entity entity,FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.core = entity.Core;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        //Debug.Log(entity.transform.name + " : " + animBoolName);
        entity.Animator.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        entity.Animator.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
    }

    public string getAnimBoolName()
    {
        return animBoolName;
    }

}
