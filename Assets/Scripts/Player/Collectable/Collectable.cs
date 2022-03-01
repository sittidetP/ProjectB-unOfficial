using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected Player player;
    
    private void OnTriggerEnter2D(Collider2D other) {
        player = other.GetComponent<Player>();
        if(player != null){
            if(canCollect()){
                ActionItem();
                Destroy(gameObject);
            }
            
        }
    }

    protected virtual void ActionItem(){
        
    }

    protected virtual bool canCollect(){
        return true;
    }
}
