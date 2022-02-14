using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : Projectile
{
    public override void Fire()
    {
        base.Fire();

        RB.velocity = Vector2.right * facingDiraction * projectileVelocity;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
