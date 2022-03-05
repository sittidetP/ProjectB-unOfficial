using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] BoxCollider2D[] invicibleBoxes;
    GameObject insBoss;
    Boundaries boundary;

    private void OnEnable() {
        boundary = transform.parent.gameObject.GetComponent<Boundaries>();
        if(insBoss == null && BoundariesData.isSpawnOnce != null && !BoundariesData.isSpawnOnce[boundary.Index]){
            insBoss = Instantiate(boss, transform.position, transform.rotation);
            foreach(BoxCollider2D box in invicibleBoxes){
                box.gameObject.SetActive(true);
            }
        } 
    }
    private void Start() {
        
    }

    private void Update() {
        if(insBoss != null){
            //print("item still here");
        }else{
            foreach(BoxCollider2D box in invicibleBoxes){
                box.gameObject.SetActive(false);
            }
            //print("item not here");
            BoundariesData.isSpawnOnce[boundary.Index] = true;
        }
    }
}
