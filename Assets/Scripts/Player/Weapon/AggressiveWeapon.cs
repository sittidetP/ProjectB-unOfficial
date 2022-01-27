using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class AggressiveWeapon : Weapon
{
    private List<IDamageable> detectedDamageable = new List<IDamageable>();

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = weaponData.AttackDetails[attackCounter];
        foreach(IDamageable item in detectedDamageable.ToList())
        {
            
            item.Damage(details.damageAmount, core.Movement.FacingDirection);
        }
    }

    public void AddToDetected(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponentInChildren<IDamageable>();

        if(damageable != null)
        {
            detectedDamageable.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponentInChildren<IDamageable>();

        if(damageable != null)
        {
            detectedDamageable.Remove(damageable);
        }
    }
}
