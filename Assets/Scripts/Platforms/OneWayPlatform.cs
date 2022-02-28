using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    [SerializeField] float filpTime = 0.15f;
    Player player;
    PlatformEffector2D platformEffector2D;
    private float startFilpTime;


    private void Awake()
    {
        platformEffector2D = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (player != null)
        {
            print(transform.parent.name + ", ftInput : " + player.InputHandler.FallThroughInput);
            if (player.InputHandler.FallThroughInput)
            {
                platformEffector2D.rotationalOffset = 180f;
                startFilpTime = Time.time;
            }else if(Time.time > startFilpTime + filpTime){
                platformEffector2D.rotationalOffset = 0f;
            }
            /*
            else if (player.IdleState.OnGroundOnly() || player.MoveState.OnGroundOnly())
            {
                platformEffector2D.rotationalOffset = 0f;
                player = null;
            }
            */
        }else{
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.isOnPlatform = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (player != null)
        {
            player.InputHandler.FallThroughInput = false;
            player.InputHandler.UseJumpInput();
            //player.isOnPlatform = false;
            //player.InputHandler.FallThroughInput = false;
            
        }
    }
}
