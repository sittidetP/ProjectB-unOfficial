using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHurtState : State
{
    protected BaseHurtStateData hurtStateData;
    SpriteRenderer sr;
    Material normalMaterial;
    protected bool isHurtOver;
    public BaseHurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseHurtStateData hurtStateData, SpriteRenderer sr) : base(entity, stateMachine, animBoolName)
    {
        this.hurtStateData = hurtStateData;
        this.sr = sr;
        normalMaterial = sr.material;
    }

    public override void Enter()
    {
        base.Enter();

        isHurtOver = false;

        //core.Combat.setCanDamage(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time > startTime + hurtStateData.hurtDuration){
            isHurtOver = true;
        }else{
            sr.material = hurtStateData.hurtMaterial;
        }
    }

    public override void Exit()
    {
        base.Exit();

        sr.material = normalMaterial;
        //core.Combat.setCanDamage(true);
        core.Combat.setIsNotDamage();
    }
}
