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
    [SerializeField] private float slopeCheckDistance;

    [SerializeField] LayerMask whatIsGround;
    private BoxCollider2D entityCollider;
    private Vector2 colliderSize;
    public bool isOnSlope { get; private set; }
    private float slopeSideAngle;
    private float slopeDownAngle;
    private float slopeDownAngleOld;
    public Vector2 slopeNormalPrep { get; private set; }


    int localFacing = 1;

    private void Start()
    {
        entityCollider = GetComponentInParent<BoxCollider2D>();

        if (entityCollider != null)
        {
            //print("get collider : " + entityCollider.gameObject.name);
            colliderSize = entityCollider.size;
        }
    }

    public bool Ground
    {
        get
        {
            bool gLeft = Physics2D.Raycast(groundCheckL.position, Vector2.down, groundCheckDistance, whatIsGround);
            bool gRight = Physics2D.Raycast(groundCheckR.position, Vector2.down, groundCheckDistance, whatIsGround);
            return gLeft || gRight;
        }
    }

    public bool OnOtherGround(LayerMask otherGround)
    {
        bool gLeft = Physics2D.Raycast(groundCheckL.position, Vector2.down, groundCheckDistance, otherGround);
        bool gRight = Physics2D.Raycast(groundCheckR.position, Vector2.down, groundCheckDistance, otherGround);
        return gLeft || gRight;
    }
    
    public bool GroundLeft
    {
        get => Physics2D.Raycast(groundCheckL.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    public bool GroundRight
    {
        get => Physics2D.Raycast(groundCheckR.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    public bool Wall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }

    public float getGroundCheckDistance()
    {
        return groundCheckDistance;
    }

    public LayerMask getWhatIsGround()
    {
        return whatIsGround;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        slopeCheck();
    }
    public void slopeCheck()
    {
        Vector2 checkPos = transform.position - new Vector3(0.0f, colliderSize.y / 2);

        slopedCheckHorizontal(checkPos);
        slopeCheckVertical(checkPos);
    }

    private void slopedCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, whatIsGround);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, whatIsGround);

        //Debug.Log(slopeHitFront + ", " + slopeHitBack);
        if (slopeHitFront)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }
    }

    private void slopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, whatIsGround);

        if (hit)
        {
            slopeNormalPrep = Vector2.Perpendicular(hit.normal).normalized;

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            Debug.DrawRay(hit.point, slopeNormalPrep, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }
    }

    private void OnDrawGizmos()
    {
        if (core != null)
        {
            localFacing = core.Movement.FacingDirection;
        }
        Gizmos.color = Color.red;
        if (groundCheckL != null)
            Gizmos.DrawLine(groundCheckL.position, groundCheckL.position + (Vector3)(Vector2.down * groundCheckDistance));
        if (groundCheckR != null)
            Gizmos.DrawLine(groundCheckR.position, groundCheckR.position + (Vector3)(Vector2.down * groundCheckDistance));
        Gizmos.color = Color.green;
        if (wallCheck != null)
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * localFacing * wallCheckDistance));
    }
}
