using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] UnityEvent onInsEnemyDead;
    GameObject insEnemy;
    private void OnEnable() {
        insEnemy = Instantiate(enemy, transform.position, transform.rotation);
        //print("enable");
    }

    private void Update() {
        if(!insEnemy.activeInHierarchy){
            onInsEnemyDead?.Invoke();
        }
    }

    private void OnDisable() {
        Destroy(insEnemy);
        //print("disable");
    }
}
