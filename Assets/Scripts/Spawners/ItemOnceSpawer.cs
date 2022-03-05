using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnceSpawer : MonoBehaviour
{
    [SerializeField] GameObject item;
    GameObject insItem;
    Boundaries boundary;

    private void Start() {
        boundary = transform.parent.gameObject.GetComponent<Boundaries>();
        if(BoundariesData.isSpawnOnce != null && !BoundariesData.isSpawnOnce[boundary.Index]){
            insItem = Instantiate(item, transform.position, transform.rotation); 
        } 
    }

    private void Update() {
        if(insItem != null){
            //print("item still here");
        }else{
            //print("item not here");
            BoundariesData.isSpawnOnce[boundary.Index] = true;
        }
    }
}
