using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonProjectile : Projectile
{
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        RB.velocity = Vector2.right * facingDiraction * projectileVelocity;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        Destroy(gameObject);
    }
}
