using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{    
    [SerializeField] GameObject projectile;
    [SerializeField] float consumedMP;
    [SerializeField] Sprite weaponSprite;
    public Sprite WeaponSprite {get => weaponSprite;}
    public GameObject Projectile {get => projectile; set => projectile = value;}
    public float ConsumedMP {get => consumedMP;}
    
}
