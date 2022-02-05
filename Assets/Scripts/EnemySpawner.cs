using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    GameObject insEnemy;
    private void OnEnable() {
        insEnemy = Instantiate(enemy);
        //print("enable");
    }

    private void OnDisable() {
        Destroy(insEnemy);
        //print("disable");
    }
}
