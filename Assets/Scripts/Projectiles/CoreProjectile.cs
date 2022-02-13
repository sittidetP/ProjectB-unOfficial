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
    protected LayerMask whatToDamage;
    protected float fireTime;
    protected Vector2 workspace;
    protected Rigidbody2D RB;
    
    protected bool[] hasLayers = new bool[32];
    private void CheckMasks()
    {
        for (int i = 0; i < 32; i++)
        {
            if (whatToDamage == (whatToDamage | (1 << i)))
            {
                hasLayers[i] = true;
            }
        }
    }
    // Start is called before the first frame update
    
    public virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    protected void Start() {
        //print("Start");
        Fire();
    }
    

    public virtual void Update()
    {
        if (Time.time >= fireTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public virtual void SetUpProjectile(int shooterFacingDiraction, LayerMask whatToDamage){
        this.whatToDamage = whatToDamage;
        CheckMasks();
        if(shooterFacingDiraction != facingDiraction){
            facingDiraction = shooterFacingDiraction;
            RB.transform.Rotate(0.0f, 180f, 0.0f);
        }
    }

    public virtual void Fire(){
        
        fireTime = Time.time;
        
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
