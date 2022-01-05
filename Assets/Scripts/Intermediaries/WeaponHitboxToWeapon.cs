using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxToWeapon : MonoBehaviour
{
    AggressiveWeapon aggressiveWeapon;

    private void Awake()
    {
        aggressiveWeapon = GetComponentInParent<AggressiveWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aggressiveWeapon.AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aggressiveWeapon.RemoveFromDetected(collision);
    }
}
