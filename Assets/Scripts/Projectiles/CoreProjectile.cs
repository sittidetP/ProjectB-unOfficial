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
    [SerializeField] protected AudioClip shootSFX;
    [SerializeField] protected AudioClip destroySFX;
    protected Animator animator;
    protected int shooterFacingDirection;
    protected LayerMask whatToDamage;
    protected float fireTime;
    protected Vector2 workspace;
    protected Rigidbody2D RB;
    protected bool isAnimationFinished;
    protected bool[] hasLayers = new bool[32];
    protected int shooterLayer;
    protected AudioSource audioSource;
    private void CheckMasks()
    {
        for (int i = 0; i < 32; i++)
        {
            if (whatToDamage == (whatToDamage | (1 << i)))
            {
                hasLayers[i] = true;
            }
            //print(i + ", " + hasLayers[i]);
        }
    }
    // Start is called before the first frame update
    
    public virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    protected void Start() {
        isAnimationFinished = false;
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

    public virtual void SetUpProjectile(int shooterFacingDiraction, LayerMask whatToDamage, int shooterLayer){
        this.whatToDamage = whatToDamage;
        this.shooterLayer = shooterLayer;
        CheckMasks();
        if(shooterFacingDiraction != facingDiraction){
            facingDiraction = shooterFacingDiraction;
            RB.transform.Rotate(0.0f, 180f, 0.0f);
        }
    }

    public virtual void Fire(){
        
        fireTime = Time.time;
        if(shootSFX){
            audioSource.PlayOneShot(shootSFX);
        }
        //SetVelocity(projectileVelocity, angle, facingDiraction);
    }

    public virtual void AnimationFinishTrigger(){
        isAnimationFinished = true;
    }

    private void OnDrawGizmosSelected() {
        if(checkPosition != null)
            Gizmos.DrawWireSphere(checkPosition.position, checkRadius);
    }
}
