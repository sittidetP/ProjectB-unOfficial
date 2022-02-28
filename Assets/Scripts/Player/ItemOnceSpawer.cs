using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnceSpawer : MonoBehaviour
{
    [SerializeField] GameObject item;
    GameObject insItem;
    private void OnEnable() {
        insItem = Instantiate(item, transform.position, transform.rotation);
        //print("enable");
    }

    private void Update() {
        if(insItem != null){
            print("item still here");
        }else{
            print("item not here");
        }
    }

    private void OnDisable() {
        Destroy(insItem);
        //print("disable");
    }
}
