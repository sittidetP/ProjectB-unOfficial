using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnceSpawer : MonoBehaviour
{
    [SerializeField] GameObject item;
    GameObject insItem;
    Boundaries boundary;

    private void OnEnable() {
        print(transform.position);
        boundary = transform.parent.gameObject.GetComponent<Boundaries>();
        if(insItem == null && BoundariesData.isSpawnOnce != null && !BoundariesData.isSpawnOnce[boundary.Index]){
            print(transform.position);
            insItem = Instantiate(item, transform.position, transform.rotation);
            //insItem = Instantiate(item);
            //insItem.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
        } 
    }
    private void Start() {
        
    }

    private void Update() {
        if(insItem != null){
            //print("item : " + item.name + " still here");
        }else{
            //print("item : " + item.name + " not here");
            BoundariesData.isSpawnOnce[boundary.Index] = true;
        }
    }
}
