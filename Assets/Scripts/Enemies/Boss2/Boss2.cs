using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Enemy
{
    [Header("Other Objects")]
    [SerializeField] Transform enemyEye;
    [SerializeField] Transform meleeHitboxPosition;
    [SerializeField] int debugFacing = 1;
    [SerializeField] AudioClip deadSFX;
    public AudioClip DeadSFX { get => deadSFX; }
    float gizmosDrawRadius = 0.25f;
    Material normalMaterial;
    bool isHurt;
    float startTime;
    /*
    private void BlinkWhenDamaged()
    {
        if (!isHurt)
        {
            AudioSource.PlayOneShot(hurtStateData.hitSFX);
            startTime = Time.time;
            isHurt = true;
        }
        if (isHurt && Time.time > startTime + hurtStateData.hurtDuration)
        {
            SpriteRenderer.material = normalMaterial;
            Core.Combat.setIsNotDamage();
            isHurt = false;
        }
        else if (isHurt && Time.time <= startTime + hurtStateData.hurtDuration)
        {
            SpriteRenderer.material = hurtStateData.hurtMaterial;
        }
    }

    private void OnDrawGizmos()
    {


        if (Core != null)
        {
            debugFacing = Core.Movement.FacingDirection;
        }

        Gizmos.color = Color.white;
        if (enemyEye != null)
        {
            Gizmos.DrawWireSphere(enemyEye.position + new Vector3(argoStateData.minArgoDistance * debugFacing, 0.0f, 0.0f), gizmosDrawRadius);
            Gizmos.DrawWireSphere(enemyEye.position + new Vector3(argoStateData.maxArgoDistance * debugFacing, 0.0f, 0.0f), gizmosDrawRadius);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeHitboxPosition.position, meleeAttackStateData.HitboxRadius);

        Gizmos.color = Color.blue;
        if (enemyEye != null)
        {
            Gizmos.DrawLine(enemyEye.position, enemyEye.position + (Vector3)Vector2.right * debugFacing * argoStateData.closeToPlayerDistance);
        }
    }
    */
}
