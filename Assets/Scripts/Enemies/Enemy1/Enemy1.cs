using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState IdleState {get; private set;}
    public E1_MoveState MoveState{get; private set;}
    public E1_MeleeState MeleeState {get; private set;}

    [SerializeField] BaseIdleStateData idleStateData;
    [SerializeField] BaseMoveStateData moveStateData;
    [SerializeField] BaseArgoStateData argoStateData;
    [SerializeField] BaseMeleeAttackStateData meleeAttackStateData;
    [SerializeField] Transform enemyEye;
    [SerializeField] Transform meleeHitboxPosition;

    AttackStateToAnimation atk2ani;

    float gizmosDrawRadius = 0.25f;
    public override void Awake()
    {
        base.Awake();

        Core.Movement.InitialFacingDirection(-1);

        IdleState = new E1_IdleState(this, StateMachine, "idle", argoStateData, enemyEye,idleStateData, this);
        MoveState = new E1_MoveState(this, StateMachine, "move", argoStateData, enemyEye,moveStateData, this);
        MeleeState = new E1_MeleeState(this, StateMachine, "attack", argoStateData, enemyEye, meleeHitboxPosition, meleeAttackStateData, this);
    }

    private void Start()
    {
        atk2ani = GetComponent<AttackStateToAnimation>();
        atk2ani.setAttackState(MeleeState);
        StateMachine.Initialize(IdleState);
    }

    private void OnDrawGizmos() {
        int facing = -1;

        if(Core != null){
            facing = Core.Movement.FacingDirection;
        }
        Gizmos.color = Color.white;
        if(enemyEye != null){
            Gizmos.DrawWireSphere(enemyEye.position + new Vector3(argoStateData.minArgoDistance * facing, 0.0f, 0.0f), gizmosDrawRadius);
            Gizmos.DrawWireSphere(enemyEye.position + new Vector3(argoStateData.maxArgoDistance * facing, 0.0f, 0.0f), gizmosDrawRadius);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeHitboxPosition.position, meleeAttackStateData.HitboxRadius);

        Gizmos.color = Color.blue;
        if(enemyEye != null){
            Gizmos.DrawLine(enemyEye.position, enemyEye.position + (Vector3)Vector2.right * facing * argoStateData.closeToPlayerDistance);
        }
        
    }
}
