using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public Vector3 position;
    public string[] projectilesName;
    public int[] potionsAmount;
    public int unlockJumps;
    public bool unlockDash;
    public bool[] isSpawnOnces;
}
