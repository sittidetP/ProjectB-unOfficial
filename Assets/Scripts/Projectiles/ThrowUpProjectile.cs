using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowUpProjectile : Projectile
{
    [SerializeField] Vector2 angle;
    public override void Fire()
    {
        base.Fire();

        SetVelocity(projectileVelocity, angle, facingDiraction);
    }

    private void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB.velocity = workspace;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
