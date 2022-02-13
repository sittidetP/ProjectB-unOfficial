using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreProjectile : MonoBehaviour
{
    [SerializeField] protected float damageAmount = 6;
    [SerializeField] protected float projectileVelocity = 10f;
    [SerializeField] protected float lifeTime = 10f;
    [SerializeField] protected int facingDiraction;
    [SerializeField] protected Transform checkPosition;
    [SerializeField] protected float checkRadius = 0.5f;
    [SerializeField] protected bool isForPlayer;

    protected int shooterFacingDirection;
    protected string shooterTag;
    protected float fireTime;
    protected Vector2 workspace;
    protected Rigidbody2D RB;
    
    // Start is called before the first frame update
    
    public virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    protected void Start() {
        //print("Start");
        //Fire(1);
    }
    

    public virtual void Update()
    {
        if (Time.time >= fireTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Fire(int shooterFacingDiraction, string shooterTag){
        this.shooterTag = shooterTag;
        fireTime = Time.time;
        if(shooterFacingDiraction != facingDiraction){
            facingDiraction = shooterFacingDiraction;
            RB.transform.Rotate(0.0f, 180f, 0.0f);
        }
        //SetVelocity(projectileVelocity, angle, facingDiraction);
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB.velocity = workspace;
    }

    private void OnDrawGizmosSelected() {
        if(checkPosition != null)
            Gizmos.DrawWireSphere(checkPosition.position, checkRadius);
    }
}
