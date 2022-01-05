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

    [SerializeField] private Transform groundCheckL;
    [SerializeField] private Transform groundCheckR;

    [SerializeField] private float groundCheckDistance;

    [SerializeField] LayerMask whatIsGround;

    public bool Ground
    {
        get
        {
            bool gLeft = Physics2D.Raycast(groundCheckL.position, Vector2.down, groundCheckDistance, whatIsGround);
            bool gRight = Physics2D.Raycast(groundCheckR.position, Vector2.down, groundCheckDistance, whatIsGround);
            return gLeft || gRight;
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
        Gizmos.color = Color.red;
        if(groundCheckL != null)
            Gizmos.DrawLine(groundCheckL.position, groundCheckL.position + (Vector3)(Vector2.down*groundCheckDistance));
        if(groundCheckR != null)
            Gizmos.DrawLine(groundCheckR.position, groundCheckR.position + (Vector3)(Vector2.down*groundCheckDistance));
    }
}
