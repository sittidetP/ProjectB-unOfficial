using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEHurtStateData", menuName = "Data/Enemy Data/HurtStateData")]

public class BaseHurtStateData : ScriptableObject
{
    public float hurtDuration = 1.0f;

    public Material hurtMaterial;
    public AudioClip hitSFX;
}
