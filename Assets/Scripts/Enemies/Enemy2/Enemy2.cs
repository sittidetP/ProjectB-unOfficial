using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public E2_IdleState IdleState {get; private set;}
    public E2_MoveState MoveState {get; private set;}
    public E2_MeleeAttackState MeleeState {get; private set;}
    public E2_RangeAttackState RangeState {get; private set;}
    public E2_HurtState HurtState {get; private set;}
    public E2_DeadState DeadState {get; private set;}
    [SerializeField] BaseIdleStateData idleStateData;
    [SerializeField] BaseMoveStateData moveStateData;
    [SerializeField] BaseArgoStateData argoStateData;
    [SerializeField] BaseMeleeAttackStateData meleeAttackStateData;
    [SerializeField] BaseRangeAttackStateData rangeAttackStateData;
    [SerializeField] BaseHurtStateData hurtStateData;
    [SerializeField] Transform enemyEye;
    [SerializeField] Transform meleeHitboxPosition;
    [SerializeField] Transform rangeAttackPosition;

    [SerializeField] int debugFacing = 1;
    //AttackStateToAnimation atk2ani;

    float gizmosDrawRadius = 0.25f;
    public override void Awake()
    {
        base.Awake();

        IdleState = new E2_IdleState(this, StateMachine, "idle", argoStateData, enemyEye,idleStateData, this);
        MoveState = new E2_MoveState(this, StateMachine, "move", argoStateData, enemyEye,moveStateData, this);
        MeleeState = new E2_MeleeAttackState(this, StateMachine, "attack", argoStateData, enemyEye, meleeHitboxPosition, meleeAttackStateData, this);
        RangeState = new E2_RangeAttackState(this, StateMachine, "attack", argoStateData, enemyEye, meleeHitboxPosition, rangeAttackStateData, rangeAttackPosition, this);
        HurtState = new E2_HurtState(this, StateMachine, "hurt", hurtStateData, SpriteRenderer, this);
        DeadState = new E2_DeadState(this, StateMachine, "dead", itemDroper, this);
    }

    private void Start()
    {
        //atk2ani = GetComponent<AttackStateToAnimation>();
        //atk2ani.setAttackState(MeleeState);
        StateMachine.Initialize(IdleState);
    }

    public override void Update()
    {
        base.Update();

        if(Core.Stats.getIsDead()){
            StateMachine.ChangeState(DeadState);
        }else if(Core.Combat.getIsDamaged()){
            StateMachine.ChangeState(HurtState);
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
