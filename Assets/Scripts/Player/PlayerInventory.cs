using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    public Weapon[] weapons;

    public RangeWeapon[] projectiles;
    public Dictionary<int, Potion> potions = new Dictionary<int, Potion>();

    int indexWeapon = 0;
    int indexProjectile = 0;
    int indexSelectedProjectile = 0;

    private void Start() {
        if(projectiles.Count(s => s != null) == 0){
            UIRangeWeapIcon.Instance.SetRangeWeaponIcon(null);
        }
    }

    private void Update() {
        if(projectiles.Count(s => s != null) > 0){
            UIRangeWeapIcon.Instance.SetRangeWeaponIcon(projectiles[indexSelectedProjectile].WeaponSprite);
        }
    }

    public Weapon getSelectedWeapon(){
        return weapons[indexWeapon];
    }

    public void AddRangeWeapon(RangeWeapon rangeWeapon){
        if(indexProjectile < projectiles.Length){
            projectiles[indexProjectile] = rangeWeapon;
            indexProjectile++;
        }
    }

    public GameObject getSelectedProjectile(){
        return projectiles[indexSelectedProjectile].Projectile;
    }

    public RangeWeapon getSelectedRangeWeapon(){
        return projectiles[indexSelectedProjectile];
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

    public void AddPotions(int indexPotion,Potion potion){
        if(potions.ContainsKey(indexPotion)){
            Potion collectedPotion = potions[indexPotion];
            collectedPotion.AddPotionAmount();
        }else{
            potions.Add(indexPotion, potion);
            potion.AddPotionAmount();
        }
        DebugPotion();
    }

    private void DebugPotion(){
        foreach(KeyValuePair<int, Potion> p in potions){
            Debug.Log(p.Key + ", " + p.Value.name + " : " + p.Value.Amount);
        }
    }
}
