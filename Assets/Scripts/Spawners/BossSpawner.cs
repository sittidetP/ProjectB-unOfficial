using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] BoxCollider2D[] invicibleBoxes;
    [SerializeField] UnityEvent onBossStart;
    [SerializeField] UnityEvent onBossDead;
    GameObject insBoss;
    Boundaries boundary;

    private void OnEnable() {
        boundary = transform.parent.gameObject.GetComponent<Boundaries>();
        if(insBoss == null && BoundariesData.isSpawnOnce != null && !BoundariesData.isSpawnOnce[boundary.Index]){
            insBoss = Instantiate(boss, transform.position, transform.rotation);
            foreach(BoxCollider2D box in invicibleBoxes){
                onBossStart?.Invoke();
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
                onBossDead?.Invoke();
                box.gameObject.SetActive(false);
            }
            //print("item not here");
            BoundariesData.isSpawnOnce[boundary.Index] = true;
        }
    }
}
