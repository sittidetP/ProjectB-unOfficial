using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : State
{
    Player player;
    public PlayerHurtState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Player player) : base(entity, stateMachine, animBoolName)
    {
        this.player = player;
    }

    
}
