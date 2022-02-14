using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerStateData", menuName = "Data/Player Data/PlayerStateData")]
public class PlayerStateData : ScriptableObject
{
    [Header("Move State")]
    public float moveVelocity = 7;

    [Header("Jump State")]
    public float jumpVelocity = 7;
    public float jumpBootsMultipiler = 1.5f;
    public int amountOfJump = 2;

    [Header("MidAir State")]
    public float jumpVelocityFalloffs = -5f;
    public float fallMultipiler = 1.5f;
    public float coyoteTime = 0.2f;

    [Header("Dash State")]
    public float dashVelocity = 20.0f;
    public float dashDuration = 0.5f;
    public float dashGLinearDrag = 10f;
    public float distBetweenAfterImage = 0.5f;

    public float dashCooldown = 1f;

    [Header("Dead State")]
    public float deadFadeOutTime = 0.5f;
    public float alphaMultiple = 0.1f;
    [Header("Hurt effect")]
    public int amountOfBlinks = 15;
    [Header("Range Attack State")]
    public float rangeAttackCooldown = 0.1f;
    public float rangeAttackIdleTime = 0.3f;
    public LayerMask whatToDamage;
}
