using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public Vector3 position;
    public RangeWeapon[] projectiles;
    public Potion[] potions;
    public int unlockJumps;
    public bool unlockDash;
}
