using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : Enemy
{
    public B3_IdleState IdleState {get; private set;}
    public B3_MoveState MoveState {get; private set;}
    public B3_MeleeAttackState MeleeAttackState {get; private set;}
    public B3_RangeAttackState RangeAttackState1 {get; private set;}
    public B3_RangeAttackState RangeAttackState2 {get; private set;}
    public B3_DeadState DeadState {get; private set;}
    [Header("States Data")]
    [SerializeField] BaseArgoStateData argoStateData;
    [SerializeField] BaseIdleStateData idleStateData;
    
    [SerializeField] BaseMoveStateData moveStateData;
    
    [SerializeField] BaseHurtStateData hurtStateData;
    
    [SerializeField] BaseMeleeAttackStateData meleeAttackStateData;
    [SerializeField] BaseRangeAttackStateData rangeAttackState1Data;
    [SerializeField] BaseRangeAttackStateData rangeAttackState2Data;
    /*
    [SerializeField] BaseMeleeAttackStateData tackleStateData;
    */
    [Header("Other Objects")]
    [SerializeField] Transform enemyEye;
    [SerializeField] Transform meleeHitboxPosition;
    [SerializeField] Transform rangeAttackPosition;
    [SerializeField] int debugFacing = 1;
    [SerializeField] AudioClip deadSFX;
    public AudioClip DeadSFX {get => deadSFX;}
    float gizmosDrawRadius = 0.25f;
    Material normalMaterial;
    bool isHurt;
    float startTime;

    public override void Awake()
    {
        base.Awake();

        IdleState = new B3_IdleState(this, StateMachine, "idle", argoStateData, enemyEye, idleStateData, this);
        MoveState = new B3_MoveState(this, StateMachine, "move", argoStateData, enemyEye, moveStateData, this);
        MeleeAttackState = new B3_MeleeAttackState(this, StateMachine, "attack", argoStateData, enemyEye, meleeHitboxPosition, meleeAttackStateData, this);
        RangeAttackState1 = new B3_RangeAttackState(this, StateMachine, "shoot", argoStateData, enemyEye, meleeHitboxPosition, rangeAttackState1Data, rangeAttackPosition, this);
        RangeAttackState2 = new B3_RangeAttackState(this, StateMachine, "shoot", argoStateData, enemyEye, meleeHitboxPosition, rangeAttackState2Data, rangeAttackPosition, this);
        DeadState = new B3_DeadState(this, StateMachine, "dead", itemDroper, this);
        /*
        MeleeAttackState = new B1_MeleeAttackState(this, StateMachine, "attack", argoStateData, enemyEye, meleeHitboxPosition, meleeAttackStateData, this);
        TackleState = new B1_MeleeAttackState(this, StateMachine, "attack", argoStateData, enemyEye, meleeHitboxPosition, tackleStateData, this);
        HurtState = new B1_HurtState(this, StateMachine, "hurt", hurtStateData, SpriteRenderer, this);
        
        */
    }
    void Start()
    {
        normalMaterial = SpriteRenderer.material;
        StateMachine.Initialize(MoveState);
    }

    public override void Update()
    {
        base.Update();

        if(Core.Stats.getIsDead()){
            StateMachine.ChangeState(DeadState);
        }else if(Core.Combat.getIsDamaged()){
            BlinkWhenDamaged();
            //StateMachine.ChangeState(HurtState);
        }
    }

    private void BlinkWhenDamaged(){
        if(!isHurt){
            AudioSource.PlayOneShot(hurtStateData.hitSFX);
            startTime = Time.time;
            isHurt = true;
        }
        if(isHurt && Time.time > startTime + hurtStateData.hurtDuration){
            SpriteRenderer.material = normalMaterial;
            Core.Combat.setIsNotDamage();
            isHurt = false;
        }else if(isHurt && Time.time <= startTime + hurtStateData.hurtDuration) {
            SpriteRenderer.material = hurtStateData.hurtMaterial;
        }
    }

    private void OnDrawGizmos() {
        

        if(Core != null){
            debugFacing = Core.Movement.FacingDirection;
        }
        
        Gizmos.color = Color.white;
        if(enemyEye != null){
            Gizmos.DrawWireSphere(enemyEye.position + new Vector3(argoStateData.minArgoDistance * debugFacing, 0.0f, 0.0f), gizmosDrawRadius);
            Gizmos.DrawWireSphere(enemyEye.position + new Vector3(argoStateData.maxArgoDistance * debugFacing, 0.0f, 0.0f), gizmosDrawRadius);
        }
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeHitboxPosition.position, meleeAttackStateData.HitboxRadius);
        
        Gizmos.color = Color.blue;
        if(enemyEye != null){
            Gizmos.DrawLine(enemyEye.position, enemyEye.position + (Vector3)Vector2.right * debugFacing * argoStateData.closeToPlayerDistance);
        }
        
    }
}
