using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : CoreProjectile, IDamageable
{
    protected bool isHit;

    private List<IDamageable> detectedDamageable = new List<IDamageable>();
    public void Damage(float amount)
    {

    }

    public void Damage(float amount, int attackedDirection)
    {

    }

    public override void Update()
    {
        base.Update();

        if (isHit)
        {
            //Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("trigggerEnter : " + other.gameObject.name);

        //Collider2D detectedObject = Physics2D.OverlapCircle(checkPosition.position, checkRadius, whatToDamage);

        for (int i = 0; i < 32; ++i)
        {
            if (other.gameObject.layer == i && hasLayers[i])
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

}
