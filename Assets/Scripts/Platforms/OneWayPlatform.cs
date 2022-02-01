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
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(player != null){

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }
}
