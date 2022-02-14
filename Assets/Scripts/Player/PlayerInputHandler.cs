using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    public Vector2 RawMovementInput { get; private set; }

    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    public bool JumpInput { get; private set; }
    public bool JumpInputHeld { get; private set; }

    public bool PrimaryAttackInput { get; private set; }

    public bool SecondaryAttackInput {get; private set;}

    public bool DashInput { get; private set; }

    public bool PauseInput { get; private set; }

    public bool FallThroughInput {get; set;}

    [SerializeField] float inputHoldTime;

    private float startJumpHoldTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        JumpInput = false;
        JumpInputHeld = false;
    }

    private void Update()
    {
        CheckJumpInputHold();
    }

    public void OnMoveInput(InputAction.CallbackContext callbackContext)
    {
        RawMovementInput = callbackContext.ReadValue<Vector2>();

        if (!PauseManager.isPause)
        {
            NormInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.y);
        }
    }

    public void OnJumpInput(InputAction.CallbackContext callbackContext)
    {
        if (!PauseManager.isPause)
        {
            if (callbackContext.started)
            {

                JumpInput = true;
                JumpInputHeld = true;
                startJumpHoldTime = Time.time;
            }

            if (callbackContext.canceled)
            {
                JumpInput = false;
                JumpInputHeld = false;
            }
        }
    }

    public void UseJumpInput()
    {
        JumpInput = false;
    }

    private void CheckJumpInputHold()
    {
        if (Time.time > startJumpHoldTime + inputHoldTime)
        {
            JumpInputHeld = false;
        }
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext callbackContext)
    {
        if (!PauseManager.isPause)
        {
            if (callbackContext.started)
            {
                PrimaryAttackInput = true;
            }

            if (callbackContext.canceled)
            {
                PrimaryAttackInput = false;
            }
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext callbackContext)
    {
        if (!PauseManager.isPause)
        {
            if (callbackContext.started)
            {
                SecondaryAttackInput = true;
            }

            if (callbackContext.canceled)
            {
                SecondaryAttackInput = false;
            }
        }
    }

    public void UseSecondaryAttackInput()
    {
        SecondaryAttackInput = false;
    }

    public void UsePrimaryAttackInput()
    {
        PrimaryAttackInput = false;
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (!PauseManager.isPause)
        {
            if (context.started)
            {
                DashInput = true;
            }

            if (context.canceled)
            {
                DashInput = false;
            }
        }
    }

    public void UseDashInput()
    {
        DashInput = false;
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Debug.Log("esc press");
            if (PauseManager.isPause)
            {
                PauseManager.resume();
            }
            else
            {
                PauseManager.pause();
            }
        }
    }

    public bool isPressAnykey(){
        bool checkPress = false;

        if(NormInputX != 0){
            checkPress = true;
        }
        /*
        if(NormInputY != 0){
            checkPress = true;
        }
        */
        if(JumpInput){
            checkPress = true;
        }

        if(DashInput){
            checkPress = true;
        }

        if(PrimaryAttackInput){
            checkPress = true;
        }

        if(SecondaryAttackInput){
            checkPress = true;
        }

        return checkPress;
    }
}
