using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRangeAttackStateData : ScriptableObject
{
    [SerializeField] GameObject projectile;
    public GameObject Projectile => projectile;
}
