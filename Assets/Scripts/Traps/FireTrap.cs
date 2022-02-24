using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] float damageAmount = 20;
    [SerializeField] float idleTime = 1f;
    [SerializeField] float activationTime = 0.8f;

    private Animator animator;
    private float startIdleTime;
    private float startActivationTime;
    private bool isIdle;
    private bool isActive;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetBool("idle", true);
        isIdle = true;
        isActive = false;
        startIdleTime = Time.time;
    }

    private void Update()
    {
        if (isIdle && Time.time > startIdleTime + idleTime)
        {
            animator.SetBool("idle", false);
            animator.SetBool("active", true);
            startActivationTime = Time.time;
            isIdle = false;
            isActive = true;
        }
        else if (isActive && Time.time > startActivationTime + activationTime)
        {
            animator.SetBool("active", false);
            animator.SetBool("idle", true);
            startIdleTime = Time.time;
            isIdle = true;
            isActive = false;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.Core.Combat.Damage(damageAmount);
        }
    }
}
