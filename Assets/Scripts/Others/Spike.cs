using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float damageAmount = 20;
    private void OnTriggerStay2D(Collider2D other) {
        Player player = other.GetComponent<Player>();
        if(player != null){
            player.Core.Combat.Damage(damageAmount);
        }
    }
}
