using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Player : Entity
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerMidAirState MidAirState { get; private set; }

    public PlayerDashState DashState { get; private set; }

    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerRangeAttackState SecondaryAttackState { get; private set; }

    public PlayerHurtState HurtState { get; private set; }

    public PlayerWaitState WaitState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    [SerializeField] PlayerStateData playerStateData;
    [SerializeField] Transform rangeAttackPos;
    [SerializeField] UnityEvent<AudioClip> onPlaySFX;
    public UnityEvent<AudioClip> OnPlaySFX {get => onPlaySFX;}
    public PlayerStateData PlayerStateData { get => playerStateData; private set => playerStateData = value; }

    public PlayerInventory Inventory { get; private set; }
    public ExtraPlayer ExtraPlayer { get; private set; }

    public bool isOnPlatform { get; set; }

    private bool selectSecondLeftInput;
    private bool selectSecondRigthInput;
    private bool hpPotionInput;
    private bool mpPotionInput;

    private int unlockJumps = 1;
    public int UnlockJumps {get => unlockJumps;}

    public override void Awake()
    {
        base.Awake();
        //print("player awake");
        InputHandler = GetComponent<PlayerInputHandler>();

        IdleState = new PlayerIdleState(this, StateMachine, "idle", playerStateData);
        MoveState = new PlayerMoveState(this, StateMachine, "move", playerStateData);
        JumpState = new PlayerJumpState(this, StateMachine, "midAir", playerStateData);
        MidAirState = new PlayerMidAirState(this, StateMachine, "midAir", playerStateData);
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, "attack", playerStateData);
        SecondaryAttackState = new PlayerRangeAttackState(this, StateMachine, "shoot", playerStateData, rangeAttackPos);
        DashState = new PlayerDashState(this, StateMachine, "dash", playerStateData);
        WaitState = new PlayerWaitState(this, StateMachine, "wait", playerStateData);
        HurtState = new PlayerHurtState(this, StateMachine, "hurt", playerStateData);
        DeadState = new PlayerDeadState(this, StateMachine, "dead", playerStateData);
    }

    public void Start()
    {
        //print("player start");
        //defaultPhysicsMat = Core.Movement.RB.sharedMaterial;
        StateMachine.Initialize(IdleState);

        Inventory = GetComponent<PlayerInventory>();
        ExtraPlayer = GetComponentInChildren<ExtraPlayer>();

        PrimaryAttackState.SetWeapon(Inventory.weapons[0]);

        if (unlockJumps == 1)
        {
            playerStateData.amountOfJump = 1;
        }
    }

    public override void Update()
    {
        base.Update();
        ExtraPlayer.AlertTextManager.SetTextPosition(transform);
        selectSecondLeftInput = InputHandler.SelectSecondLeftInput;
        selectSecondRigthInput = InputHandler.SelectSecondRightInput;
        hpPotionInput = InputHandler.HPPotionInput;
        mpPotionInput = InputHandler.MPPotionInput;

        UIManager.Instance.SetHPBarValue(Core.Stats.getHPRatio());
        UIManager.Instance.SetMPBarValue(ExtraPlayer.PlayerMana.getMPRatio());

        if (selectSecondLeftInput)
        {
            Inventory.SelectSecondLeft();
            InputHandler.UseSelectSecondLeftInput();
            //Debug.Log(Inventory.getSelectedProjectile().name);
        }
        else if (selectSecondRigthInput)
        {
            Inventory.SelectSecondRigth();
            InputHandler.UseSelectSecondRightInput();
            //Debug.Log(Inventory.getSelectedProjectile().name);
        }

        if (Core.Stats.getIsDead())
        {
            StateMachine.ChangeState(DeadState);
        }
        else if (Core.Combat.getIsDamaged() && !Core.Stats.getAlreadyDead())
        {
            StartCoroutine(FlashAfterDamage());
            StateMachine.ChangeState(HurtState);
        }

        if (hpPotionInput)
        {
            if (Inventory.potions.ContainsKey((int)PotionType.HPPotion))
            {
                Inventory.potions[(int)PotionType.HPPotion].UsePotion();
                InputHandler.UseHPPotionInput();
            }
        }

        if (mpPotionInput)
        {
            if (Inventory.potions.ContainsKey((int)PotionType.MPPotion))
            {
                Inventory.potions[(int)PotionType.MPPotion].UsePotion();
                InputHandler.UseMPPotionInput();
            }
        }
    }


    private IEnumerator FlashAfterDamage()
    {
        float flashDelay = (Core.Combat.getDamageCoolDown()) / playerStateData.amountOfBlinks;
        //yield return new WaitForSeconds(flashDelay);
        //yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < playerStateData.amountOfBlinks; i++)
        {
            yield return new WaitForSeconds(flashDelay);
            SpriteRenderer.color = new Color(1, 1, 1, 0.4f);

            yield return new WaitForSeconds(flashDelay);
            SpriteRenderer.color = Color.clear;

        }

        SpriteRenderer.color = Color.white;
    }

    public void unlockMultipleJump(int jumps)
    {
        unlockJumps = jumps;
        playerStateData.amountOfJump = unlockJumps;
    }

    public void PlayCollectSFX(AudioClip audioClip){
        onPlaySFX?.Invoke(audioClip);
    }

}
