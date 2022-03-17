using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeProjectile : Projectile
{
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        Destroy(gameObject);
    }
}
