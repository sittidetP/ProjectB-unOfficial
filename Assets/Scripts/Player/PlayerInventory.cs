using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    public Weapon[] weapons;

    public RangeWeapon[] projectiles;

    int indexWeapon = 0;
    int indexProjectile = 0;
    int indexSelectedProjectile = 0;

    public Weapon getSelectedWeapon(){
        return weapons[indexWeapon];
    }

    public void SetProjectile(GameObject projectile){
        if(indexProjectile < projectiles.Length){
            projectiles[indexProjectile].Projectile = projectile;
            indexProjectile++;
        }
    }

    public GameObject getSelectedProjectile(){
        return projectiles[indexSelectedProjectile].Projectile;
    }

    public void SelectSecondLeft(){
        int projectileCount = projectiles.Count(s => s != null);
        int indexFinal = --indexSelectedProjectile%projectileCount;
        if(indexFinal < 0){
            indexFinal = projectileCount - 1;
        }
        //print(indexFinal);
        if(projectiles[indexFinal] != null){
            indexSelectedProjectile = indexFinal;
        }
    }

    public void SelectSecondRigth(){
        int projectileCount = projectiles.Count(s => s != null);
        int indexFinal = ++indexSelectedProjectile%projectileCount;
        if(projectiles[indexFinal] != null){
            indexSelectedProjectile = indexFinal;
        }
    }
}
