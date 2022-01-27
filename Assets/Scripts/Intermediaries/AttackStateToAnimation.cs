using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateToAnimation : MonoBehaviour
{
    BaseAttackState attackState;

    public void setAttackState(BaseAttackState attackState){
        this.attackState = attackState;
    }
    public void AttackAnimationTrigger(){
        attackState.AnimationTrigger();
    }

    public void AttackAnimationFinishTrigger(){
        attackState.AnimationFinishTrigger();
    }
}
