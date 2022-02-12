using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangeAtkStateData", menuName = "Data/Enemy Data/RangeAttackStateData")]
public class BaseRangeAttackStateData : ScriptableObject
{
    [SerializeField] GameObject projectile;
    public GameObject Projectile => projectile;
    [SerializeField] float cooldownTime = 0.5f;
    public float CooldownTime => cooldownTime;
}
