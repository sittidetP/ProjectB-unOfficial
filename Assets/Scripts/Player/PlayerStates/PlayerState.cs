using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected Player player;
    protected PlayerStateData playerStateData;
    public PlayerState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName)
    {
        player = entity;
        this.playerStateData = playerData;
    }
}
