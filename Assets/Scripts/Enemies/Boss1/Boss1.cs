using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{
    public B1_IdleState IdleState {get; private set;}
    public B1_MoveState MoveState {get; private set;}

    [Header("States Data")]
    [SerializeField] BaseArgoStateData argoStateData;
    [SerializeField] BaseIdleStateData idleStateData;
    [SerializeField] BaseMoveStateData moveStateData;

    [Header("Other Objects")]
    [SerializeField] Transform enemyEye;
    [SerializeField] Transform meleeHitboxPosition;
    [SerializeField] int debugFacing = 1;
    float gizmosDrawRadius = 0.25f;

    public override void Awake()
    {
        base.Awake();

        IdleState = new B1_IdleState(this, StateMachine, "idle", argoStateData, enemyEye, idleStateData, this);
        MoveState = new B1_MoveState(this, StateMachine, "move", argoStateData, enemyEye, moveStateData, this);

    }
    // Start is called before the first frame update
    void Start()
    {
        StateMachine.Initialize(MoveState);
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
        /*
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeHitboxPosition.position, meleeAttackStateData.HitboxRadius);
        */
        Gizmos.color = Color.blue;
        if(enemyEye != null){
            Gizmos.DrawLine(enemyEye.position, enemyEye.position + (Vector3)Vector2.right * debugFacing * argoStateData.closeToPlayerDistance);
        }
    }
}
