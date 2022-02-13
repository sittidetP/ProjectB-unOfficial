using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : CoreProjectile, IDamageable
{
    protected bool isHit;

    public void Damage(float amount)
    {
        
    }

    public void Damage(float amount, int attackedDirection)
    {
        
    }

    public override void Update()
    {
        base.Update();
        
        if(isHit){
            //Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(shooterTag.Equals("Enemy")){
            
        }else if(shooterTag.Equals("Player")){

        }
        /*
        IDamageable damageable = other.GetComponent<IDamageable>();
        damageable?.Damage(damageAmount);
        */
        //isHit = true;
    }

}
