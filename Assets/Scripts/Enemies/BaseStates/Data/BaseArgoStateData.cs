using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEArgoStateData", menuName = "Data/Enemy Data/ArgoStateData")]

public class BaseArgoStateData : ScriptableObject
{
    public float minArgoDistance = 3.0f;
    public float maxArgoDistance = 6.0f;
    public float closeToPlayerDistance = 0.5f;

    public LayerMask whatIsPlayer;
}
