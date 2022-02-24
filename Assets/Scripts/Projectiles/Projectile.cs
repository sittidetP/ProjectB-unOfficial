using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : CoreProjectile, IDamageable
{
    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    public void Damage(float amount)
    {
        BeingHit();
    }

    public void Damage(float amount, int attackedDirection)
    {
        BeingHit();
    }

    public override void Update()
    {
        base.Update();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("trigggerEnter : " + other.gameObject.name);
        //print(other.gameObject.layer + ", " +  hasLayers[other.gameObject.layer]);
        //Collider2D detectedObject = Physics2D.OverlapCircle(checkPosition.position, checkRadius, whatToDamage);

        if (hasLayers[other.gameObject.layer])
        {

            IDamageable damageable = other.GetComponentInChildren<IDamageable>();

            if (damageable != null)
            {
                //Debug.Log("player not null");
                damageable.Damage(damageAmount);
            }
            else
            {
                //Debug.Log("player null");
            }
        }
        if (other.gameObject.layer != shooterLayer)
        {
            BeingHit();
        }
        /*
        if (detectedObject == other)
        {
            IDamageable damageable = detectedObject.GetComponentInChildren<IDamageable>();

            if (damageable != null)
            {
                //Debug.Log("player not null");
                damageable.Damage(damageAmount);
            }
            else
            {
                //Debug.Log("player null");
            }
        }
        */

        /*
        IDamageable damageable = other.GetComponent<IDamageable>();
        damageable?.Damage(damageAmount);
        */
        //isHit = true;
    }

    private void BeingHit()
    {
        animator?.SetTrigger("isHit");

        RB.velocity = Vector2.zero;
    }



}
