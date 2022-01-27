using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateToAnimation : MonoBehaviour
{
    State state;

    public void setState(State state){
        this.state = state;
    }
    public void AnimationTrigger(){
        state.AnimationTrigger();
    }

    public void AnimationFinishTrigger(){
        state.AnimationFinishTrigger();
    }
}
