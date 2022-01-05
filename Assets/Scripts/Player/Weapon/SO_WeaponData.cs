using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerStateData", menuName = "Data/Player Data/PlayerWeaponData")]
public class SO_WeaponData : ScriptableObject
{
    public WeaponAttackDetails[] AttackDetails;
}
