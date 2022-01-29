using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    [SerializeField] float waitAttackDuration = 0.1f;
    [SerializeField] protected SO_WeaponData weaponData;

    public float WaitAttackDuration{ get; private set; }
    protected PlayerAttackState attackState;

    protected Animator baseAnimator;
    protected Animator weaponAnimator;

    protected int attackCounter;
    protected Core core;

    private float exitTime;
    
    protected virtual void Awake()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        WaitAttackDuration = waitAttackDuration;
        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        SetZeroAttackCounter();
        if (attackCounter >= weaponData.AttackDetails.Length)
        {
            attackCounter = 0;
        }

        baseAnimator.SetBool("attack", true);
        weaponAnimator.SetBool("attack", true);

        baseAnimator.SetInteger("attackCounter", attackCounter);
        weaponAnimator.SetInteger("attackCounter", attackCounter);

    }

    public virtual void ExitWeapon()
    {
        attackCounter++;

        exitTime = Time.time;
    }

    public virtual void AnimationFinishTrigger() 
    {
        attackState.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        //Debug.Log(weaponData.AttackDetails[attackCounter].attackMoveSpeed);
        if(core.CollisionSenses.Ground){
            attackState.SetPlayerVelocity(weaponData.AttackDetails[attackCounter].attackMoveSpeed);
        }
    }

    public virtual void AnimationStopMovementTrigger()
    {
        attackState.SetPlayerVelocity(0f);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        attackState.SetFilpCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        attackState.SetFilpCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {
        
    }

    public void InitializeWeapon(PlayerAttackState attackState, Core core)
    {
        this.attackState = attackState;
        this.core = core;
    }

    public void SetZeroAttackCounter()
    {
        if(Time.time > exitTime + waitAttackDuration)
        {
            attackCounter = 0;
        }
        
    }

    public void SetWeaponActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public void SetAnimationFalse()
    {
        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        
    }
}
