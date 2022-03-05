using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;
    GameObject insBoss;
    Boundaries boundary;

    private void OnEnable() {
        boundary = transform.parent.gameObject.GetComponent<Boundaries>();
        if(insBoss == null && BoundariesData.isSpawnOnce != null && !BoundariesData.isSpawnOnce[boundary.Index]){
            insBoss = Instantiate(boss, transform.position, transform.rotation); 
        } 
    }
    private void Start() {
        
    }

    private void Update() {
        if(insBoss != null){
            //print("item still here");
        }else{
            //print("item not here");
            BoundariesData.isSpawnOnce[boundary.Index] = true;
        }
    }
}
