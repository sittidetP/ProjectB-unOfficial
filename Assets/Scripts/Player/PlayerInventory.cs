using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Weapon[] weapons;

    public GameObject[] projectiles;

    int indexWeapon = 0;
    int indexProjectile = 0;
    int indexSelectedProjectile = 0;

    public Weapon getSelectedWeapon(){
        return weapons[indexWeapon];
    }

    public void SetProjectile(GameObject projectile){
        if(indexProjectile < projectiles.Length){
            projectiles[indexProjectile] = projectile;
            indexProjectile++;
        }
    }

    public GameObject getSelectedProjectile(){
        return projectiles[indexSelectedProjectile];
    }
}
