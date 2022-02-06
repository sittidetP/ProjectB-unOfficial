using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform GroundCheckL
    {
        get => GenericsNotImplementedError<Transform>.TryGet(groundCheckL, transform.parent.name);
        private set => groundCheckL = value;
    }

    public Transform GroundCheckR
    {
        get => GenericsNotImplementedError<Transform>.TryGet(groundCheckR, transform.parent.name);
        private set => groundCheckR = value;
    }

    public Transform WallCheck
    {
        get => GenericsNotImplementedError<Transform>.TryGet(wallCheck, transform.parent.name);
        private set => wallCheck = value;
    }

    

    [SerializeField] private Transform groundCheckL;
    [SerializeField] private Transform groundCheckR;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] LayerMask whatIsSlope;

    int localFacing = 1;

    public bool Ground
    {
        get
        {
            bool gLeft = Physics2D.Raycast(groundCheckL.position, Vector2.down, groundCheckDistance, whatIsGround);
            bool gRight = Physics2D.Raycast(groundCheckR.position, Vector2.down, groundCheckDistance, whatIsGround);
            return gLeft || gRight;
        }
    }

    public bool Slope
    {
        get
        {
            bool sLeft = Physics2D.Raycast(groundCheckL.position, Vector2.down, groundCheckDistance, whatIsSlope);
            bool sRight = Physics2D.Raycast(groundCheckR.position, Vector2.down, groundCheckDistance, whatIsSlope);
            return sLeft || sRight;
        }
    }

    public bool GroundLeft
    {
        get =>  Physics2D.Raycast(groundCheckL.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    public bool GroundRight
    {
        get => Physics2D.Raycast(groundCheckR.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    public bool Wall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right*core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public float getGroundCheckDistance()
    {
        return groundCheckDistance;
    }

    public LayerMask getWhatIsGround()
    {
        return whatIsGround;
    }

    private void OnDrawGizmos()
    {        
        if(core != null){
            localFacing = core.Movement.FacingDirection;
        }
        Gizmos.color = Color.red;
        if(groundCheckL != null)
            Gizmos.DrawLine(groundCheckL.position, groundCheckL.position + (Vector3)(Vector2.down*groundCheckDistance));
        if(groundCheckR != null)
            Gizmos.DrawLine(groundCheckR.position, groundCheckR.position + (Vector3)(Vector2.down*groundCheckDistance));
        Gizmos.color = Color.green;
        if(wallCheck != null)
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right*localFacing*wallCheckDistance));
    }
}
