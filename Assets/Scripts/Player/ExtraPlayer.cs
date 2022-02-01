using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlayer : MonoBehaviour
{
    [SerializeField] Transform ceilingCheck;
    [SerializeField] LayerMask whatIsCeiling;

    CollisionSenses playerCollisionSenses;

    private void Start()
    {
        playerCollisionSenses = GetComponentInParent<Player>().Core.CollisionSenses;
        /*
        Debug.Log(playerCollisionSenses.getGroundCheckDistance());
        Debug.Log(playerCollisionSenses.getWhatIsGround());
        */
    }

    public bool Ceiling
    {
        get => Physics2D.Raycast(ceilingCheck.position, Vector2.up, playerCollisionSenses.getGroundCheckDistance(), whatIsCeiling);
        //Physics2D.Raycast(ceilingCheck.position, Vector2.up, playerCore.CollisionSenses.getGroundCheckDistance(), playerCore.CollisionSenses.getWhatIsGround());
    }
}
