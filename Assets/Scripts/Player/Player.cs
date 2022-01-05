using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerMidAirState MidAirState { get; private set; }

    public PlayerDashState DashState { get; private set; }

    public PlayerAttackState PrimaryAttackState { get; private set; }

    public PlayerWaitState WaitState { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    [SerializeField] PlayerStateData playerStateData;

    public PlayerInventory Inventory { get; private set; }
    public ExtraPlayer ExtraPlayer { get; private set; }

    public override void Awake()
    {
        base.Awake();

        InputHandler = GetComponent<PlayerInputHandler>();
        

        IdleState = new PlayerIdleState(this, StateMachine, "idle", playerStateData);
        MoveState = new PlayerMoveState(this, StateMachine, "move", playerStateData);
        JumpState = new PlayerJumpState(this, StateMachine, "midAir", playerStateData);
        MidAirState = new PlayerMidAirState(this, StateMachine, "midAir", playerStateData);
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, "attack", playerStateData);
        DashState = new PlayerDashState(this, StateMachine, "dash", playerStateData);
        WaitState = new PlayerWaitState(this, StateMachine, "wait", playerStateData);
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);

        Inventory = GetComponent<PlayerInventory>();
        ExtraPlayer = GetComponentInChildren<ExtraPlayer>();

        PrimaryAttackState.SetWeapon(Inventory.weapons[0]);
    }
}
