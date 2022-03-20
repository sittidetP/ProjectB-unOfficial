using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float damageAmount = 20;
    [SerializeField] Vector2 knockbackAngle;
    [SerializeField] float knockbackVelocity;
    private void OnTriggerStay2D(Collider2D other) {
        Player player = other.GetComponent<Player>();
        if(player != null){
            player.Core.Combat.Damage(damageAmount);
            player.Core.Combat.Knockback(knockbackAngle, knockbackVelocity, player.Core.Movement.FacingDirection * -1);
        }
    }
}
