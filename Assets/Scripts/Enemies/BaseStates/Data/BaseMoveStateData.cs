using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEMoveStateData", menuName = "Data/Enemy Data/MoveStateData")]

public class BaseMoveStateData : ScriptableObject
{
    public float moveVelocity = 3.0f;
    public float moveDuration = 1.5f;
}
