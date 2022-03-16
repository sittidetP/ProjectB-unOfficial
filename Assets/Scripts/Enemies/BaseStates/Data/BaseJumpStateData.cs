using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEJumpStateData", menuName = "Data/Enemy Data/JumpStateData")]
public class BaseJumpStateData : ScriptableObject
{
    public float jumpVelocity = 10f;
    public float jumpTime = 0.2f;
    public float jumpCooldown = 2f;
    public int jumpDirection = 1;
    public Vector2 jumpAngle;
}
