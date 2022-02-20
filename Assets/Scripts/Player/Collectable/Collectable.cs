using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField] protected GameObject item;
    protected Player player;
    private void OnTriggerEnter2D(Collider2D other) {
        player = other.GetComponent<Player>();
        if(player != null){
            ActionItem();
            Destroy(gameObject);
        }
    }

    protected virtual void ActionItem(){
        
    }
}
