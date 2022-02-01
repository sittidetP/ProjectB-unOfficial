using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    Player player;

    PlatformEffector2D platformEffector2D;
    
    private void Awake() {
        platformEffector2D = GetComponent<PlatformEffector2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<Player>();
            if(player != null){
                player.isOnPlatform = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(player != null){
            if(player.InputHandler.FallThroughInput){
                platformEffector2D.rotationalOffset = 180f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.isOnPlatform = false;
            player.InputHandler.FallThroughInput = false;
            player.InputHandler.UseJumpInput();
            player = null;
            platformEffector2D.rotationalOffset = 0f;
        }
    }
}
