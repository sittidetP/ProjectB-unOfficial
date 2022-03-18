using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_RangeAttackState : BaseRangeAttackState
{
    Boss2 boss2;
    bool spawnOnPlayer;
    public B2_RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, BaseArgoStateData stateData, Transform enemyEye, Transform attackPosition, BaseRangeAttackStateData rangeAttackStateData, Transform rangeAttackPosition, Boss2 boss2, bool sOnP) : base(entity, stateMachine, animBoolName, stateData, enemyEye, attackPosition, rangeAttackStateData, rangeAttackPosition)
    {
        this.boss2 = boss2;
        spawnOnPlayer = sOnP;
    }

    public override void Enter()
    {
        base.Enter();

        boss2.AudioSource.PlayOneShot(boss2.CastSFX);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        
        if(playerTransform != null && spawnOnPlayer){
            projectile.transform.position = new Vector3(playerTransform.position.x, projectile.transform.position.y, 0.0f);
        }
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        
        if(!canAttack){
            stateMachine.ChangeState(boss2.IdleState);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        if(IsPlayerBehind()){
            core.Movement.Filp();
        }
    }

    
}
