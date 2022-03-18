using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWrapState : BaseArgoState
{
    protected BaseWrapStateData wrapStateData;
    private float wrapTime;
    private float startCountdown;
    protected bool canWrap;

    public BaseWrapState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData argoStateData, Transform enemyEye, BaseWrapStateData wrapStateData) : base(entity, stateMachine, animBoolName, argoStateData, enemyEye)
    {
        this.wrapStateData = wrapStateData;
    }

    public override void Enter()
    {
        base.Enter();
        wrapTime = Time.time;
        
        if(playerTransform != null){
            entity.transform.position = playerTransform.position;
        }
    }

    public bool getCountdown(){
        if(Time.time > startCountdown + wrapStateData.CountdownTime){
            canWrap = true;
        }else{
            canWrap = false;
        }
        return canWrap;
    }

    public void StartCountdownTime(){
        startCountdown = Time.time;
    }
}
