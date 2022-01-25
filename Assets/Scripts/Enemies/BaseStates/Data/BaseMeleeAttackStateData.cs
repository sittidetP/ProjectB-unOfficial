using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAtkStateData", menuName = "Data/Enemy Data/MeleeAttackStateData")]
public class BaseMeleeAttackStateData : ScriptableObject
{
    public float HitboxRadius = 1.0f;
    public float attackDamage = 5f;
    public float attackVelocity = 0.0f;
    public float cooldownTime = 0.5f;
}
