using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlayer : MonoBehaviour
{
    [SerializeField] Transform ceilingCheck;
    [SerializeField] LayerMask whatIsCeiling;
    [SerializeField] AlertTextManager alertTextManager;

    CollisionSenses playerCollisionSenses;

    Core playerCore;

    Player player;

    public PlayerMana PlayerMana {get; private set;}
    public AlertTextManager AlertTextManager {get => alertTextManager;}

    private void Start()
    {
        player = GetComponentInParent<Player>();
        playerCore = player.Core;
        playerCollisionSenses = playerCore.CollisionSenses;
        PlayerMana = GetComponentInChildren<PlayerMana>();
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
