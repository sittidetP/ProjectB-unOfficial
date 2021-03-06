using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D RB { get; private set; }

    [SerializeField] int facingDirection = 1;
    [SerializeField] PhysicsMaterial2D withFrictionMat;
    private PhysicsMaterial2D defaultPhysMat;

    public int FacingDirection { get => localFacingDirection; private set=> localFacingDirection = value; }

    public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;

    private int localFacingDirection;

    private Entity entity;

    private void OnEnable() {
        localFacingDirection = facingDirection;
    }

    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();
        defaultPhysMat = RB.sharedMaterial;
        entity = GetComponentInParent<Entity>();
        CanSetVelocity = true;
    }

    public override void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;

        
        //print(CurrentVelocity);
    }

    public void SetVelocityZero()
    {
        workspace = Vector2.zero;
        SetFinalVelocity();
    }

    public void SetVelocityX(float velocity)
    {
        //print(core.CollisionSenses.isOnSlope);
        if(core.CollisionSenses.isOnSlope && velocity == 0.0f){
            RB.sharedMaterial = withFrictionMat;
        }else{
            RB.sharedMaterial = defaultPhysMat;
        }
        workspace.Set(velocity, CurrentVelocity.y);
        SetFinalVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        SetFinalVelocity();
    }

    public void SetVelocityXY(float velocityX, float velocityY)
    {
        /*
        if(core.CollisionSenses.isOnSlope && velocityX == 0.0f){
            RB.sharedMaterial = withFrictionMat;
        }else{
            RB.sharedMaterial = defaultPhysMat;
        }
        */
        //workspace.Set(velocityX, velocityY);
        SetVelocityX(velocityX);
        SetVelocityY(velocityY);
        SetFinalVelocity();
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        SetFinalVelocity();
    }

    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }
    }

    public void CheckIfShouldFilp(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Filp();
        }
    }

    public void Filp()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180f, 0.0f);
    }

    public int getInitialFacingDirection()
    {
        return facingDirection;
    }
}
